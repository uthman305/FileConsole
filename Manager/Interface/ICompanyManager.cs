using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Model.Entities;

namespace File_ConsoleC.Manager.Interface
{
    public interface ICompanyManager
    {
        Company Get(string name);
        Company Get(int id);
        Company Add(Company company);
    }
}