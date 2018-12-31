namespace PosnetParser.Models
{
    public class Product
    {
        protected Product(
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
            int notebook
        )
        {
            Number = number;
            Name = name;
            Barcode = barcode;
            MinWarehouse = minWarehouse;
            Type = type;
            Price = price;
            PackageNumber = packageNumber;
            UnitOfMeasureNumber = unitOfMeasureNumber;
            AmountFormat = amountFormat;
            Fixed = isFixed;
            DiscountNumber = discountNumber;
            Group = group;
            DiscountCoating = discountCoating;
            Amount = amount;
            LinkedPLU = linkedPLU;
            Notebook = notebook;
        }

        protected Product()
        {
        }

        public int Number { get; }
        public string Name { get; }
        public string Barcode { get; }
        public string MinWarehouse { get; }
        public string Type { get; }
        public int VATNumber { get; }
        public decimal Price { get; }
        public int PackageNumber { get; }
        public int UnitOfMeasureNumber { get; }
        public int AmountFormat { get; }
        public bool Fixed { get; }
        public int DiscountNumber { get; }
        public int Group { get; }
        public int DiscountCoating { get; }
        public double Amount { get; }
        public int LinkedPLU { get; }
        public int Notebook { get; }
    }
}
