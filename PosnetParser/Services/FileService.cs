using PosnetParser.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PosnetParser.Services
{
    public class FileService : IFileService
    {
        public async Task<string> ReadFileAsync(string path)
        {
            var fileExists = File.Exists(path);

            if (!fileExists)
            {
                throw new Exception("Specified file doesn't exist.");
            }

            var fileText = await File.ReadAllTextAsync(path);

            if (string.IsNullOrEmpty(fileText))
            {
                throw new Exception("Specified file doesn't have any data.");
            }

            return fileText;
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
