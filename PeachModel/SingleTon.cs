using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel
{
    public class SingleTon<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = Activator.CreateInstance<T>();
                }
                return (T)_instance;
            }
        }

        private SingleTon()
        {

        }

    }
}
