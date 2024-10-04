using AttributeLib;
using DAL;
using POCO;
using System.Reflection;
using System.Security.Principal;

namespace SmallORMApp
{
    internal class Program
    {
        static List<string> createQuery()
        {
            
            Assembly assembly = Assembly.LoadFrom(@"C:\PGDAC24\.net\New folder (2)\SmallORMTool\POCO\bin\Debug\net6.0\POCO.dll");
            Type[] type = assembly.GetTypes();
            List<string> queries = new List<string>();
            foreach (Type t in type)
            {
                if (!t.FullName.ToLower().Contains("attribute"))
                {
                    string query = "";
                    IEnumerable<Attribute> tableattributes = t.GetCustomAttributes();
                    foreach (Attribute a in tableattributes)
                    {
                        if (a is Table)
                        {
                            Table table = (Table)a;
                            query = "CREATE TABLE " + table.Name + "(";
                        }
                    }
                    PropertyInfo[] properties = t.GetProperties();
                    foreach (PropertyInfo p in properties)
                    {
                        IEnumerable<Attribute> colnattributes = p.GetCustomAttributes();
                        foreach (Attribute a in colnattributes)
                        {
                            if (a is Column)
                            {
                                Column column = (Column)a;
                                query += column.Name + " " + column.Datatype + " " + column.Key + " " + column.Increment + " " + column.Linktotable + " " + column.Linktocolumn + " " + column.Deletecascade + ",";
                            }
                        }
                    }
                    query = query.TrimEnd(',');
                    query += ");";
                    queries.Add(query);
                }
            }
            return queries;
        }

        static int menu()
        {
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Create Account");
            Console.WriteLine("3. Show Accounts");
            Console.WriteLine("4. Show Users");
            Console.WriteLine("5. Delete User along with its Accounts");
            Console.WriteLine("6. Create Queries");
            Console.WriteLine("7. Login");
            return Convert.ToInt32(Console.ReadLine());
        }

        static int loggedInMenu()
        {
            Console.WriteLine("0. Logout");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            int choice;
            while ((choice = menu()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        {
                            UserDAL userDAL = new UserDAL();
                            Console.WriteLine("Enter Email :");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter password :");
                            string password = Console.ReadLine();
                            Console.WriteLine("Enter Confirm password :");
                            string Cpassword = Console.ReadLine();
                            if (password.Equals(Cpassword))
                            {
                                userDAL.registerUser(email, password);
                            }
                            else
                            {
                                Console.WriteLine("Password Mismatch");
                            }
                        }
                        break;
                    case 2:
                        {
                            AccountsDAL accountsDAL = new AccountsDAL();
                            Console.WriteLine("Enter AccountNumber :");
                            int accno = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Name :");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Email :");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter phone ");
                            int phone = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Balance :");
                            double balance = Convert.ToDouble(Console.ReadLine());
                            UserDAL accounts = new UserDAL();
                            int a = accounts.SearchUser(email);
                            if (a == 0)
                                Console.WriteLine("User not found");
                            else
                                accountsDAL.registerAccount(accno, name, email, phone, balance, a);
                        }
                        break;
                    case 3:
                        {
                            AccountsDAL accountDAL = new AccountsDAL();
                            List<Account> list = accountDAL.displayAccounts();
                            if (list.Count == 0)
                                Console.WriteLine("No Accounts Found !!!");
                            else
                                foreach (Account account in list)
                                {
                                    Console.WriteLine(account);
                                }
                        }
                        break;
                    case 4:
                        {
                            UserDAL userDAL = new UserDAL();
                            List<User> list = userDAL.displayUsers();
                            if (list.Count == 0)
                                Console.WriteLine("No Users Found !!!");
                            else
                                foreach (User account in list)
                                {
                                    Console.WriteLine(account);
                                }
                        }
                        break;
                    case 5:
                        {
                            UserDAL accountDAL = new UserDAL();
                            Console.WriteLine("Enter EmailID :");
                            string email = Console.ReadLine();
                            accountDAL.deleteUser(email);
                        }
                        break;
                    case 6:
                        {
                            List<string> queries = createQuery();
                            foreach (string query in queries)
                            {
                                Console.WriteLine(query);
                            }
                        }
                        break;
                    case 7:
                        {
                            UserDAL userDAL = new UserDAL();
                            Console.WriteLine("Enter Email :");
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter password :");
                            string password = Console.ReadLine();
                            string s = userDAL.loginUser(email, password);
                            if (s.StartsWith("Welcome"))
                            {
                                Console.WriteLine(s);
                                AccountsDAL accountsDAL = new AccountsDAL();
                                int loggedInChoice;
                                while ((loggedInChoice = loggedInMenu()) != 0)
                                {
                                    switch (loggedInChoice)
                                    {
                                        case 1:
                                            {
                                                Console.WriteLine("Enter Account Number:");
                                                int accNo = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Enter amount to deposit:");
                                                double amount = Convert.ToDouble(Console.ReadLine());
                                                accountsDAL.Deposit(accNo, amount);
                                                Console.WriteLine("Deposit successful.");
                                            }
                                            break;
                                        case 2:
                                            {
                                                Console.WriteLine("Enter Account Number:");
                                                int accNo = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Enter amount to withdraw:");
                                                double amount = Convert.ToDouble(Console.ReadLine());

                                                bool result = accountsDAL.Withdraw(accNo, amount);

                                                if (result)
                                                    Console.WriteLine("Withdrawal successful.");
                                                else
                                                    Console.WriteLine("Withdrawal failed.");
                                            }
                                            break;

                                    }
                                }
                                Console.WriteLine("Logged out.");
                            }
                            else
                            {
                                Console.WriteLine("Login Failed.");
                            }
                        }
                        break;
                }
            }
        }
    }
}
