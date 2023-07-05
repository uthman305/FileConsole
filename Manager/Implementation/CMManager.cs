using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Manager.Interface;
using File_ConsoleC.Model.Entities;
using File_ConsoleC.Model.Enum;

namespace File_ConsoleC.Manager.Implementation
{
    public class CMManager : ICMManager
    {
        private string Path = @"C:\Users\Uthman\Desktop\File-ConsoleC\Files\cm.txt";
        public static List<CM> CMDb = new List<CM>();

        public CM Get(string managerId)
        {
            foreach (var cM in CMDb)
            {
                if (cM.ManagerId == managerId)
                {
                    return cM;
                }
            }
            return null;
        }

        public CM Get(int id)
        {
            foreach (var cM in CMDb)
            {
                if (cM.Id == id)
                {
                    return cM;
                }
            }
            return null;
        }

        public CM Open(string firstName, string lastName, string email, string password, string phoneNumber, DateOnly dob, Gender gender, int pin, string companyName)
        {
            User user = new User(UserManager.UserDb.Count + 1, firstName, lastName, email, password, phoneNumber, dob, gender, "Manager");
            var userManager = new UserManager().Add(user);

            Wallet wallet = new Wallet(WalletManager.WalletDb.Count + 1, firstName, 0, 0, GenerateCMId(phoneNumber), pin);
            var walletManager = new WalletManager().Add(wallet);

            Company company = new Company(CompanyManager.CompanyDb.Count + 1, companyName, WalletManager.WalletDb.Count + 1);
            var companyManager = new CompanyManager().Add(company);


            CM cM = new CM(CMDb.Count + 1, GenerateCMId(phoneNumber), UserManager.UserDb.Count );
            var cmManager = new CMManager().Add(cM);
            return cM;
        }
        public string GenerateCMId(string phoneNumber)
        {
            string walletId = "";
            walletId = phoneNumber.Substring(1, 10);
            return walletId;
        }
        public CM Add(CM cM)
        {
            using (var streamWriter = new StreamWriter(Path, true))
            {
                streamWriter.WriteLine(cM.ToString());
            }
            CMDb.Add(cM);
            return cM;
        }
        public void LoadDataFromFile()
        {
            var data = File.ReadAllLines(Path);
            foreach (var item in data)
            {
                CMDb.Add(ConvertToCMObject(item));

            }
        }
        private CM ConvertToCMObject(string data)
        {
            var newData = data.Split(' ');
            return new CM(int.Parse(newData[0]), newData[1], (int.Parse(newData[2])));

        }
        public void UpdateDataInFile()
        {
            // Clear the contents of the file
            File.WriteAllText(Path, "");

            // Write each customer to the file
            foreach (var cM in CMDb)
            {
                using (var streamWriter = new StreamWriter(Path, true))
                {
                    streamWriter.WriteLine(cM.ToString());
                }
            }
        }

    }
}