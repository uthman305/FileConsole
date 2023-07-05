using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Model.Entities;
using File_ConsoleC.Model.Enum;

namespace File_ConsoleC.Manager.Interface
{
    public interface ICMManager
    {
        CM Open(string firstName, string lastName, string email, string password, string phoneNumber, DateOnly dob, Gender gender, int pin, string companyName);

        CM Get(string managerId);
        CM Get(int id);
        CM Add(CM cM);
    }
}