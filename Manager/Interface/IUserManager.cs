using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Model.Entities;

namespace File_ConsoleC.Manager.Interface
{
    public interface IUserManager
    {
        User Get(string email);
        User Login(string email, string password);
        User Add(User user);
    }
}