using System.Collections.Generic;
using System.Linq;

namespace PosnetParser.Models
{
    public class PosnetProductsDatabase
    {
        public PosnetProductsDatabase(string cashRegisterModel, ICollection<Product> products)
        {
            if (!products.Any())
            {
                IsEmpty = true;
            }
            else
            {
                CashRegisterModel = cashRegisterModel;
                Products = (IReadOnlyCollection<Product>)products;
                IsEmpty = false;
            }
        }

        private PosnetProductsDatabase()
        {
            IsEmpty = true;
        }

        public string CashRegisterModel { get; }

        public IReadOnlyCollection<Product> Products { get; }

        public int Count => Products.Count;

        public bool IsEmpty { get; }

        public static PosnetProductsDatabase Empty => new PosnetProductsDatabase();
    }
}
