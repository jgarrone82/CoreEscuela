using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entities
{
    public abstract class BaseSchoolObj
    {
        public string UniqueId { get; private set; }
        public string Name { get; set; }

        public BaseSchoolObj()
        {
            UniqueId = Guid.NewGuid().ToString();
            Name = "";
        }

        public override string ToString()
        {
            return $"{Name} , {UniqueId}";
        }
    }
}