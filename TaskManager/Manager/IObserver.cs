using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Manager
{
    internal interface IObserver
    {
        IObserver Observe(IObservable watch);

        IObserver StopWatching(IObservable watch);
    }
}
