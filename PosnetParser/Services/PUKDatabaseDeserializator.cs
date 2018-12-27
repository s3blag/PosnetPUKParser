using PosnetParser.Helpers;
using PosnetParser.Interfaces;
using PosnetParser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PosnetParser.Services
{
    public class PUKDatabaseDeserializator : IPUKDatabaseDeserializator
    {
        private readonly string _separator;
        private readonly int _numberOfPropertiesInProductClass;

        public PUKDatabaseDeserializator()
        {
            _separator = new EnumValuesProvider().GetCsvSeparatorValue(Enums.CsvSeparator.Tabulation);
            _numberOfPropertiesInProductClass = typeof(Product).GetProperties().Count();
        }

        public PosnetProductsDatabase Deserialize(string[] dbFileLines)
        {
            var deviceInfo = ReadDeviceMetadata(dbFileLines);

            var products = new List<Product>(dbFileLines.Count()-2);

            //TODO
            Parallel.ForEach(dbFileLines.Skip(3).Take(4098), productDbLine =>
            {
                products.Add(CreateProductFromLine(productDbLine));
            });

            return new PosnetProductsDatabase(deviceInfo, products);
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

        private Product CreateProductFromLine(string csvLine)
        {
            var productValues = csvLine.Split(_separator);

            if (productValues.Count()-1 != _numberOfPropertiesInProductClass)
            {
                ThrowInvalidFileException();
            }

            return
                new Product(
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
