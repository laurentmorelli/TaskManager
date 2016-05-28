using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Manager.Perimeter
{
    class Perimeter
    {
        private readonly IList<string> innerKeys;
        private const char SEPARATOR = '.'; 

        public IList<string> Keys { get { return innerKeys; } }

        public Perimeter(string requestedPerimeter)
        {
            //check for technical reject
            if (string.IsNullOrWhiteSpace(requestedPerimeter))
                throw new EmptyPerimeterException();

            //we're good
            innerKeys = new List<string>();

            string[] splitted = requestedPerimeter.Split(SEPARATOR);
            string currentkey = splitted[0];

            innerKeys.Add(currentkey);
            for (int i = 1; i < splitted.Length; i++)
                innerKeys.Add(currentkey += SEPARATOR+ splitted[i]);
            
        }

        #region Exception

        /// <summary>
        /// multithreaded issue
        /// </summary>
        [Serializable]
        class EmptyPerimeterException : SystemException
        {
            public EmptyPerimeterException() : base(string.Format("Empty perimeter ! FTW !"))
            {
            }
        }
        #endregion


    }
}
