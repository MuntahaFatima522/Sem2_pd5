using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.DL;

namespace Task_2.BL
{
    internal class Product
    {
        public string name;
        public string category;
        public double price;
        public int availableStockQuantity;
        public int minimumStockThreshold;
        public double salesTax;
        public Product(string name, string category, double price, int availableStockQuantity, int minimumStockThreshold)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.availableStockQuantity = availableStockQuantity;
            this.minimumStockThreshold = minimumStockThreshold;
            salesTax = (CalculateSalesTax()/100)*price;
        }

        public double CalculateSalesTax()
        {
            if (category == "grocery" || category == "Grocery")
            {
                return 10.0;
            }
            else if (category == "fruit" || category == "Fruit")
            {
                return 5.0;
            }
            else
            {
                return 15.0;
            }
        }
    }
}
