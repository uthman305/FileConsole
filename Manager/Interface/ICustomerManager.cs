using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Model.Entities;
using File_ConsoleC.Model.Enum;

namespace File_ConsoleC.Manager.Interface
{
    public interface ICustomerManager
    {
        Customer Open(string firstName, string lastName, string email, string password, string phoneNumber, DateOnly dob, Gender gender, int pin);
        Customer Get(string customerId);
        Customer Get(int id);
        Customer Add(Customer customer); 
    }
}