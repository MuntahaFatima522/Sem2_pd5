using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.BL;
using Task_2.UI;
using Task_2.DL;

namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserCRUD.readFromFile();
            ProductCRUD.readFromFile();
            while (true)
            {
                Console.Clear();
                int op = ConsoleUtility.MainMenu();
                if (op == 1)
                {
                    string name = SignInUI.TakeNameInputToSignIn();
                    string password= SignInUI.TakePasswordInputToSignIn();
                    string role=UserCRUD.checkRole(name,password);
                    User u=UserCRUD.findByNameAndPass(name,password);
                    if(role =="Admin" ||  role =="admin")
                    {
                        while(true)
                        {
                            Console.Clear();
                            AdminUI.successfulLogin();
                            int ch = AdminUI.AdminMenu();
                            if (ch == 1)
                            {
                                Product p = ProductUI.TakeInputToAddProduct();
                                ProductCRUD.AddProduct(p);
                                ProductCRUD.WriteDataInFile(p);
                                Console.ReadKey();
                            }
                            else if (ch == 2)
                            {
                                ProductUI.ViewAllProducts();
                                Console.ReadKey();

                            }
                            else if (ch == 3)
                            {
                                ProductUI.DisplayHighestPrice();
                                Console.ReadKey();

                            }
                            else if (ch == 4)
                            {
                                ProductUI.ViewSalesTaxOfAllProducts();
                                Console.ReadKey();

                            }
                            else if (ch == 5)
                            {
                                ProductUI.DisplayProductsToBeOrdered();
                                Console.ReadKey();

                            }
                            else if (ch == 6)
                            {
                                u.ViewAdminProfile();
                                Console.ReadKey();

                            }
                            else if (ch == 7)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid option.");
                                Console.ReadKey();

                            }
                        }
                        
                    }
                    else if(role=="Customer" || role=="customer")
                    {
                        while(true)
                        {
                            Console.Clear();
                            CustomerUI.successfulLogin();
                            int ch = CustomerUI.CustomerMenu();
                            if (ch == 1)
                            {
                                ProductUI.ViewAllProducts();
                                Console.ReadKey();

                            }
                            else if (ch == 2)
                            {
                                CustomerUI.BuyProducts(u);
                                Console.ReadKey();

                            }
                            else if (ch == 3)
                            {
                                CustomerUI.GenerateInvoice(u);
                                Console.ReadKey();

                            }
                            else if (ch == 4)
                            {
                                u.ViewCustomerProfile();
                                Console.ReadKey();

                            }
                            else if (ch == 5)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid option.");
                                Console.ReadKey();

                            }
                        }
                    }
                }
                else if (op == 2) 
                {
                    User u=SignUpUI.TakeSignUpInput();
                    UserCRUD.AddUser(u);
                    UserCRUD.WriteDataInFile(u);
                }
                else if(op == 3) 
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                    Console.ReadKey();

                }
            }
        }
    }
}
