using System.Threading.Tasks;

namespace PosnetParser.Interfaces
{
    public interface IFileService
    {
        Task<string[]> ReadFileLinesAsync(string path);
        Task SaveFileAsync(string path, string content);
    }
}