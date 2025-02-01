using System;
using System.IO;
using System.Threading.Tasks;
using Xabe.FFmpeg;

class Program
{
    static async Task Main()
    {
        var filePath = @"D:\D51_20240923000000.mp4";
        await GenerateScreenshots(filePath);
    }

    static async Task GenerateScreenshots(string filePath)
    {
        var fileName = Path.GetFileName(filePath);
        fileName = fileName.Remove(fileName.Length - 4);
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Video file does not exist.");
            return;
        }

        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots", fileName);
        Directory.CreateDirectory(outputDir);

        // Get video duration
        var mediaInfo = await FFmpeg.GetMediaInfo(filePath);
        double duration = mediaInfo.Duration.TotalMinutes;

        for (int i = 1; i <= duration; i++)
        {
            string outputPath = Path.Combine(outputDir, $"screenshot_{i}.jpg");
            await FFmpeg.Conversions.New()
                .AddParameter($"-ss {i * 60} -i \"{filePath}\" -vframes 1 -q:v 2 \"{outputPath}\"")
                .Start();

            Console.WriteLine($"Generated screenshot {i} at {i} minutes.");
        }

        Console.WriteLine("Screenshots generated successfully!");
    }
}
