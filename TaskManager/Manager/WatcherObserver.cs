using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Manager
{
    internal abstract class WatcherObserver<WATCHER> : IObserver where WATCHER : IObservable 
    {
        /// <summary>
        /// inner watchers
        /// </summary>
        private IList<IObservable> innerWatchers;

        private object innerLock;
        
        /// <summary>
        /// Observe
        /// </summary>
        /// <returns></returns>
        public IObserver Observe(IObservable watch)
        {
            lock (innerLock)
            {
                innerWatchers.Add(watch);
            }
            return this;
        }

        /// <summary>
        /// release the watch
        /// </summary>
        /// <param name="watch"></param>
        public IObserver StopWatching(IObservable watch)
        {
            lock (innerLock)
            {
                if (!innerWatchers.Contains(watch))
                    throw new MissingWatcherException(watch);
                innerWatchers.Remove(watch);
            }
            return this;
        }

        #region Exception

        /// <summary>
        /// multithreaded issue
        /// </summary>
        [Serializable]
        class MissingWatcherException : SystemException
        {
            public MissingWatcherException(IObservable watch) : base(string.Format("Missing Watcher : {0}", watch.ToString()))
            {
            }
        }
        #endregion
    }
}