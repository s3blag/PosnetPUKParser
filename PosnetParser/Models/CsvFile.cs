using PosnetParser.Enums;

namespace PosnetParser.Models
{
    public class CsvFile
    {
        private readonly string _parsedData;

        public CsvFile(string parsedData, CsvSeparator csvSeparator)
        {
            _parsedData = parsedData;
            Separator = csvSeparator;
        }

        public CsvSeparator Separator { get; }

        public override string ToString() => _parsedData;
    }
}
