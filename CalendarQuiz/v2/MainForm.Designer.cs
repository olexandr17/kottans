namespace CalendarQuiz
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lstMatches = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTeam1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTeam2 = new System.Windows.Forms.TextBox();
            this.lblDateBegin = new System.Windows.Forms.Label();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeBegin = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblDuration = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.niTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.cmTray.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lstMatches
            // 
            this.lstMatches.FormattingEnabled = true;
            resources.ApplyResources(this.lstMatches, "lstMatches");
            this.lstMatches.Name = "lstMatches";
            this.lstMatches.SelectedIndexChanged += new System.EventHandler(this.lstMatches_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtTeam1
            // 
            resources.ApplyResources(this.txtTeam1, "txtTeam1");
            this.txtTeam1.Name = "txtTeam1";
            this.txtTeam1.TextChanged += new System.EventHandler(this.txtTeam_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtTeam2
            // 
            resources.ApplyResources(this.txtTeam2, "txtTeam2");
            this.txtTeam2.Name = "txtTeam2";
            this.txtTeam2.TextChanged += new System.EventHandler(this.txtTeam_TextChanged);
            // 
            // lblDateBegin
            // 
            resources.ApplyResources(this.lblDateBegin, "lblDateBegin");
            this.lblDateBegin.Name = "lblDateBegin";
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            resources.ApplyResources(this.dtpDateBegin, "dtpDateBegin");
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.ValueChanged += new System.EventHandler(this.dtpBegin_ValueChanged);
            // 
            // dtpTimeBegin
            // 
            resources.ApplyResources(this.dtpTimeBegin, "dtpTimeBegin");
            this.dtpTimeBegin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeBegin.Name = "dtpTimeBegin";
            this.dtpTimeBegin.ShowUpDown = true;
            this.dtpTimeBegin.ValueChanged += new System.EventHandler(this.dtpBegin_ValueChanged);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblDuration
            // 
            resources.ApplyResources(this.lblDuration, "lblDuration");
            this.lblDuration.Name = "lblDuration";
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // niTray
            // 
            this.niTray.ContextMenuStrip = this.cmTray;
            resources.ApplyResources(this.niTray, "niTray");
            this.niTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.niTray_MouseClick);
            this.niTray.MouseMove += new System.Windows.Forms.MouseEventHandler(this.niTray_MouseMove);
            // 
            // cmTray
            // 
            this.cmTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmExit});
            this.cmTray.Name = "cmTray";
            resources.ApplyResources(this.cmTray, "cmTray");
            // 
            // cmExit
            // 
            this.cmExit.Name = "cmExit";
            resources.ApplyResources(this.cmExit, "cmExit");
            this.cmExit.Click += new System.EventHandler(this.cmExit_Click);
            // 
            // nudDuration
            // 
            resources.ApplyResources(this.nudDuration, "nudDuration");
            this.nudDuration.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Value = new decimal(new int[] {
            105,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nudDuration);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dtpTimeBegin);
            this.Controls.Add(this.dtpDateBegin);
            this.Controls.Add(this.lblDateBegin);
            this.Controls.Add(this.txtTeam2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTeam1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstMatches);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.cmTray.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstMatches;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTeam1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTeam2;
        private System.Windows.Forms.Label lblDateBegin;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.DateTimePicker dtpTimeBegin;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.NotifyIcon niTray;
        private System.Windows.Forms.ContextMenuStrip cmTray;
        private System.Windows.Forms.ToolStripMenuItem cmExit;
        private System.Windows.Forms.NumericUpDown nudDuration;
    }
}

