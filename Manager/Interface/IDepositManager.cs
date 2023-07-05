using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Model.Entities;

namespace File_ConsoleC.Manager.Interface
{
    public interface IDepositManager
    {
        Deposit Make(string customerId, string accountNumber, double amount, int pin);
        Deposit AgentMake(string agentId, string accountNumber, double amount, int pin);
        Deposit ManagerMake(string managerId, string accountNumber, double amount, int pin);
        Deposit Add(Deposit deposit);
    }
}