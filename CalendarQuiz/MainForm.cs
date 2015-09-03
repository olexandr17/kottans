using System;
using System.Collections;
using System.Windows.Forms;
using System.Xml;

namespace CalendarQuiz
{
    public partial class MainForm : Form
    {

        private string dataURL = Application.StartupPath +  "\\events.xml";
        
        private ArrayList matches;

        private Timer timerUpdate = new Timer();


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            checkAllowAdd();

            timerUpdate.Interval = 1000 * 60 * 60;
            timerUpdate.Tick += timer_Tick;
            timerUpdate.Enabled = true;

            loadData();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();

                MatchEvent matchNext = getNextMatch();
                string tipText = matchNext != null ? matchNext.getDescription() : "No matches in calendar";
                niTray.ShowBalloonTip(500, Application.ProductName, tipText, ToolTipIcon.Info);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            updateTrayIcon();
        }
        

        private void lstMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = lstMatches.SelectedIndex;
            if (selected > -1 && selected < matches.Count)
            {
                MatchEvent match = (MatchEvent) matches[selected];
                txtTeam1.Text = match.Team1;
                txtTeam2.Text = match.Team2;
                dtpDateBegin.Value = match.DateBegin;
                dtpTimeBegin.Value = match.DateBegin;
                nudDuration.Value = match.Duration;

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }

            checkAllowAdd();
        }

        private void txtTeam_TextChanged(object sender, EventArgs e)
        {
            checkAllowAdd();
        }

        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDateBegin.Value < DateTime.Today)
            {
                dtpDateBegin.Value = DateTime.Today;
            }

            DateTime dateBegin = mergeDate(dtpDateBegin.Value, dtpTimeBegin.Value);
            dtpDateBegin.Value = dateBegin;
            dtpTimeBegin.Value = dateBegin;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selected = lstMatches.SelectedIndex;
            if (selected > -1 && selected < matches.Count)
            {
                MatchEvent matchUpdate = (MatchEvent)matches[selected];
                matchUpdate.Team1 = txtTeam1.Text;
                matchUpdate.Team2 = txtTeam2.Text;
                matchUpdate.DateBegin = mergeDate(dtpDateBegin.Value, dtpTimeBegin.Value);
                matchUpdate.Duration = (int)nudDuration.Value;

                if (matchUpdate.DateBegin < DateTime.Now)
                {
                    MessageBox.Show("You can not to update match which starts in the past", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string matchIntersects = getIntersectsMatches(matchUpdate);
                if (matchIntersects == string.Empty ||
                    MessageBox.Show("Are you really want to update match which intersects with existing match?" + matchIntersects, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    saveData();
                    lstMatches.Items.Clear();
                    loadData();
                    lstMatches.SetSelected(selected, true);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selected = lstMatches.SelectedIndex;
            if (selected > -1 && selected < matches.Count)
            {
                matches.RemoveAt(selected);

                saveData();
                lstMatches.Items.Clear();
                loadData();
                lstMatches.SetSelected(0, false);  
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MatchEvent matchNew = new MatchEvent(
                txtTeam1.Text,
                txtTeam2.Text,
                mergeDate(dtpDateBegin.Value, dtpTimeBegin.Value),
                (int)nudDuration.Value);

            if (matchNew.DateBegin < DateTime.Now)
            {
                MessageBox.Show("You can not to add match which starts in the past", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string matchIntersects = getIntersectsMatches(matchNew);
            if (matchIntersects == string.Empty ||
                MessageBox.Show("Are you really want to add match which intersects with existing match?" + matchIntersects, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                matches.Add(matchNew);

                saveData();
                lstMatches.Items.Clear();
                loadData();
                lstMatches.SetSelected(matches.Count - 1, true);  
            }
        }


        private void niTray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Normal)
                {
                    WindowState = FormWindowState.Minimized;
                    Hide();
                }
                else
                {
                    Show();
                    WindowState = FormWindowState.Normal;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                cmTray.Show();
            }
        }

        private void niTray_MouseMove(object sender, MouseEventArgs e)
        {
            MatchEvent matchNext = getNextMatch();

            if (matchNext != null)
            {
                TimeSpan delay = matchNext.DateBegin - DateTime.Now;
                string description = matchNext.getDescription();
                string through = "Match through " + delay.Days.ToString("00") + ":" + delay.Hours.ToString("00") + ":" + delay.Minutes.ToString("00");
                string tipText = (description + "\n" + through);

                niTray.Text = tipText.Length < 64 ? tipText : description;
            }
            else
            {
                niTray.Text = "No matches in calendar";
            }
        }

        private void cmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void loadData()
        {
            matches = new ArrayList();

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(dataURL);

                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    MatchEvent match = new MatchEvent(node);

                    if (match.DateBegin >= DateTime.Today)
                    {
                        matches.Add(match);
                        lstMatches.Items.Add(match.Team1 + " - " + match.Team2);
                    }
                }

                updateTrayIcon();
            }
            catch
            {

            }
        }

        private void saveData()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<data></data>");

            foreach (MatchEvent match in matches)
            {
                xmlDoc.DocumentElement.AppendChild(match.toXmlNode(xmlDoc));
            }

            xmlDoc.Save(dataURL);
        }


        private DateTime mergeDate(DateTime date, DateTime time)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0, 0);
        }

        private string getIntersectsMatches(MatchEvent match)
        {
            string intersects = string.Empty;
            foreach (MatchEvent m in matches)
            {
                if (match.isIntersectWith(m))
                {
                    intersects += ("\n" + m.getDescription());
                }
            }

            return intersects;
        }

        private MatchEvent getNextMatch()
        {
            MatchEvent next = null;
            if (matches.Count > 0)
            {
                next = (MatchEvent)matches[0];
                foreach (MatchEvent m in matches)
                {
                    if (next.DateBegin > m.DateBegin)
                    {
                        next = m;
                    }
                }
            }

            return next;
        }

        private void checkAllowAdd()
        {
            btnAdd.Enabled = (txtTeam1.Text != string.Empty && txtTeam2.Text != string.Empty);
        }

        private void updateTrayIcon()
        {
            MatchEvent next = getNextMatch();
            if (next != null && (next.DateBegin - DateTime.Now).Days < 14)
            {
                niTray.Icon = MatchCalendar.Properties.Resources.football2;
            }
            else
            {
                niTray.Icon = MatchCalendar.Properties.Resources.football1;
            }
        }

    }
}
