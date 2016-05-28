using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TaskManager.Manager.Task
{
    class Task : Watcher
    {
        private Perimeter.Perimeter _innerPerimeter;

        public Perimeter.Perimeter Perimeter { get { return this._innerPerimeter; } }

        public Task(TaskManager observer, Perimeter.Perimeter perimeter) : base(observer)
        {
            this._innerPerimeter = perimeter;
        }
    }
}
