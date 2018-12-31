using PosnetParser.Enums;
using System;
using System.Text;

namespace PosnetParser.Helpers
{
    public static class Extensions
    {
        public static void AppendField(this StringBuilder stringBuilder, string separator, string fieldValue)
        {
            stringBuilder.Append(fieldValue);
            stringBuilder.Append(separator);
        }

        public static string GetCorrespondingEnumValue(this CsvSeparator csvSeparator)
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
