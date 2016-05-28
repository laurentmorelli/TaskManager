using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Manager.Perimeter
{
    interface IperimeterManager
    {
        bool TryToRegister(Perimeter perimeter);
        IperimeterManager Release(Perimeter perimeter); 
    }
}
