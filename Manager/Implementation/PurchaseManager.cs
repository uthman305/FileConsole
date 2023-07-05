using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Manager.Interface;
using File_ConsoleC.Model.Entities;

namespace File_ConsoleC.Manager.Implementation
{
    public class PurchaseManager : IPurchaseManager
    {
        private string Path = @"C:\Users\Uthman\Desktop\File-ConsoleC\Files\purchase.txt";
        public static List<Purchase> PurchaseDb = new List<Purchase>();

        IAgentManager agentManager = new AgentManager();
        ICustomerManager customerManager = new CustomerManager();
        IWalletManager walletManager = new WalletManager();
        ICMManager cMManager = new CMManager();
        public Purchase AgentMake(string agentId, string accountNumber, string managerId, double amount, int pin)
        {
            var agent = agentManager.Get(agentId);
            var manager = cMManager.Get(managerId);
            var rwallet = walletManager.Get(managerId);
            var wallet = walletManager.Get(accountNumber);
            if (agent == null)
            {
                System.Console.WriteLine("account not found");
                return null;
            }
            else
            {
                if (wallet.Pin == pin)
                {
                    if (amount > 0)
                    {
                        if (wallet.MoneyBalance > amount && rwallet.CardBalance > amount)
                        {
                            wallet.CardBalance += amount;
                            rwallet.CardBalance -= amount;
                            wallet.MoneyBalance -= amount;
                            rwallet.MoneyBalance += amount;
                            Purchase purchase = new Purchase(PurchaseDb.Count + 1, amount, agentId);
                            System.Console.WriteLine("succesful");
                            // update file
                            var walletManager = new WalletManager();
                            walletManager.UpdateDataInFile();
                            var purchaseManager = new PurchaseManager().Add(purchase);
                            return purchase;
                        }
                        else
                        {
                            System.Console.WriteLine("Insufficient found");
                            return null;
                        }

                    }
                    else

                    {
                        System.Console.WriteLine("amount must be greater than zero");
                        return null;
                    }
                }
                else
                {
                    System.Console.WriteLine("invalid pin");
                    return null;
                }
            }
        }


        public Purchase Make(string customerId, string accountNumber, string agentId, double amount, int pin)
        {
            var customer = customerManager.Get(customerId);
            var agent = agentManager.Get(agentId);
            var rwallet = walletManager.Get(agentId);
            var wallet = walletManager.Get(accountNumber);
            if (customer == null)
            {
                System.Console.WriteLine("account not found");
                return null;
            }
            else
            {
                if (wallet.Pin == pin)
                {
                    if (amount > 0)
                    {
                        if (wallet.MoneyBalance > amount && rwallet.CardBalance > amount)
                        {
                            wallet.CardBalance += amount;
                            rwallet.CardBalance -= amount;
                            wallet.MoneyBalance -= amount;
                            rwallet.MoneyBalance += amount;
                            Purchase purchase = new Purchase(PurchaseDb.Count + 1, amount, customerId);
                            System.Console.WriteLine("succesful");
                            // update file
                            var walletManager = new WalletManager();
                            walletManager.UpdateDataInFile();
                            var purchaseManager = new PurchaseManager().Add(purchase);
                            return purchase;
                        }
                        else
                        {
                            System.Console.WriteLine("Insufficient found");
                            return null;
                        }

                    }
                    else

                    {
                        System.Console.WriteLine("amount must be greater than zero");
                        return null;
                    }
                }
                else
                {
                    System.Console.WriteLine("invalid pin");
                    return null;
                }
            }
        }

        public Purchase Add(Purchase purchase)
        {
            using (var streamWriter = new StreamWriter(Path, true))
            {
                streamWriter.WriteLine(purchase.ToString());
            }
            PurchaseDb.Add(purchase);
            return purchase;
        }
        public void LoadDataFromFile()
        {
            var data = File.ReadAllLines(Path);
            foreach (var item in data)
            {
                PurchaseDb.Add(ConvertToPurchaseObject(item));

            }
        }
        private Purchase ConvertToPurchaseObject(string data)
        {
            var newData = data.Split(' ');
            return new Purchase(int.Parse(newData[0]), (double.Parse(newData[1])), (newData[2]));

        }
        public void UpdateDataInFile()
        {
            // Clear the contents of the file
            File.WriteAllText(Path, "");

            // Write each customer to the file
            foreach (var purchase in PurchaseDb)
            {
                using (var streamWriter = new StreamWriter(Path, true))
                {
                    streamWriter.WriteLine(purchase.ToString());
                }
            }
        }
    }
}