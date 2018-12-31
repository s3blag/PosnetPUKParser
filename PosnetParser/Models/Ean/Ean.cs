namespace PosnetParser.Models
{
    public class Ean
    {
        protected Ean()
        {

        }

        protected Ean(int number, string barcode, decimal price)
        {
            Number = number;
            Barcode = barcode;
            Price = price;
        }

        public int Number { get; }
        public string Barcode { get; }
        public decimal Price { get; }
    }
}
