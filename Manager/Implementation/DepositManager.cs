using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Manager.Interface;
using File_ConsoleC.Model.Entities;

namespace File_ConsoleC.Manager.Implementation
{
    public class DepositManager : IDepositManager
    {
        private static string Path = @"C:\Users\Uthman\Desktop\File-ConsoleC\Files\deposit.txt";
        public static List<Deposit> DepositDb = new List<Deposit>();

        ICustomerManager customerManager = new CustomerManager();
        IAgentManager agentManager = new AgentManager();
        IUserManager userManager = new UserManager();
        ICMManager cMManager = new CMManager();
        IWalletManager walletManager = new WalletManager();

        public Deposit AgentMake(string agentId, string accountNumber, double amount, int pin)
        {
            var agent = agentManager.Get(agentId);
            var wallet = walletManager.Get(accountNumber);
            if (agent == null)
            {

                return null;
            }
            else
            {
                if (wallet.Pin == pin)
                {
                    if (amount > 0)
                    {
                        wallet.MoneyBalance += amount;
                        Deposit deposit = new Deposit(DepositDb.Count + 1, amount, agentId);

                        // update file
                        var walletManager = new WalletManager();
                        walletManager.UpdateDataInFile();

                        // var depositManager = new DepositManager().Add(deposit);
                       Add(deposit);
                        return deposit;
                    }
                    else

                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public Deposit Make(string customerId, string accountNumber, double amount, int pin)
        {
            var customer = customerManager.Get(customerId);
            var wallet = walletManager.Get(accountNumber);
            if (customer == null)
            {
                return null;
            }
            else
            {
                if (wallet.Pin == pin)
                {
                    // specify the error
                    if (amount > 0)
                    {
                        wallet.MoneyBalance += amount;
                        Deposit deposit = new Deposit(DepositDb.Count + 1, amount, customerId);

                        // update file
                        var walletManager = new WalletManager();
                        walletManager.UpdateDataInFile();

                        // var depositManager = new DepositManager().Add(deposit);
                        Add(deposit);
                        return deposit;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        public Deposit ManagerMake(string managerId, string accountNumber, double amount, int pin)
        {
            var cm = cMManager.Get(managerId);
            var wallet = walletManager.Get(accountNumber);
            if (cm == null)
            {

                return null;
            }
            else
            {
                if (wallet.Pin == pin)
                {
                    if (amount > 0)
                    {
                        wallet.CardBalance += amount;
                        Deposit deposit = new Deposit(DepositDb.Count + 1, amount, managerId);
                        // update file
                        var walletManager = new WalletManager();
                        walletManager.UpdateDataInFile();
                        // var depositManager = new DepositManager().Add(deposit);
                        Add(deposit);
                        return deposit;
                    }
                    else

                    {

                        return null;
                    }
                }
                else
                {

                    return null;
                }
            }
        }
        public  Deposit Add(Deposit deposit)
        {
            using (var streamWriter = new StreamWriter(Path, true))
            {
                streamWriter.WriteLine(deposit.ToString());
            }
            DepositDb.Add(deposit);
            return deposit;
        }
        public void LoadDataFromFile()
        {
            var data = File.ReadAllLines(Path);
            foreach (var item in data)
            {
                DepositDb.Add(ConvertToDepositObject(item));

            }
        }
        private Deposit ConvertToDepositObject(string data)
        {
            var newData = data.Split(' ');
            return new Deposit(int.Parse(newData[0]), (double.Parse(newData[1])), (newData[2]));

        }
        public void UpdateDataInFile()
        {
            // Clear the contents of the file
            File.WriteAllText(Path, "");

            // Write each customer to the file
            foreach (var deposit in DepositDb)
            {
                using (var streamWriter = new StreamWriter(Path, true))
                {
                    streamWriter.WriteLine(deposit.ToString());
                }
            }
        }
    }
}