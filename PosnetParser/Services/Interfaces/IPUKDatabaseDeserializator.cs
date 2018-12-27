using PosnetParser.Models;

namespace PosnetParser.Interfaces
{
    public interface IPUKDatabaseDeserializator
    {
        PosnetProductsDatabase Deserialize(string[] dbFileLines);
    }
}