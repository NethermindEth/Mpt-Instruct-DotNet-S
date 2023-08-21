# Mpt-Instruct-DotNet-S
This repository hosts examples of (`Nethermind/Mpt-Instruct-DotNet-S`)[https://huggingface.co/Nethermind/Mpt-Instruct-DotNet-S] usage and training procedures.

## Use on CPU in .Net
We created a GGML wrapper for MPT GGML codes and provided it in this repository. Quantised weights can be automatically downloaded from (`Nethermind/Mpt-Instruct-DotNet-S`)[https://huggingface.co/Nethermind/Mpt-Instruct-DotNet-S]. We provide three flavours:
 - f15 - for best results, requires > 14GB of free RAM, slow
 - q8 - for results with lower quality yet generated faster, requires> 7.5GB of free RAM
 - q5 - for results with even lower quality yet generated in the least amount of time, requires> 4.5GB of free RAM

 Use:
```csharp
var downloader = new ModelDownloader();
            var path = await downloader.DownloadModel("q8"); // you also can use f16 (eats 14 GB of RAM), q5 (eats 4 GB)
            var mpt = new MptConsole(new mpt_params()
            {
                model = path,
                n_predict = 512,
                n_ctx = 1024,
                n_threads = 16
            });
            var result = mpt.Process(@"You are an experienced .Net C# developer. Below is an instruction that describes a task. Write a response that completes the request providing detailed explanations with code examples.
### Instruction:
interface IRobot {
    void Take(string what);
    void Cut(int size);
    void Give(string to);
}

You are a robot. Create a sample of _api usage performing what is asked in Example:
Rick asks a robot: slice and pass me the butter, please

Create example using _api continuing this code:
class Request {
    IRobot _api;
    void Do() {
### Response:
");

Console.WriteLine("--------------------------------");
Console.WriteLine(result.FilterString());
```

## Use on GPU in Python
It will requier > 8000MB of free GPU ram even with `load_in_8bit=True` In short:
```python
import torch
import transformers
from transformers import AutoTokenizer

tokenizer = AutoTokenizer.from_pretrained("EleutherAI/gpt-neox-20b")
tokenizer.pad_token = tokenizer.eos_token

device = torch.device("cuda")
model_name = "Nethermind/Mpt-Instruct-DotNet-S"
config = transformers.AutoConfig.from_pretrained(model_name, trust_remote_code=True)
config.init_device = device
config.max_seq_len = 1024 
config.attn_config['attn_impl'] = 'torch'
config.use_cache = False

model = transformers.AutoModelForCausalLM.from_pretrained(
	model_name,
	config=config,
	torch_dtype=torch.bfloat16,
	trust_remote_code=True,
	ignore_mismatched_sizes=True,
	# load_in_8bit=True # when low on GPU memory
)
model.eval()

INSTRUCTION_KEY = "### Instruction:"
RESPONSE_KEY = "### Response:"
PROMPT_FOR_GENERATION_FORMAT = """{system}
{instruction_key}
{instruction}
{response_key}
""".format(
    system="{system}",
    instruction_key=INSTRUCTION_KEY,
    instruction="{instruction}",
    response_key=RESPONSE_KEY
)

def give_answer(instruction="Create a loop over [0, 6, 7 , 77] that prints its contentrs", system="You are an experienced .Net C# developer. Below is an instruction that describes a task. Write a response that completes the request providing detailed explanations with code examples.", ):
    question = PROMPT_FOR_GENERATION_FORMAT.format(system=system, instruction=instruction)
    input_tokens = tokenizer.encode(question ,return_tensors='pt')               
	model.generate(input_tokens.to(device), max_new_tokens=min(512, 1024 - input_tokens.shape[1]), do_sample=False, top_k=1, top_p=0.95)
    outputs = output_loop(tokenized_question)
    answer = tokenizer.batch_decode(outputs, skip_special_tokens=True)
    print(answer[0])

```

### GPU speedups
Set max_new_tokens to 256, 1024-prompt tokens length is its limit.