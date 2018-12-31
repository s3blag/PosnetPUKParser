using PosnetParser.Models;

namespace PosnetParser.Interfaces
{
    public interface IPUKDatabaseDeserializer
    {
        PosnetProductsDatabase Deserialize(string db);
    }
}