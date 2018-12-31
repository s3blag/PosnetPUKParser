using PosnetParser.Helpers;
using PosnetParser.Interfaces;
using PosnetParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PosnetParser.Services
{
    public class PUKDatabaseDeserializer : IPUKDatabaseDeserializer
    {
        private readonly string _separator;
        private readonly List<ProductWithMetadata> _products = new List<ProductWithMetadata>();
        private readonly List<EanWithMetadata> _eans = new List<EanWithMetadata>();
        private readonly List<SetWithMetadata> _sets = new List<SetWithMetadata>();
        private readonly List<Warning> _warnings = new List<Warning>();

        public PUKDatabaseDeserializer()
        {
            _separator = Enums.CsvSeparator.Tabulation.GetCorrespondingEnumValue();
        }

        public PosnetProductsDatabase Deserialize(string db)
        {
            _products.Clear();
            _eans.Clear();
            _sets.Clear();
            _warnings.Clear();
            var groupedDbString = new GroupedDbString(db);

            GetProducts(groupedDbString.Products);
            GetEans(groupedDbString.Eans);
            GetSets(groupedDbString.Sets);

            return new PosnetProductsDatabase(groupedDbString.Device, _products, _eans, _sets, _warnings);
        }

        private void GetProducts(string[] productsStrings)
        {
            foreach (var productString in productsStrings)
            {
                var product = CreateProductFromString(productString);

                if (product.IsValid)
                {
                    _products.Add(product);
                }
                else
                {
                    _warnings.Add(new Warning(productString, 0));
                }
            }
        }

        private void GetEans(string[] eansStrings)
        {
            foreach (var eanString in eansStrings)
            {
                var ean = CreateEanFromString(eanString);

                if (ean.IsValid)
                {
                    _eans.Add(ean);
                }
                else
                {
                    _warnings.Add(new Warning(eanString, 0));
                }
            }
        }

        private void GetSets(string[] setsStrings)
        {
            foreach (var setString in setsStrings)
            {
                var set = CreateSetFromString(setString);

                if (set.IsValid)
                {
                    _sets.Add(set);
                }
                else
                {
                    _warnings.Add(new Warning(setString, 0));
                }
            }
        }

        private ProductWithMetadata CreateProductFromString(string csvLine)
        {
            var productValues = csvLine.Split(_separator);

            return ProductWithMetadata.Create(productValues);
        }

        private EanWithMetadata CreateEanFromString(string csvLine)
        {
            var eanValues = csvLine.Split(_separator);

            return EanWithMetadata.Create(eanValues);
        }

        private SetWithMetadata CreateSetFromString(string csvLine)
        {
            var setValues = csvLine.Split(_separator);

            return SetWithMetadata.Create(setValues);
        }

        private void ThrowInvalidFileException()
        {
            throw new Exception("Given file is not a valid PKU database CSV file.");
        }
    }
}
