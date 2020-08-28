using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeachView.Ucs.Common
{
    public class CustomTimer : Timer
    {
        public CustomTimer(int milliseconds, EventHandler tick)
        {
            base.Interval = milliseconds;
            base.Tick += tick;
        }

    }
}
