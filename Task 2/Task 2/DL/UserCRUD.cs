using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_2.BL;

namespace Task_2.DL
{
    internal class UserCRUD
    {
        static List<User> users= new List<User>();
        public static string checkRole(string name,string pass)
        {
            foreach (User u in users)
            {
                if (u.name == name && pass == u.password)
                {
                    return u.role;
                }
            }
            return null;
        }
        public static User findByNameAndPass(string name,string pass)
        {
            foreach (User u in users)
            {
                if (u.name == name && pass == u.password)
                {
                    return u;
                }
            }
            return null;
        }
        public static void AddUser(User u)
        {
            users.Add(u);
        }

        public static void readFromFile()
        {
            StreamReader f = new StreamReader("User.txt");
            string record;
            if (File.Exists("User.txt"))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    string password = splittedRecord[1];
                    string role = splittedRecord[2];
                    string email= splittedRecord[3];
                    string address= splittedRecord[4];
                    string contact= splittedRecord[5];
                    User u=new User(name,password,role,email,address,contact);
                    users.Add(u);
                }
                f.Close();
            }
        }

        public static void WriteDataInFile(User u)
        {
            using (StreamWriter f = new StreamWriter("User.txt", true))
            {
                f.WriteLine();
                f.Write($"{u.name},{u.password},{u.role},{u.email},{u.address},{u.contact}");
            }
        }
    }
}
