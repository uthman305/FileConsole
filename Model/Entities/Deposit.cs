using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_ConsoleC.Model.Entities
{
    public class Deposit : BaseEntity
    {
        public double Amount;
        public string UserId;

        public Deposit(int id, double amount, string userId) : base(id)
        {
            Amount = amount;
            UserId = userId;
        }

        public override string ToString()
        {
            return $"{Id} {Amount} {UserId}";
        }
    }
}