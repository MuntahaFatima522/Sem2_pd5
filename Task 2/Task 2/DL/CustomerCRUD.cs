using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.BL;

namespace Task_2.DL
{
    internal class CustomerCRUD
    {
        
        public static void BuyProduct(string productName, int quantity, User user)
        {
            Product product = ProductCRUD.findByName(productName);
            if (product == null)
            {
                Console.WriteLine("Product not found.");
            }

            if (product.availableStockQuantity < quantity)
            {
                Console.WriteLine($"Insufficient stock for {productName}.");
            }
            double totalCost = product.price * quantity;
            double totalCostwithTax = totalCost + product.salesTax;
            product.availableStockQuantity -= quantity;
            ProductCRUD.WriteDataInFile(product);
            Console.WriteLine($"Product: {productName}\t Quantity: {quantity}\t Total Cost: {totalCost}\t Total Cost with Tax:{totalCostwithTax}");
            user.products.Add(product);
            user.totalCost += totalCostwithTax;
        }

        
    }
}
