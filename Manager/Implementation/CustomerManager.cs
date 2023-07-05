using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Manager.Interface;
using File_ConsoleC.Model.Entities;
using File_ConsoleC.Model.Enum;

namespace File_ConsoleC.Manager.Implementation
{
    public class CustomerManager : ICustomerManager
    {
        private string Path = @"C:\Users\Uthman\Desktop\File-ConsoleC\Files\customer.txt";
        public static List<Customer> CustomerDb = new List<Customer>();
        public Customer Get(string customerId)
        {
            foreach (var customer in CustomerDb)
            {
                if (customer.CustomerId == customerId)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer Get(int id)
        {
            foreach (var customer in CustomerDb)
            {
                if (customer.Id == id)
                {
                    return customer;
                }
            }
            return null;
        }

        public Customer Open(string firstName, string lastName, string email, string password, string phoneNumber, DateOnly dob, Gender gender, int pin)
        {
            User user = new User(UserManager.UserDb.Count + 1, firstName, lastName, email, password, phoneNumber, dob, gender, "Customer");
            var userManager = new UserManager().Add(user);

            Wallet wallet = new Wallet(WalletManager.WalletDb.Count + 1, firstName, 0, 0, GenerateCustomerId(phoneNumber), pin);
            var walletManager = new WalletManager().Add(wallet);


            Customer customer = new Customer(CustomerDb.Count + 1, GenerateCustomerId(phoneNumber), WalletManager.WalletDb.Count + 1, UserManager.UserDb.Count );
            var customerManager = new CustomerManager().Add(customer);
            return customer;
        }

        public string GenerateCustomerId(string phoneNumber)
        {
            string walletId = "";
            walletId = phoneNumber.Substring(1, 10);
            return walletId;
        }

        public Customer Add(Customer customer)
        {
            using (var streamWriter = new StreamWriter(Path, true))
            {
                streamWriter.WriteLine(customer.ToString());
            }
            CustomerDb.Add(customer);
            return customer;
        }
        public void LoadDataFromFile()
        {
            var data = File.ReadAllLines(Path);
            foreach (var item in data)
            {
                CustomerDb.Add(ConvertToCustomerObject(item));

            }
        }
        private Customer ConvertToCustomerObject(string data)
        {
            var newData = data.Split(' ');
            return new Customer(int.Parse(newData[0]), newData[1], (int.Parse(newData[2])), (int.Parse(newData[3])));

        }
        public void UpdateDataInFile()
        {
            // Clear the contents of the file
            File.WriteAllText(Path, "");

            // Write each customer to the file
            foreach (var customer in CustomerDb)
            {
                using (var streamWriter = new StreamWriter(Path, true))
                {
                    streamWriter.WriteLine(customer.ToString());
                }
            }
        }


    }
}