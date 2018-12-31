using System;
using System.Collections.Generic;
using System.Text;

namespace PosnetParser.Models
{
    public class Set
    {
        protected Set()
        {

        }

        protected Set(int number, string pluElement, decimal amount, decimal price)
        {
            Number = number;
            PluElement = pluElement;
            Amount = amount;
            Price = price;
        }

        public int Number { get; set; }
        public string PluElement { get; set; }
        public decimal Amount { get; set; }
        public decimal Price { get; set; }
    }
}
