using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Model.Entities;
using File_ConsoleC.Model.Enum;

namespace File_ConsoleC.Manager.Interface
{
    public interface IAgentManager
    {
        Agent Open(string firstName, string lastName, string email, string password, string phoneNumber, DateOnly dob, Gender gender, int pin);
        Agent Get(string agentId);
        Agent Get(int id);
        Agent Add(Agent agent);
    }
}