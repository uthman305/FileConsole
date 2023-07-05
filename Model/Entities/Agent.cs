using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_ConsoleC.Model.Entities
{
    public class Agent : BaseEntity
    {
        public string AgentId;
        public int WalletId;
        public int UserId;

        public Agent(int id, string agentId, int walletId, int userId) : base(id)
        {
            AgentId = agentId;
            WalletId = walletId;
            UserId = userId;
        }
        public override string ToString()
        {
            return $"{Id} {AgentId} {WalletId} {UserId}  ";
        }
    }

}