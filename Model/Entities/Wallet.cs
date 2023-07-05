using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_ConsoleC.Model.Entities
{
    public class Wallet : BaseEntity
    {

        public string Name;
        public double MoneyBalance;
        public double CardBalance;
        public string AccountNumber;
        public int Pin;

        public Wallet(int id, string name, double moneyBalance, double cardBalance, string accountNumber, int pin) : base(id)
        {
            Name = name;
            MoneyBalance = moneyBalance;
            CardBalance = cardBalance;
            AccountNumber = accountNumber;
            Pin = pin;
        }
        public override string ToString()
        {
            return $"{Id} {Name} {MoneyBalance} {CardBalance} {AccountNumber} {Pin}  ";
        }
    }
}