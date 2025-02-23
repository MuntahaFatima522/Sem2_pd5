using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.BL;
using Task_2.DL;

namespace Task_2.UI
{
    internal class ProductUI
    {
        public static Product TakeInputToAddProduct()
        {
            Console.WriteLine("Enter Product Details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Category: ");
            string category = Console.ReadLine();
            Console.Write("Price: ");
            double price = double.Parse(Console.ReadLine());
            Console.Write("Available Stock Quantity: ");
            int availableStockQuantity = int.Parse(Console.ReadLine());
            Console.Write("Minimum Stock Threshold: ");
            int minimumStockThreshold = int.Parse(Console.ReadLine());
            return new Product(name, category, price, availableStockQuantity, minimumStockThreshold);
        }
        public static void ViewAllProducts()
        {
            Console.WriteLine("All Products:");
            foreach (Product product in ProductCRUD.products)
            {
                Console.WriteLine($"Name: {product.name}\t Category: {product.category}\t Price: {product.price}\t Available Stock Quantity: {product.availableStockQuantity}\t Minimum Stock Threshold: {product.minimumStockThreshold}");
            }

        }
        public static void DisplayHighestPrice()
        {
            Product product=ProductCRUD.FindProductWithHighestUnitPrice();
            Console.WriteLine("Product with highest price is "+product.name);
        }

        public static void ViewSalesTaxOfAllProducts()
        {
            Console.WriteLine("Sales Tax of All Products:");
            foreach (Product product in ProductCRUD.products)
            {
                Console.WriteLine($"Product: {product.name}\t Category: {product.category}\t Sales Tax In Percentage: {product.CalculateSalesTax()}%\t Sales tax in rupees: {product.salesTax}");
            }
        }

        public static void DisplayProductsToBeOrdered()
        {
            List<Product> products = ProductCRUD.GetProductsToOrder();
            Console.WriteLine("Products to be ordered are: ");
            foreach (Product product in products)
            {
                Console.WriteLine(product.name);
            }
        }
    }
}
