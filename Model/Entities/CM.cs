using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_ConsoleC.Model.Entities
{
    public class CM : BaseEntity

    {
        public string ManagerId;
        public int UserId;

        public CM(int id, string managerId, int userId) : base(id)
        {
            ManagerId = managerId;
            UserId = userId;
        }
        public override string ToString()
        {
            return $"{Id} {ManagerId} {UserId}  ";
        }
    }
}