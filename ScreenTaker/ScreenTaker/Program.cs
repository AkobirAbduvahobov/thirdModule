using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xabe.FFmpeg;

class Program
{
    static async Task Main()
    {


        Hashtable
        
        var s1 = "{[]({})}";

        /// 


        var s2 = "({[({{[]}})]})";
        var s3 = "()";
        var s4 = ")(";
        var s5 = "([]{)()}";

        // ({

        Console.WriteLine(IsValid(s1));
        Console.WriteLine(IsValid(s2));
        Console.WriteLine(IsValid(s3));
        Console.WriteLine(IsValid(s4));
        Console.WriteLine(IsValid(s5));

        


        //var filePath = @"D:\D25_20240923000000.mp4";
        //await GenerateScreenshots(filePath);
    }

    public static bool IsValid(string s)
    {
        var blocks = new List<char>();

        foreach (var ch in s)
        {
            blocks.Add(ch);
            if (blocks.Count() == 1 || blocks.Count() == 0) continue;
            
            else if (blocks[blocks.Count() - 2] == '{'
                && blocks[blocks.Count() - 1] == '}')
            {
                blocks.RemoveAt(blocks.Count() - 2);
                blocks.RemoveAt(blocks.Count() - 1);
            }

            else if (blocks[blocks.Count() - 2] == '['
                && blocks[blocks.Count() - 1] == ']')
            {
                blocks.RemoveAt(blocks.Count() - 2);
                blocks.RemoveAt(blocks.Count() - 1);
            }

            else if (blocks[blocks.Count() - 2] == '('
                && blocks[blocks.Count() - 1] == ')')
            {
                blocks.RemoveAt(blocks.Count() - 2);
                blocks.RemoveAt(blocks.Count() - 1);
            }
        }

        return blocks.Count() == 0;
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
