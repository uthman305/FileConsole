using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Model.Entities;

namespace File_ConsoleC.Manager.Interface
{
    public interface IPurchaseManager
    {
        Purchase Make(string customerId, string accountNumber, string agentId, double amount, int pin);
        Purchase AgentMake(string agentId, string accountNumber, string managerId, double amount, int pin);
        Purchase Add(Purchase purchase);
    }
}