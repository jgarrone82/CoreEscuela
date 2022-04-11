using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entities
{
    public interface IPlace
    {
        string Address { get; set; }

        void CleanPlace();
    }
}