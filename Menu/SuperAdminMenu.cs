using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Manager.Implementation;
using File_ConsoleC.Manager.Interface;
using File_ConsoleC.Model.Enum;

namespace File_ConsoleC.Menu
{
    public class SuperAdminMenu
    {
         ICMManager cMManager = new CMManager();
        public void SuperMain()
        {
            try
            {
                Console.WriteLine("welcome to SalTech\nEnter 1 to Register A company \nEnter 2 to go to Main menu");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    AccountForm();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine("wrong input");
                    Console.ResetColor();

                    SuperMain();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();

                SuperMain();
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
                Console.Write("enter your company name: ");
                string companyName = Console.ReadLine();

                var cM = cMManager.Open(fName, lName, email, password, phoneNumber, dob, (Gender)gender, pin, companyName);
                if (cM == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine("not succesful");
                    Console.ResetColor();

                }
                else
                {
                    System.Console.WriteLine($"congratulations  your account number is {cM.ManagerId}");
                    Console.WriteLine(" Do you want to continue if yes press 1 \nIf you want to log ou press 2");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        AccountForm();

                    }
                    else if (input == 2)
                    {
                        MainMenu mainMenu = new MainMenu();
                        mainMenu.Main();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("wrong input");
                        Console.ResetColor();

                        SuperMain();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();

                SuperMain();
            }

        }
    }
}