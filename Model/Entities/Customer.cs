using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_ConsoleC.Model.Entities
{
    public class Customer : BaseEntity
    {
        public string CustomerId;
        public int WalletId;
        public int UserId;


        public Customer(int id, string customerId, int walletId, int userId) : base(id)
        {
            CustomerId = customerId;
            WalletId = walletId;
            UserId = userId;
        }
        public override string ToString()
        {
            return $"{Id} {CustomerId} {WalletId} {UserId}  ";
        }
    }
}