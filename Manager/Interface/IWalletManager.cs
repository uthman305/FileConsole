using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Model.Entities;

namespace File_ConsoleC.Manager.Interface
{
    public interface IWalletManager
    {
        Wallet Get(int id);
        Wallet Get(string accountNumber);
        Wallet Add(Wallet wallet);
    }
}