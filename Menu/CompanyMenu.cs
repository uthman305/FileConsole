using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Manager.Implementation;
using File_ConsoleC.Manager.Interface;
using File_ConsoleC.Model.Enum;

namespace File_ConsoleC.Menu
{
    public class CompanyMenu
    {
        IDepositManager depositManager = new DepositManager();
        IWalletManager walletManager = new WalletManager();
        IAgentManager agentManager = new AgentManager();

        public void CompanyMain()
        {
            try
            {
                System.Console.WriteLine("enter 1 to deposit Card \nEnter 2 to register an agent\nenter 3 to go back to Log out");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    DepositMenu();
                }
                else if (opt == 2)
                {
                    AccountForm();
                }
                else if (opt == 3)
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Main();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                CompanyMain();
            }
        }

        public void DepositMenu()
        {
            try
            {
                Console.Write("enter your account number: ");
                string accountNumber = Console.ReadLine();
                Console.Write("enter the amount: ");
                double amount = double.Parse(Console.ReadLine());
                Console.Write("enter your pin: ");
                int pin = int.Parse(Console.ReadLine());

                var deposit = depositManager.ManagerMake(accountNumber, accountNumber, amount, pin);
                if (deposit == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Account does not exist");
                    Console.ResetColor();

                    CompanyMain();
                }
                else
                {
                    var wallet = walletManager.Get(deposit.UserId);
                    Console.WriteLine($"transaction succesful");

                    Console.WriteLine(" Do you want to continue if yes press 1 \nIf no press 2 ");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        CompanyMain();
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

                        CompanyMain();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                CompanyMain();
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

                var agent = agentManager.Open(fName, lName, email, password, phoneNumber, dob, (Gender)gender, pin);
                if (agent == null)
                {
                    System.Console.WriteLine("not succesful");
                }
                else
                {
                    System.Console.WriteLine($"congratulations  your account number is {agent.AgentId}");
                    Console.WriteLine(" Do you want to continue if yes press 1 if no press any number\nIf no press 2 ");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        CompanyMain();
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

                        CompanyMain();
                    }

                }

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                CompanyMain();
            }
        }
    }
}