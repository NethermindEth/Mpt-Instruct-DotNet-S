using BlazorLlm.Shared;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using MptLibrary;
using System.Text.RegularExpressions;
namespace BlazorLlm.Services
{

    public class CodeService
    {
        public static readonly string DefaultSystemPrompt =
            "You are an experienced .Net C# developer. Below is an instruction that describes a task. Write a response that completes the request providing detailed explanations with code examples.";

        public string SystemPrompt { get; set; }

        private readonly MptActionBased _mpt;
        private string buffer = "";
        public CodeService(mpt_params mpt_settings)
        {
            SystemPrompt = DefaultSystemPrompt;
            _mpt = new MptActionBased(mpt_settings);
            _mpt.NewTokenProcessedEvent += token =>
            {
                buffer += token;
                OutputText = Regex.Unescape(buffer.FilterString()); ;
                OnOutputChanged?.Invoke();
            };
        }

        public event Action? OnOutputChanged;
        public string OutputText { get; set; } = string.Empty;

        private string FormatTaskForCodeGen(string task)
        {
            var INSTRUCTION_KEY = "### Instruction:";
            var RESPONSE_KEY = "### Response:";
            var instruction = "Generate code to answer the question.\n" + task;
            return $@"{SystemPrompt}\n{INSTRUCTION_KEY}\n{instruction}\n{RESPONSE_KEY}\n";
        }

        private string FormatTaskForCodeExplaining(string code)
        {
            var INSTRUCTION_KEY = "### Instruction:";
            var RESPONSE_KEY = "### Response:";
            var instruction = "Explain code:\n" + code;
            return $@"{SystemPrompt}\n{INSTRUCTION_KEY}\n{instruction}\n{RESPONSE_KEY}\n";
        }

        public async Task<DataModel> HandleRequestAsync(string task, string code, string action)
        {
            string result = "empty";
            try
            {
                if (action == "generate")
                {
                    var messages = FormatTaskForCodeGen(task);
                    var results = await Task.Run(() =>
                    {
                        return _mpt.Process(messages).FilterString();
                    });

                    results = results.Replace("\ncsharp", "");
                    results = results.Replace("\\ncsharp", "");

                    if (results.EndsWith("<|endoftext|>"))
                    {
                        results = results.Replace("<|endoftext|>", "");
                    }

                    var KEY = "### Response:";
                    string[] parts = results.Split(new[] { KEY }, StringSplitOptions.None);
                    code = parts[1]; // Output code
                }
                if (string.IsNullOrWhiteSpace(code))
                {
                    code = @"return ""Hello, Roslyn!"";";
                }
                if ((action is "generate") || (action is "run"))
                {

                    var options = ScriptOptions.Default;
                    foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                    {
                        if (!assembly.IsDynamic && !string.IsNullOrEmpty(assembly.Location))
                        {
                            options = options.AddReferences(assembly);
                        }
                    }
                    options = options.AddReferences(typeof(Task).Assembly);
                    options = options.AddReferences(typeof(List<>).Assembly);
                    options = options.AddReferences(typeof(Console).Assembly);

                    options = options.WithImports(
                            "System",
                            "System.Collections.Generic",
                            "System.Linq",
                            "System.Text",
                            "System.Threading.Tasks"
                        // ... any other namespaces you consider "standard"
                        );

                    TextWriter originalConsoleOut = Console.Out;

                    try
                    {
                        using (StringWriter sw = new StringWriter())
                        {
                            Console.SetOut(sw);
                            result = await CSharpScript.EvaluateAsync<string>(code, options); // Output results to log
                            Console.SetOut(originalConsoleOut);
                            result = sw + result;

                        }
                    }
                    catch
                    {
                        code = Regex.Unescape(code);
                        using (StringWriter sw = new StringWriter())
                        {
                            Console.SetOut(sw);
                            result = await CSharpScript.EvaluateAsync<string>(code, options); // Output results to log
                            Console.SetOut(originalConsoleOut);
                            result = sw + result;
                        }
                    }
                    finally
                    {
                        Console.SetOut(originalConsoleOut);
                    }

                    if (string.IsNullOrWhiteSpace(result))
                    {
                        result = "empty!";
                    }
                }

                if (action == "explain")
                {
                    var messages = FormatTaskForCodeExplaining(code);

                    var results = await Task.Run(() =>
                    {
                        return _mpt.Process(messages).FilterString();
                    });

                    if (results.EndsWith("<|endoftext|>"))
                    {
                        results = results.Replace("<|endoftext|>", "");
                    }
                    results = Regex.Unescape(results);
                    var KEY = "### Response:";
                    string[] parts = results.Split(new[] { KEY }, StringSplitOptions.None);
                    result = parts[1]; // Output explanation
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            finally
            {
                OutputText = "";
                buffer = "";
            }


            return new DataModel()
            {
                Code = code,
                Log = result,
                Task = task
            };
        }
    }
}
