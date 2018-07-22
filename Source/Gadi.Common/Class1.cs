using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadi.Common
{
    public class Class1
    {
    }

    public sealed class Singleton
    {
        private Singleton()
        {

        }

        public static Singleton _singleton = null;

        public static Singleton SingletonInstance
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new Singleton();
                }
                return _singleton;
            }
        }
        
    }
}
