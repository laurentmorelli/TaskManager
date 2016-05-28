using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Manager.Perimeter
{
    class PerimeterManager : IperimeterManager
    {
        private IList<Perimeter> _innerPerimeter = new List<Perimeter>();
        
        private object lockerwrite = new object();

        public bool TryToRegister(Perimeter perimeter)
        {
            bool addedyet = false;
            
            lock (lockerwrite)
            {
                if (IsAvailable(perimeter))
                {
                    _innerPerimeter.Add(perimeter);
                    addedyet = true;
                }
            }

            return addedyet;
        }

        public IperimeterManager Release(Perimeter perimeter)
        {
            // for the moment we don't give a shit we take anything
            lock (this.lockerwrite)
            {
                if (_innerPerimeter.Contains(perimeter))
                    _innerPerimeter.Remove(perimeter);
            }

            return this;
        }

        private bool IsAvailable(Perimeter perimeter)
        {
            // to be called in a lock otherwise it's shitty shitty tell me why

            // TODO this sucks algowise, to be refacto later
            foreach (Perimeter innerPerimeter in _innerPerimeter)
                foreach (string currentKey in perimeter.Keys)
                    foreach (string key in innerPerimeter.Keys)
                        if (key == currentKey)
                            return false;

            return true;
        }

    }
}
