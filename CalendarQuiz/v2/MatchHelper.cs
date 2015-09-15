using CalendarQuiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchCalendar
{
    class MatchHelper
    {

        public static string ToIntersectsString(MatchProvider provider, MatchItem match)
        {
            string intersects = string.Empty;
            foreach (MatchItem m in provider)
            {
                if (match.isIntersectWith(m))
                {
                    intersects += ("\n" + m.getDescription());
                }
            }

            return intersects;
        }

        public static DateTime MergeDate(DateTime date, DateTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0, 0);
        }


    }
}
