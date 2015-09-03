using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CalendarQuiz
{
    class MatchEvent
    {

        public string Team1;
        public string Team2;

        public DateTime DateBegin;
        public int Duration;

        public DateTime DateEnd
        {
            get
            {
                return DateBegin.AddMinutes(Duration);
            }
        }


        public MatchEvent(string team1, string team2, DateTime dateBegin, int duration)
        {
            Team1 = team1;
            Team2 = team2;
            DateBegin = dateBegin;
            Duration = duration;
        }

        public MatchEvent(XmlNode match)
        {
            foreach (XmlNode node in match.ChildNodes)
            {
                switch (node.Name)
                {
                    case "team1":
                        Team1 = node.InnerText;
                        break;
                    case "team2":
                        Team2 = node.InnerText;
                        break;
                    case "dateBegin":
                        DateBegin = Convert.ToDateTime(node.InnerText);
                        break;
                    case "duration":
                        Duration = Convert.ToInt32(node.InnerText);
                        break;
                }
            }
        }

        public XmlNode toXmlNode(XmlDocument xmlDoc)
        {
            XmlNode match = xmlDoc.CreateElement("event");
            XmlNode node;

            node = xmlDoc.CreateElement("team1");
            node.InnerText = Team1;
            match.AppendChild(node);

            node = xmlDoc.CreateElement("team2");
            node.InnerText = Team2;
            match.AppendChild(node);

            node = xmlDoc.CreateElement("dateBegin");
            node.InnerText = DateBegin.ToString();
            match.AppendChild(node);

            node = xmlDoc.CreateElement("duration");
            node.InnerText = Duration.ToString();
            match.AppendChild(node);

            return match;
        }

        public string getDescription()
        {
            return Team1 + " - " + Team2 + " (" + 
                DateBegin.Day.ToString("00") + "." + DateBegin.Month.ToString("00") + "." + DateBegin.Year.ToString("00") + ", " + 
                DateBegin.Hour.ToString("00") + ":" + DateBegin.Minute.ToString("00") + ")";
        }

        public bool isIntersectWith(MatchEvent match)
        {
            return (match != this && (DateBegin < match.DateEnd && DateEnd > match.DateBegin));
        }

    }
}
