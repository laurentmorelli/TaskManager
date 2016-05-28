using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Manager.Perimeter;

namespace TaskManager.Manager.Task
{
    class TaskManager : WatcherObserver<Task>
    {
        private PerimeterManager _innerPerimeterManager;

        public TaskManager(PerimeterManager perimeterManager)
        {
            _innerPerimeterManager = perimeterManager;
        }
    }
}
