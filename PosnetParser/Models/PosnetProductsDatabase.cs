using System.Collections.Generic;
using System.Linq;

namespace PosnetParser.Models
{
    public class PosnetProductsDatabase
    {
        public PosnetProductsDatabase(
            string cashRegisterModel, 
            ICollection<ProductWithMetadata> products,
            ICollection<EanWithMetadata> eans,
            ICollection<SetWithMetadata> sets,
            ICollection<Warning> warnings)
        {
            if (!products.Any() && !eans.Any() && !sets.Any())
            {
                IsEmpty = true;
            }
            else
            {
                CashRegisterModel = cashRegisterModel;
                Products = (IReadOnlyCollection<Product>)products;
                Sets = (IReadOnlyCollection<Set>)sets;
                Eans = (IReadOnlyCollection<Ean>)eans;
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

        public IReadOnlyCollection<Ean> Eans { get; set; }

        public IReadOnlyCollection<Set> Sets { get; set; }

        public IReadOnlyCollection<Warning> Warnings { get; }

        public int Count => Products.Count;

        public bool HasErrors => Warnings.Any();

        public bool IsEmpty { get; }

        public static PosnetProductsDatabase Empty => new PosnetProductsDatabase();
    }
}
