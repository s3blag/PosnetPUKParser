namespace PosnetParser.Models
{
    public class ProductWithMetadata: Product
    {
        public ProductWithMetadata(
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

        private ProductWithMetadata()
        {
            IsValid = false;
        }

        public bool IsValid { get; }

        public static ProductWithMetadata NotValid => new ProductWithMetadata();
    }
}
