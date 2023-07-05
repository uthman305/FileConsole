using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Manager.Interface;
using File_ConsoleC.Model.Entities;

namespace File_ConsoleC.Manager.Implementation
{
    public class WalletManager : IWalletManager
    {
        private string Path = @"C:\Users\Uthman\Desktop\File-ConsoleC\Files\wallet.txt";
        public static List<Wallet> WalletDb = new List<Wallet>();
        public Wallet Get(int id)
        {
            foreach (var wallet in WalletDb)
            {
                if (wallet.Id == id)
                {
                    return wallet;
                }
            }
            return null;
        }

        public Wallet Get(string accountNumber)
        {
            foreach (var wallet in WalletDb)
            {
                if (wallet.AccountNumber == accountNumber)
                {
                    return wallet;
                }
            }
            return null;
        }
        public Wallet Add(Wallet wallet)
        {
            using (var streamWriter = new StreamWriter(Path, true))
            {
                streamWriter.WriteLine(wallet.ToString());
            }
            WalletDb.Add(wallet);
            return wallet;
        }
        public void LoadDataFromFile()
        {
            var data = File.ReadAllLines(Path);
            foreach (var item in data)
            {
                WalletDb.Add(ConvertToWalletObject(item));

            }
        }
        private Wallet ConvertToWalletObject(string data)
        {
            var newData = data.Split(' ');
            return new Wallet(int.Parse(newData[0]), newData[1], (double.Parse(newData[2])), (double.Parse(newData[3])), newData[4], int.Parse(newData[5]));

        }
        public void UpdateDataInFile()
        {
            // Clear the contents of the file
            File.WriteAllText(Path, "");

            // Write each customer to the file
            foreach (var wallet in WalletDb)
            {
                using (var streamWriter = new StreamWriter(Path, true))
                {
                    streamWriter.WriteLine(wallet.ToString());
                }
            }
        }
    }
}