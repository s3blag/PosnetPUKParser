using PosnetParser.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PosnetParser.Services
{
    public class FileService : IFileService
    {
        public async Task<string[]> ReadFileLinesAsync(string path)
        {
            var fileExists = File.Exists(path);

            if (!fileExists)
            {
                throw new Exception("Specified file doesn't exist.");
            }

            var fileLines = await File.ReadAllLinesAsync(path);

            if (fileLines.Count() < 4)
            {
                throw new Exception("Specified file doesn't have any data.");
            }

            return fileLines;
        }

        public async Task SaveFileAsync(string path, string content)
        {
            var fileExists = File.Exists(path);

            if (fileExists)
            {
                throw new Exception("Specified file already exists.");
            }

            await File.WriteAllTextAsync(path, content);
        }
    }
}
