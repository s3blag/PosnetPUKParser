using PosnetParser.Enums;
using System;

namespace PosnetParser.Helpers
{
    public class EnumValuesProvider
    {
        public string GetCsvSeparatorValue(CsvSeparator csvSeparator)
        {
            switch (csvSeparator)
            {
                case CsvSeparator.Comma:
                    return ",";

                case CsvSeparator.Dot:
                    return ".";

                case CsvSeparator.Semicolon:
                    return ";";

                case CsvSeparator.Space:
                    return " ";

                case CsvSeparator.Tabulation:
                    return "\t";

                default:
                    throw new Exception("Invalid CSV separator value.");
            }
        }
    }
}
