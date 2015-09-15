using CalendarQuiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MatchCalendar
{
    class MatchProvider:List<MatchItem>
    {

        public delegate void LoadHandler(MatchProvider sender, EventArgs e);

        public event LoadHandler OnLoadSuccess;
        public event LoadHandler OnLoadFail;


        private string dataURL;


        public MatchProvider(string url)
        {
            dataURL = url;
        }

        public void Load()
        {
            Clear();

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(dataURL);

                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    MatchItem match = new MatchItem(node);

                    if (match.DateBegin >= DateTime.Today)
                    {
                        Add(match);
                    }
                }

                if (OnLoadSuccess != null)
                {
                    OnLoadSuccess(this, null);
                }
            }
            catch
            {
                if (OnLoadFail != null)
                {
                    OnLoadFail(this, null);
                }
            }
        }

        public void Save()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<data></data>");

            foreach (MatchItem match in this)
            {
                xmlDoc.DocumentElement.AppendChild(match.toXmlNode(xmlDoc));
            }

            xmlDoc.Save(dataURL);
        }

        public MatchItem GetNextMatch()
        {
            MatchItem next = null;
            if (Count > 0)
            {
                foreach (MatchItem match in this)
                {
                    if (match.DateBegin > DateTime.Now && (next == null || next.DateBegin > match.DateBegin))
                    {
                        next = match;
                    }
                }
            }

            return next;
        }

    }
}
