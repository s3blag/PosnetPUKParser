using System.Threading.Tasks;

namespace PosnetParser.Interfaces
{
    public interface IFileService
    {
        Task<string> ReadFileAsync(string path);
        Task SaveFileAsync(string path, string content);
    }
}