using System.Text;

namespace PosnetParser.Models
{
    public static class Extensions
    {
        public static void AppendField(this StringBuilder stringBuilder, string separator, string fieldValue)
        {
            stringBuilder.Append(fieldValue);
            stringBuilder.Append(separator);
        }
    }
}
