using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchCalendar
{
    class Config
    {

        public static string DataURL = Application.StartupPath + "\\events.xml";

        public static int TimeUpdate = 1000 * 60 * 30;
        public static int DaysThrough = 14;

    }
}
