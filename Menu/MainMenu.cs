using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Manager.Implementation;
using File_ConsoleC.Manager.Interface;
using File_ConsoleC.Model.Enum;

namespace File_ConsoleC.Menu
{
    public class MainMenu
    {
        ICustomerManager customerManager = new CustomerManager();
        IUserManager userManager = new UserManager();
        CustomerMenu customerMenu = new CustomerMenu();
        AgentMenu agentMenu = new AgentMenu();
        CompanyMenu companyMenu = new CompanyMenu();

        SuperAdminMenu superAdminMenu = new SuperAdminMenu();

        public void Main()
        {
            try
            {
                Console.WriteLine("welcome to SalTech\nEnter 1 to Register\nEnter 2 to login\nEnter 3 to log out");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    AccountForm();
                }
                else if (option == 2)
                {
                    LoginForm();
                }
                else if (option == 3)
                {
                    
                }
                else
                {
                    System.Console.WriteLine("wrong input");
                    Main();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                Main();
            }
        }

        public void AccountForm()
        {
            try
            {
                Console.Write("enter your first name: ");
                string fName = Console.ReadLine();
                Console.Write("enter your last name: ");
                string lName = Console.ReadLine();
                Console.Write("enter your email address: ");
                string email = Console.ReadLine();
                Console.Write("enter your password: ");
                string password = Console.ReadLine();
                Console.Write("enter your phone number: ");
                string phoneNumber = Console.ReadLine();
                Console.Write("enter your date of birth: ");
                DateOnly dob = DateOnly.Parse(Console.ReadLine());
                Console.Write("enter 1 for male and 2 for female: ");
                int gender = int.Parse(Console.ReadLine());
                Console.Write("enter your pin: ");
                int pin = int.Parse(Console.ReadLine());

                var customer = customerManager.Open(fName, lName, email, password, phoneNumber, dob, (Gender)gender, pin);
                if (customer == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine("not succesful");
                    Console.ResetColor();

                }
                else
                {
                    System.Console.WriteLine($"congratulations  your account number is {customer.CustomerId}");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                Main();
            }
            Main();





        }

        public void LoginForm()
        {
            try
            {
                Console.Write("enter your email address: ");
                string email = Console.ReadLine();
                Console.Write("enter your password: ");
                string password = Console.ReadLine();

                var user = userManager.Login(email, password);
                if (user == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("wrong cridentials");
                    Console.ResetColor();

                    LoginForm();
                }
                else
                {

                    if (user.Role == "Customer")
                    {
                        customerMenu.CustomerMain();
                    }
                    else if (user.Role == "Agent")
                    {
                        agentMenu.AgentMain();
                    }
                    else if (user.Role == "Manager")
                    {
                        companyMenu.CompanyMain();
                    }
                    else if (user.Role == "SuperAdmin")
                    {
                        superAdminMenu.SuperMain();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                Main();
            }
        }
    }
}