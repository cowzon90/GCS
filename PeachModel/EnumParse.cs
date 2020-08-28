using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeachModel
{
    public static class EnumParse
    {
        public static object FromInt(Type type, int index, int defaultEnum = 0)
        {
            try
            {
                object o = Enum.ToObject(type, index);
                return o;
            }
            catch (Exception)
            {
                try
                {
                    return Enum.ToObject(type, defaultEnum);
                }
                catch (Exception)
                {
                    return null;
                    throw;
                }
            }
        }
    }
}
