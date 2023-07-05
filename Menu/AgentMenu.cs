using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Manager.Implementation;
using File_ConsoleC.Manager.Interface;

namespace File_ConsoleC.Menu
{
    public class AgentMenu
    {
        IDepositManager depositManager = new DepositManager();
        IPurchaseManager purchaseManager = new PurchaseManager();
        IAgentManager agentManager = new AgentManager();
        IWalletManager walletManager = new WalletManager();



        public void AgentMain()
        {
            try
            {
                System.Console.WriteLine("enter 1 to deposit Money \nEnter 2 to make purchase \nEnter 3 to log out");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    DepositMenu();
                }
                else if (opt == 2)
                {
                    PurchaseMenu();
                }
                else if (opt == 3)
                {
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Main();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    System.Console.WriteLine("wrong input");
                    Console.ResetColor();
                    AgentMain();
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();

                AgentMain();
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

                var deposit = depositManager.AgentMake(accountNumber, accountNumber, amount, pin);
                if (deposit == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Account does not exist");
                    Console.ResetColor();

                    AgentMain();
                }
                else
                {
                    var wallet = walletManager.Get(deposit.UserId);
                    Console.WriteLine($"transaction succesful, your new balance is {wallet.MoneyBalance}");
                    Console.WriteLine(" Do you want to continue if yes press 1 if no press any number\nIf no press 2 ");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        AgentMain();
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

                        AgentMain();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                AgentMain();
            }

        }

        public void PurchaseMenu()
        {
            try
            {
                Console.Write("enter your account number: ");
                string accountNumber = Console.ReadLine();
                Console.Write("enter your buyer account number: ");
                string managerId = Console.ReadLine();
                Console.Write("enter the amount: ");
                double amount = double.Parse(Console.ReadLine());
                Console.Write("enter your pin: ");
                int pin = int.Parse(Console.ReadLine());

                var purchase = purchaseManager.AgentMake(accountNumber, accountNumber, managerId, amount, pin);
                var wallet = walletManager.Get(accountNumber);
                var rwallet = walletManager.Get(managerId);
                if (purchase == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Transaction failed due to wrong input");
                    Console.ResetColor();

                    AgentMain();
                }
                else
                {
                    var agent = agentManager.Get(purchase.UserId);
                    Console.WriteLine($"transaction succesful, your new  money balance is {wallet.MoneyBalance} and your card balance is {wallet.CardBalance}");
                    Console.WriteLine(" Do you want to continue if yes press 1 if no press any number\nIf no press 2 ");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        AgentMain();
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

                        AgentMain();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("An error occurred: " + ex.Message);
                Console.ResetColor();
                AgentMain();
            }

        }
    }
}