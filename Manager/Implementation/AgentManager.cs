using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using File_ConsoleC.Manager.Interface;
using File_ConsoleC.Model.Entities;
using File_ConsoleC.Model.Enum;

namespace File_ConsoleC.Manager.Implementation
{
    public class AgentManager : IAgentManager
    {
        private string Path = @"C:\Users\Uthman\Desktop\File-ConsoleC\Files\agent.txt";
        public static List<Agent> AgentDb = new List<Agent>();
        public Agent Get(string agentId)
        {
            foreach (var agent in AgentDb)
            {
                if (agent.AgentId == agentId)
                {
                    return agent;
                }
            }
            return null;
        }

        public Agent Get(int id)
        {
            foreach (var agent in AgentDb)
            {
                if (agent.Id == id)
                {
                    return agent;
                }
            }
            return null;
        }

        public Agent Open(string firstName, string lastName, string email, string password, string phoneNumber, DateOnly dob, Gender gender, int pin)
        {
            User user = new User(UserManager.UserDb.Count + 1, firstName, lastName, email, password, phoneNumber, dob, gender, "Agent");
            var userManager = new UserManager().Add(user);

            Wallet wallet = new Wallet(WalletManager.WalletDb.Count + 1, firstName, 0, 0, GenerateAgentId(phoneNumber), pin);
            var walletManager = new WalletManager().Add(wallet);


            Agent agent = new Agent(AgentDb.Count + 1, GenerateAgentId(phoneNumber), WalletManager.WalletDb.Count, UserManager.UserDb.Count);
            var agentManager = new AgentManager().Add(agent);
            return agent;
        }
        public string GenerateAgentId(string phoneNumber)
        {
            string walletId = "";
            walletId = phoneNumber.Substring(1, 10);
            return walletId;
        }

        public Agent Add(Agent agent)
        {
            using (var streamWriter = new StreamWriter(Path, true))
            {
                streamWriter.WriteLine(agent.ToString());
            }
            AgentDb.Add(agent);
            return agent;
        }

        public void LoadDataFromFile()
        {
            var data = File.ReadAllLines(Path);
            foreach (var item in data)
            {
                AgentDb.Add(ConvertToAgentObject(item));

            }
        }
        private Agent ConvertToAgentObject(string data)
        {
            var newData = data.Split(' ');
            return new Agent(int.Parse(newData[0]), newData[1], (int.Parse(newData[2])), (int.Parse(newData[3])));

        }
        public void UpdateDataInFile()
        {
            // Clear the contents of the file
            File.WriteAllText(Path, "");

            foreach (var agent in AgentDb)
            {
                using (var streamWriter = new StreamWriter(Path, true))
                {
                    streamWriter.WriteLine(agent.ToString());
                }
            }
        }
    }
}