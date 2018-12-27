using System.Collections.Generic;
using System.Linq;

namespace PosnetParser.Models
{
    public class PosnetProductsDatabase
    {
        public PosnetProductsDatabase(string cashRegisterModel, ICollection<ProductWithMetadata> products, ICollection<Warning> warnings)
        {
            if (!products.Any())
            {
                IsEmpty = true;
            }
            else
            {
                CashRegisterModel = cashRegisterModel;
                Products = (IReadOnlyCollection<Product>)products;
                Warnings = (IReadOnlyCollection<Warning>) warnings;
                IsEmpty = false;
            }
        }

        private PosnetProductsDatabase()
        {
            IsEmpty = true;
        }

        public string CashRegisterModel { get; }

        public IReadOnlyCollection<Product> Products { get; }

        public IReadOnlyCollection<Warning> Warnings { get; }

        public int Count => Products.Count;

        public bool HasErrors => Warnings.Any();

        public bool IsEmpty { get; }

        public static PosnetProductsDatabase Empty => new PosnetProductsDatabase();
    }
}
