using System.Diagnostics;

namespace MptLibrary;

public class ModelDownloader
{
    private const string ModelsDirectory = "./models/";

    // Download model into "./models/" or return existing one
    // Use "f16", "q8", "q5" to download a Nethermind/Mpt-Instruct-DotNet-S MPT-7B-Instruction based model, pretrained and GGML quantised 
    // Pass in your URL to download any other MPT GGML Quantised model
    public async Task<string> DownloadModel(string option = null, Action<int> progressAction = null)
    {
        string url = DetermineModelUrl(option);
        if (url == null)
        {
            throw new ArgumentException("No valid model option provided.");
            return null;
        }

        string fileName = Path.GetFileName(new Uri(url).LocalPath);
        string localFilePath = Path.Combine(ModelsDirectory, fileName);

        if (!Directory.Exists(ModelsDirectory))
        {
            Directory.CreateDirectory(ModelsDirectory);
        }

        if (File.Exists(localFilePath))
        {
            // File {fileName} already exists. No download needed.
            return localFilePath;
        }

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            using (var contentStream = await response.Content.ReadAsStreamAsync())
            using (var fileStream = new FileStream(localFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var totalBytes = response.Content.Headers.ContentLength.GetValueOrDefault();
                var bytesDownloaded = 0L;
                var buffer = new byte[8192];
                var bytesRead = 0;

                int lastPercentage = -1; // Set to -1 to ensure the first percentage is always printed.

                while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                    bytesDownloaded += bytesRead;

                    int percentage = (int)(100 * (bytesDownloaded / (float)totalBytes));

                    if (percentage != lastPercentage)
                    {
                        // Update the last percentage
                        lastPercentage = percentage;

                        // If progressAction is not provided, use the console printout
                        if (progressAction == null)
                        {
                            Console.WriteLine($"Download progress: {percentage}% " + new string('■', percentage / 2) + new string(' ', 50 - percentage / 2));
                        }
                        else
                        {
                            progressAction(percentage);
                        }
                    }
                }
            }
        }

        return localFilePath;
    }

    private string DetermineModelUrl(string option)
    {

        if (!string.IsNullOrWhiteSpace(option) && !new[] { "f16", "q8", "q5" }.Contains(option))
        {
            return option;
        }

        if (option == "f16" )
            return "https://huggingface.co/Nethermind/Mpt-Instruct-DotNet-S/resolve/main/ggml-model-f16.bin";
        if (option == "q8" )
            return "https://huggingface.co/Nethermind/Mpt-Instruct-DotNet-S/resolve/main/ggml-model-q8_0.bin";
        return "https://huggingface.co/Nethermind/Mpt-Instruct-DotNet-S/resolve/main/ggml-model-q5_0.bin";
    }
}
