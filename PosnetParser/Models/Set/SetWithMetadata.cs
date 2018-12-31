using System;

namespace PosnetParser.Models
{
    public class SetWithMetadata : Set, IElementWithMetadata
    {
        private SetWithMetadata()
        {
            IsValid = false;
        }

        private SetWithMetadata(
            int number,
            string pluElement,
            decimal amount,
            decimal price
            ):
            base(number, pluElement, amount, price)
        {
            IsValid = true;
        }

        public bool IsValid { get; }

        private static SetWithMetadata NotValid => new SetWithMetadata();

        public static SetWithMetadata Create(string[] setFieldValuesFromCsv)
        {
            if (setFieldValuesFromCsv.Length - 1 != typeof(Set).GetProperties().Length)
            {
                return NotValid;
            }

            return new SetWithMetadata(
                Convert.ToInt32(setFieldValuesFromCsv[0]),
                setFieldValuesFromCsv[1],
                Convert.ToDecimal(setFieldValuesFromCsv[2]),
                Convert.ToDecimal(setFieldValuesFromCsv[3])
                );
        }
    }
}
