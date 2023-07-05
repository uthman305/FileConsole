using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_ConsoleC.Model.Entities
{
    public class BaseEntity
    {
        public int Id;

        public BaseEntity(int id)
        {
            Id = id;
        }
    }
}