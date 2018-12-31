using System;

namespace PosnetParser.Models
{
    public class EanWithMetadata : Ean, IElementWithMetadata
    {
        private EanWithMetadata()
        {
            IsValid = false;
        }

        private EanWithMetadata(int number, string barcode, decimal price)
            :base(number, barcode, price)
        {
            IsValid = true;
        }

        public bool IsValid { get; }

        private static EanWithMetadata NotValid => new EanWithMetadata();

        public static EanWithMetadata Create(string[] eanValuesFromCsv)
        {
            if (eanValuesFromCsv.Length - 1 != typeof(Ean).GetProperties().Length)
            {
                return NotValid;
            }

            return new EanWithMetadata(
                Convert.ToInt32(eanValuesFromCsv[0]), 
                eanValuesFromCsv[1], 
                Convert.ToDecimal(eanValuesFromCsv[2])
                );
        }
    }
}
