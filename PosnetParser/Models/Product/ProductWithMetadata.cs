using System;

namespace PosnetParser.Models
{
    public class ProductWithMetadata : Product, IElementWithMetadata
    {
        private ProductWithMetadata()
        {
            IsValid = false;
        }

        private ProductWithMetadata(
            int number,
            string name,
            string barcode,
            string minWarehouse,
            string type,
            int vatNumber,
            decimal price,
            int packageNumber,
            int unitOfMeasureNumber,
            int amountFormat,
            bool isFixed,
            int discountNumber,
            int group,
            int discountCoating,
            double amount,
            int linkedPLU,
            int notebook) 
            : base(
                number, 
                name,
                barcode,
                minWarehouse, 
                type, 
                vatNumber, 
                price, 
                packageNumber, 
                unitOfMeasureNumber, 
                amountFormat, 
                isFixed, 
                discountNumber, 
                group, 
                discountCoating, 
                amount, 
                linkedPLU, 
                notebook)
        {
            IsValid = true;
        }

        public bool IsValid { get; }

        private static ProductWithMetadata NotValid => new ProductWithMetadata();

        public static ProductWithMetadata Create(string[] productValuesFromCsv)
        {
            if (productValuesFromCsv.Length - 1 != typeof(Product).GetProperties().Length)
            {
                return NotValid;
            }

            return new ProductWithMetadata(
                Convert.ToInt32(productValuesFromCsv[0]),
                productValuesFromCsv[1],
                productValuesFromCsv[2],
                productValuesFromCsv[3],
                productValuesFromCsv[4],
                Convert.ToInt32(productValuesFromCsv[5]),
                Convert.ToDecimal(productValuesFromCsv[6]),
                Convert.ToInt32(productValuesFromCsv[7]),
                Convert.ToInt32(productValuesFromCsv[8]),
                Convert.ToInt32(productValuesFromCsv[9]),
                productValuesFromCsv[10] == "0" ? false : true,
                Convert.ToInt32(productValuesFromCsv[11]),
                Convert.ToInt32(productValuesFromCsv[12]),
                Convert.ToInt32(productValuesFromCsv[13]),
                Convert.ToInt32(productValuesFromCsv[14]),
                Convert.ToInt32(productValuesFromCsv[15]),
                Convert.ToInt32(productValuesFromCsv[16]));
        }
    }
}
