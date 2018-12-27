using PosnetParser.Models;

namespace PosnetParser.Interfaces
{
    public interface IParser
    {
        string Parse(PosnetProductsDatabase posnetProductsDatabase);
    }
}
