using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_ConsoleC.Model.Entities
{
    public class Company : BaseEntity
    {
        public string CompanyName;
        public int WalletId;

        public Company(int id, string companyName, int walletId) : base(id)
        {
            CompanyName = companyName;
            WalletId = walletId;
        }

        public override string ToString()
        {
            return $"{Id} {CompanyName} {WalletId} ";
        }
    }
}