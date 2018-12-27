using PosnetParser.Helpers;
using PosnetParser.Interfaces;
using PosnetParser.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosnetParser.Services
{
    public class PUKDatabaseDeserializator : IPUKDatabaseDeserializator
    {
        private readonly string _separator;
        private readonly int _numberOfPropertiesInProductClass;
        private readonly List<ProductWithMetadata> _products = new List<ProductWithMetadata>();
        private readonly List<Warning> _warnings = new List<Warning>();

        public PUKDatabaseDeserializator()
        {
            _separator = Enums.CsvSeparator.Tabulation.GetEnumValue();
            _numberOfPropertiesInProductClass = typeof(Product).GetProperties().Count();
        }

        public PosnetProductsDatabase Deserialize(string[] dbFileLines)
        {
            var deviceInfo = ReadDeviceMetadata(dbFileLines);

            //remove unused tables
            _products.Clear();
            _warnings.Clear();

            foreach (var productDbLine in dbFileLines.Skip(3).Take(4098))
            {
                var product = CreateProductFromLine(productDbLine);

                if (product.IsValid)
                {
                    _products.Add(product);
                }
                else
                {
                    _warnings.Add(new Warning(productDbLine, 0));
                }
            }

            return new PosnetProductsDatabase(deviceInfo, _products, _warnings);
        }

        private string ReadDeviceMetadata(string[] serializedDatabase)
        {
            //if data doesn't have device info and @table attribute with 'PLUcodes' value [Regex]
            if (false)
            {
                ThrowInvalidFileException();
            }

            //get device from regex group
            return "";
        }

        private ProductWithMetadata CreateProductFromLine(string csvLine)
        {
            var productValues = csvLine.Split(_separator);

            if (productValues.Length-1 != _numberOfPropertiesInProductClass)
            {
                return ProductWithMetadata.NotValid;
            }

            return
                new ProductWithMetadata(
                    Convert.ToInt32(productValues[0]),
                    productValues[1],
                    productValues[2],
                    productValues[3],
                    productValues[4],
                    Convert.ToInt32(productValues[5]),
                    Convert.ToDecimal(productValues[6]),
                    Convert.ToInt32(productValues[7]),
                    Convert.ToInt32(productValues[8]),
                    Convert.ToInt32(productValues[9]),
                    productValues[10] == "0" ? false : true,
                    Convert.ToInt32(productValues[11]),
                    Convert.ToInt32(productValues[12]),
                    Convert.ToInt32(productValues[13]),
                    Convert.ToInt32(productValues[14]),
                    Convert.ToInt32(productValues[15]),
                    Convert.ToInt32(productValues[16]));
        }

        private void ThrowInvalidFileException()
        {
            throw new Exception("Given file is not a valid PKU database CSV file.");
        }
    }
}
