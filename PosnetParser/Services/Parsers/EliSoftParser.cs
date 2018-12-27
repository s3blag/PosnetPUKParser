using PosnetParser.Enums;
using PosnetParser.Helpers;
using PosnetParser.Interfaces;
using PosnetParser.Models;
using System;
using System.Text;

namespace PosnetParser.Services
{
    public class EliSoftParser: IParser
    {
        private readonly StringBuilder _parsedDataSB;
        private readonly string _separator;

        public EliSoftParser()
        {
            _parsedDataSB = new StringBuilder();
            _separator = CsvSeparator.Tabulation.GetEnumValue();
        }

        public string Parse(PosnetProductsDatabase posnetProductsDatabase)
        {
            Clear();

            AddHeader();

            AddProducts(posnetProductsDatabase);

            return GetParsedData();
        }

        private void Clear() => _parsedDataSB.Clear();

        private void AddHeader() => AddLine(GetHeader());

        private void AddProducts(PosnetProductsDatabase posnetProductsDatabase)
        {
            foreach (var product in posnetProductsDatabase.Products)
            {
                AddLine(GetLine(product));
            }
        }

        private string GetParsedData() => _parsedDataSB.ToString();

        private void AddLine(string stringToAppend) => _parsedDataSB.AppendLine(stringToAppend);

        private string GetLine(Product product)
        {
            var productSB = new StringBuilder();

            productSB.AppendField(_separator, product.Number.ToString());
            productSB.AppendField(_separator, product.Name);
            productSB.AppendField(_separator, GetUnitOfMeasure(product.UnitOfMeasureNumber));
            productSB.AppendField(_separator, product.Barcode);
            productSB.AppendField(_separator, product.Amount.ToString());
            productSB.AppendField(_separator, GetVAT(product.VATNumber));

            return productSB.ToString();
        }

        private string GetUnitOfMeasure(int unitOfMeasureNumber)
        {
            switch (unitOfMeasureNumber)
            {
                //TODO
                case 0:
                    return "szt";
                case 1:
                    return "szt";
                case 2:
                    return "kg";
                default:
                    throw new Exception("Invalid unit of measure type number.");
            }
        }

        private string GetVAT(int VATtype)
        {
            switch (VATtype)
            {
                case 0:
                    return "23";
                case 1:
                    return "8";
                case 3:
                    return "5";
                default:
                    throw new Exception("Invalid Vat type number.");
            }
        }

        private string GetHeader()
        {
            return
                "ID" + _separator +
                "Nazwa towaru" + _separator +
                "Jednostka" + _separator +
                "Kod EAN" + _separator +
                "Ilość" + _separator +
                "VAT";
        }
    }
}
