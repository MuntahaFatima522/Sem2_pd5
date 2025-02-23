using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.BL;    

namespace Task_2.DL
{
    internal class ProductCRUD
    {
        public static List<Product> products = new List<Product>();

        public static void AddProduct(Product p)
        {
            products.Add(p);
        }
        
        public static Product FindProductWithHighestUnitPrice()
        {
            Product highestPriceProduct = products[0];
            foreach (Product product in products)
            {
                if (product.price > highestPriceProduct.price)
                {
                    highestPriceProduct = product;
                }
            }
            return highestPriceProduct;
        }

       
        public static Product findByName(string name)
        {
            foreach (Product p in products)
            {
                if (p.name == name )
                {
                    return p;
                }
            }
            return null;
        }

        public static List<Product> GetProductsToOrder()
        {
            List<Product> productsToOrder = new List<Product>();
            foreach (Product product in products)
            {
                if (product.availableStockQuantity < product.minimumStockThreshold)
                {
                    productsToOrder.Add(product);
                }
            }
            return productsToOrder;
        }

        public static void readFromFile()
        {
            StreamReader f = new StreamReader("Product.txt");
            string record;
            if (File.Exists("Product.txt"))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    string category = splittedRecord[1];
                    double price= double.Parse(splittedRecord[2]);
                    int availableStockQuantity=int.Parse(splittedRecord[3]);
                    int minimumStockThreshhold=int.Parse(splittedRecord[4]);
                    Product p= new Product(name,category,price,availableStockQuantity,minimumStockThreshhold);
                    products.Add(p);

                }
                f.Close();
            }
        }
        public static void WriteDataInFile(Product updatedProduct)
        {
        string filePath = "Product.txt";
        List<string> lines = new List<string>(File.ReadAllLines(filePath));
        bool productFound = false;

        for (int i = 0; i < lines.Count; i++)
        {
            string[] data = lines[i].Split(',');
            if (data.Length >= 5 && data[0] == updatedProduct.name) 
            {
                lines[i] = $"{updatedProduct.name},{updatedProduct.category},{updatedProduct.price},{updatedProduct.availableStockQuantity},{updatedProduct.minimumStockThreshold}";
                productFound = true;
                break;
            }
        }
        if (productFound)
        {
            File.WriteAllLines(filePath, lines);
            Console.WriteLine("Product stock updated successfully!");
        }
        else
        {
            using (StreamWriter f = new StreamWriter(filePath, true))
            {
                f.WriteLine($"{updatedProduct.name},{updatedProduct.category},{updatedProduct.price},{updatedProduct.availableStockQuantity},{updatedProduct.minimumStockThreshold}");
            }
            Console.WriteLine("New product added to file!");
        }
    }

    }
}
