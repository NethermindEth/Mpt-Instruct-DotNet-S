using MptLibrary;

namespace EnjoyMpt
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var downloader = new ModelDownloader();
            var path = await downloader.DownloadModel("q8");
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

            Console.ReadLine();
        }
    }
}
