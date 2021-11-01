using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketExtensions
{
    public static class FileExtensions
    {
        public async static Task<List<string>> ReadAllLinesAsync(string filePath)
        {
            byte[] result;

            using (FileStream SourceStream = File.Open(filePath, FileMode.Open))
            {
                result = new byte[SourceStream.Length];
                await SourceStream.ReadAsync(result, 0, (int)SourceStream.Length);
            }

            var readOutput = Encoding.ASCII.GetString(result);
            var fileLines = readOutput.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            return fileLines.ToList();
        }

        public async static Task WriteAllLinesAsync(string filePath, List<string> fileLines)
        {
            var enco = new ASCIIEncoding();

            var fileText = String.Join(Environment.NewLine, fileLines);

            var result = enco.GetBytes(fileText);

            // this just overwrites the character at position 0 and nothing else

            

            using (FileStream SourceStream = File.Open(filePath, FileMode.OpenOrCreate))
            {
                if (result.Length == 0)
                {
                    SourceStream.SetLength(0);
                }
                SourceStream.Seek(0, SeekOrigin.Begin);
                await SourceStream.WriteAsync(result, 0, result.Length);
            }
        }

        public async static Task AppendAllLinesAsync(string filePath, IList<string> appendLines)
        {
            var fileLines = new List<String>();

            if (File.Exists(filePath))
            {
                fileLines = await ReadAllLinesAsync(filePath);
            }

            foreach (var i in appendLines)
            {
                fileLines.Add(i);
            }

            await WriteAllLinesAsync(filePath, fileLines);
        }

        public async static Task AppendAllTextAsync(string filePath, string appendText)
        {

            var fileLines = new List<string>();

            if (File.Exists(filePath))
            {
                fileLines = await ReadAllLinesAsync(filePath);
            }

            fileLines.Add(appendText);

            await WriteAllLinesAsync(filePath, fileLines);
        }
    }
}