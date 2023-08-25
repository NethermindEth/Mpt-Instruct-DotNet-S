using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Reflection;

namespace MptLibrary;

public static class StringExtensions
{
    //Check if we can execute string
    public static bool CanBeExecuted(this string code, IEnumerable<Assembly> assemblies = null)
    {
        try
        {
            var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                .WithOverflowChecks(true)
                .WithOptimizationLevel(OptimizationLevel.Release)
                .WithUsings("System", "System.Collections.Generic", "System.Linq");

            var compilation = CSharpCompilation.Create("DynamicCompilation", new[] { CSharpSyntaxTree.ParseText(code) },
                assemblies?.Select(a => MetadataReference.CreateFromFile(a.Location)).ToArray() ?? new MetadataReference[0], options);

            var diagnostics = compilation.GetDiagnostics();

            return !diagnostics.Any(diag => diag.Severity == DiagnosticSeverity.Error);
        }
        catch
        {
            return false;
        }
    }

    //Execute string
    public static object Execute(this string code, IEnumerable<Assembly> assemblies = null)
    {
        var options = ScriptOptions.Default;
        if (assemblies != null)
        {
            options = options.AddReferences(assemblies);
        }

        return CSharpScript.EvaluateAsync(code, options).Result;
    }

    //Filter only readable chars
    public static string FilterString(this string input)
    {
        // Define the allowable characters
        const string allowableChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789{}();\"'/?.,<>!@#$%^&*_-+=|\\[]:";
        return new string(input.Where(c => allowableChars.Contains(c) || char.IsWhiteSpace(c)).ToArray());
    }
}
