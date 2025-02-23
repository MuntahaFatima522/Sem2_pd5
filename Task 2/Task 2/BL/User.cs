using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.BL
{
    internal class User
    {
        public string name;
        public string password;
        public string role;
        public string email;
        public string address;
        public string contact;
        public List<Product> products;
        public double totalCost;
        
        public User(string name, string password, string role,string email,string address,string contact)
        {
            this.name = name;  
            this.password = password;
            this.role = role;
            this.email = email;
            this.address = address;
            this.contact = contact;
            products = new List<Product>();
            totalCost = 0;
        }

        public void ViewAdminProfile()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Password: " + password);
        }

        public void ViewCustomerProfile()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Password: " + password);
            Console.WriteLine("Email: " + email);
            Console.WriteLine("Address: " + address);
            Console.WriteLine("Contact: " + contact);
        }
    }
}
