using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Manager
{
    internal abstract class Watcher : IDisposable, IObservable
    {
        /// <summary>
        /// global observer
        /// </summary>
        private IObserver _innerParent;

        /// <summary>
        /// We don't know yet who creates the watcher
        /// </summary>
        /// <param name="watcherobs"></param>
        public Watcher(IObserver watcherobs)
        {
            this._innerParent = watcherobs.Observe(this);
        }

        /// <summary>
        /// IDisposable Implement
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //stop observation
                _innerParent.StopWatching(this);
            }
        }
    }
}
