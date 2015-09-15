using MatchCalendar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CalendarQuiz
{
    public partial class MainForm : Form
    {

        private MatchProvider matchProvider;
        private Timer timerUpdate = new Timer();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            checkAllowUpdate();
            checkAllowDelete();
            checkAllowAdd();

            timerUpdate.Interval = Config.TimeUpdate;
            timerUpdate.Tick += timer_Tick;
            timerUpdate.Enabled = true;

            matchProvider = new MatchProvider(Config.DataURL);
            matchProvider.OnLoadSuccess += matchProvider_OnLoadSuccess;
            matchProvider.Load();
        }


        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();

                MatchItem matchNext = matchProvider.GetNextMatch();

                string tipText = Strings.NoMatches;
                if (matchNext != null)
                {
                    tipText = matchNext.getDescription();
                }

                niTray.ShowBalloonTip(500, Application.ProductName, tipText, ToolTipIcon.Info);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            updateTrayIcon();
        }

        private void matchProvider_OnLoadSuccess(MatchProvider sender, EventArgs e)
        {
            foreach (MatchItem match in matchProvider)
            {
                lstMatches.Items.Add(match.getName());
            }

            updateTrayIcon();
        }


        private void lstMatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = lstMatches.SelectedIndex;
            if (selected > -1 && selected < matchProvider.Count)
            {
                MatchItem match = matchProvider[selected];
                txtTeam1.Text = match.Team1;
                txtTeam2.Text = match.Team2;
                dtpDateBegin.Value = match.DateBegin;
                dtpTimeBegin.Value = match.DateBegin;
                nudDuration.Value = match.Duration;
            }

            checkAllowUpdate();
            checkAllowDelete();
            checkAllowAdd();
        }

        private void txtTeam_TextChanged(object sender, EventArgs e)
        {
            checkAllowUpdate();
            checkAllowAdd();
        }

        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDateBegin.Value < DateTime.Today)
            {
                dtpDateBegin.Value = DateTime.Today;
            }

            DateTime dateBegin = MatchHelper.MergeDate(dtpDateBegin.Value, dtpTimeBegin.Value);
            dtpDateBegin.Value = dateBegin;
            dtpTimeBegin.Value = dateBegin;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int selected = lstMatches.SelectedIndex;
            if (selected > -1 && selected < matchProvider.Count)
            {
                MatchItem matchUpdate = matchProvider[selected];
                matchUpdate.Team1 = txtTeam1.Text;
                matchUpdate.Team2 = txtTeam2.Text;
                matchUpdate.DateBegin = MatchHelper.MergeDate(dtpDateBegin.Value, dtpTimeBegin.Value);
                matchUpdate.Duration = (int)nudDuration.Value;

                if (matchUpdate.DateBegin < DateTime.Now)
                {
                    MessageBox.Show(Strings.NotUpdate, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string matchIntersects = MatchHelper.ToIntersectsString(matchProvider, matchUpdate);
                if (matchIntersects == string.Empty ||
                    MessageBox.Show(Strings.IntersectUpdate + matchIntersects, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    matchProvider.Save();
                    lstMatches.Items.Clear();
                    matchProvider.Load();
                    lstMatches.SetSelected(selected, true);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selected = lstMatches.SelectedIndex;
            if (selected > -1 && selected < matchProvider.Count)
            {
                matchProvider.RemoveAt(selected);

                matchProvider.Save();
                lstMatches.Items.Clear();
                matchProvider.Load();
                lstMatches.SetSelected(0, false);  
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MatchItem matchNew = new MatchItem(
                txtTeam1.Text,
                txtTeam2.Text,
                MatchHelper.MergeDate(dtpDateBegin.Value, dtpTimeBegin.Value),
                (int)nudDuration.Value);

            if (matchNew.DateBegin < DateTime.Now)
            {
                MessageBox.Show(Strings.NotAdd, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string matchIntersects = MatchHelper.ToIntersectsString(matchProvider, matchNew);
            if (matchIntersects == string.Empty ||
                MessageBox.Show(Strings.IntersectAdd + matchIntersects, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                matchProvider.Add(matchNew);

                matchProvider.Save();
                lstMatches.Items.Clear();
                matchProvider.Load();
                lstMatches.SetSelected(matchProvider.Count - 1, true);  
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
            MatchItem matchNext = matchProvider.GetNextMatch();

            if (matchNext != null)
            {
                TimeSpan delay = matchNext.DateBegin - DateTime.Now;
                string description = matchNext.getDescription();
                int minutes = delay.Minutes + (delay.Seconds > 30 ? 1 : 0);
                string through = Strings.Through + delay.Days.ToString("00") + ":" + delay.Hours.ToString("00") + ":" + minutes.ToString("00");
                string tipText = (description + "\n" + through);

                niTray.Text = tipText.Length < 64 ? tipText : description;
            }
            else
            {
                niTray.Text = Strings.NoMatches;
            }
        }

        private void cmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void checkAllowUpdate()
        {
            int selected = lstMatches.SelectedIndex;
            if (selected > -1 && selected < matchProvider.Count)
            {
                btnUpdate.Enabled = (txtTeam1.Text != string.Empty && txtTeam2.Text != string.Empty);
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void checkAllowDelete()
        {
            int selected = lstMatches.SelectedIndex;
            if (selected > -1 && selected < matchProvider.Count)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }
        }

        private void checkAllowAdd()
        {
            btnAdd.Enabled = (txtTeam1.Text != string.Empty && txtTeam2.Text != string.Empty);
        }

        private void updateTrayIcon()
        {
            MatchItem next = matchProvider.GetNextMatch();
            if (next != null && (next.DateBegin - DateTime.Now).Days < Config.DaysThrough)
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
