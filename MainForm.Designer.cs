namespace MunicipalityServiceApp2
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlBottomNav = new System.Windows.Forms.Panel();
            this.btnProfile = new FontAwesome.Sharp.IconButton();
            this.btnSettings = new FontAwesome.Sharp.IconButton();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.btnEvents = new FontAwesome.Sharp.IconButton();
            this.btnRequests = new FontAwesome.Sharp.IconButton();
            this.btnReportIssue = new FontAwesome.Sharp.IconButton();
            this.btnDashboard = new FontAwesome.Sharp.IconButton();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.lblHelpArrow = new System.Windows.Forms.Label();
            this.lblHelpSub = new System.Windows.Forms.Label();
            this.lblHelp = new System.Windows.Forms.Label();
            this.pnlQuickEvents = new System.Windows.Forms.Panel();
            this.lblUpcomingEventsSub = new System.Windows.Forms.Label();
            this.lblUpcomingEvents = new System.Windows.Forms.Label();
            this.IconQuickEvents = new FontAwesome.Sharp.IconPictureBox();
            this.pnlQuickRequests = new System.Windows.Forms.Panel();
            this.lblActiveRequestsSub = new System.Windows.Forms.Label();
            this.lblActiveRequests = new System.Windows.Forms.Label();
            this.iconQuickRequests = new FontAwesome.Sharp.IconPictureBox();
            this.pnlActivityHeader = new System.Windows.Forms.Panel();
            this.lblActivityHeader = new System.Windows.Forms.Label();
            this.pnlQuickReport = new System.Windows.Forms.Panel();
            this.lblQuickArrow = new System.Windows.Forms.Label();
            this.lblQuickReportSub = new System.Windows.Forms.Label();
            this.lblQuickReport = new System.Windows.Forms.Label();
            this.iconQuickReport = new FontAwesome.Sharp.IconPictureBox();
            this.pnlQuickHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQuickTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.pnlBottomNav.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            this.pnlQuickEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconQuickEvents)).BeginInit();
            this.pnlQuickRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconQuickRequests)).BeginInit();
            this.pnlActivityHeader.SuspendLayout();
            this.pnlQuickReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconQuickReport)).BeginInit();
            this.pnlQuickHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.White;
            this.pnlSidebar.Controls.Add(this.pnlBottomNav);
            this.pnlSidebar.Controls.Add(this.pnlNavigation);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(10, 15, 10, 15);
            this.pnlSidebar.Size = new System.Drawing.Size(150, 711);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlBottomNav
            // 
            this.pnlBottomNav.Controls.Add(this.btnProfile);
            this.pnlBottomNav.Controls.Add(this.btnSettings);
            this.pnlBottomNav.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomNav.Location = new System.Drawing.Point(10, 546);
            this.pnlBottomNav.Name = "pnlBottomNav";
            this.pnlBottomNav.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.pnlBottomNav.Size = new System.Drawing.Size(130, 150);
            this.pnlBottomNav.TabIndex = 0;
            // 
            // btnProfile
            // 
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnProfile.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.btnProfile.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnProfile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProfile.IconSize = 40;
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProfile.Location = new System.Drawing.Point(5, 75);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(120, 65);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.Text = "profile";
            this.btnProfile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnSettings.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSettings.IconSize = 40;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSettings.Location = new System.Drawing.Point(5, 10);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(120, 65);
            this.btnSettings.TabIndex = 4;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSettings.UseVisualStyleBackColor = true;
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.Controls.Add(this.btnEvents);
            this.pnlNavigation.Controls.Add(this.btnRequests);
            this.pnlNavigation.Controls.Add(this.btnReportIssue);
            this.pnlNavigation.Controls.Add(this.btnDashboard);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNavigation.Location = new System.Drawing.Point(10, 105);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.pnlNavigation.Size = new System.Drawing.Size(130, 591);
            this.pnlNavigation.TabIndex = 1;
            // 
            // btnEvents
            // 
            this.btnEvents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEvents.FlatAppearance.BorderSize = 0;
            this.btnEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEvents.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnEvents.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.btnEvents.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnEvents.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEvents.IconSize = 40;
            this.btnEvents.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEvents.Location = new System.Drawing.Point(5, 226);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Size = new System.Drawing.Size(120, 72);
            this.btnEvents.TabIndex = 3;
            this.btnEvents.Text = "Events";
            this.btnEvents.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEvents.UseVisualStyleBackColor = true;
            // 
            // btnRequests
            // 
            this.btnRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRequests.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRequests.FlatAppearance.BorderSize = 0;
            this.btnRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequests.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRequests.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnRequests.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btnRequests.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnRequests.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRequests.IconSize = 40;
            this.btnRequests.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRequests.Location = new System.Drawing.Point(5, 154);
            this.btnRequests.Name = "btnRequests";
            this.btnRequests.Size = new System.Drawing.Size(120, 72);
            this.btnRequests.TabIndex = 2;
            this.btnRequests.Text = "Requests";
            this.btnRequests.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRequests.UseVisualStyleBackColor = true;
            // 
            // btnReportIssue
            // 
            this.btnReportIssue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportIssue.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportIssue.FlatAppearance.BorderSize = 0;
            this.btnReportIssue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportIssue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnReportIssue.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.btnReportIssue.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnReportIssue.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReportIssue.IconSize = 40;
            this.btnReportIssue.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReportIssue.Location = new System.Drawing.Point(5, 82);
            this.btnReportIssue.Name = "btnReportIssue";
            this.btnReportIssue.Size = new System.Drawing.Size(120, 72);
            this.btnReportIssue.TabIndex = 1;
            this.btnReportIssue.Text = "Report Issue";
            this.btnReportIssue.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReportIssue.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnDashboard.IconChar = FontAwesome.Sharp.IconChar.HomeLg;
            this.btnDashboard.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDashboard.IconSize = 40;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDashboard.Location = new System.Drawing.Point(5, 10);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(120, 72);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDashboard.UseVisualStyleBackColor = true;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.picLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(10, 15);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(130, 90);
            this.pnlLogo.TabIndex = 0;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picLogo.Image = global::MunicipalityServiceApp2.Properties.Resources.logo;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(130, 65);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.pnlHelp);
            this.pnlRight.Controls.Add(this.pnlQuickEvents);
            this.pnlRight.Controls.Add(this.pnlQuickRequests);
            this.pnlRight.Controls.Add(this.pnlActivityHeader);
            this.pnlRight.Controls.Add(this.pnlQuickReport);
            this.pnlRight.Controls.Add(this.pnlQuickHeader);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(856, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(18, 24, 18, 24);
            this.pnlRight.Size = new System.Drawing.Size(280, 711);
            this.pnlRight.TabIndex = 1;
            // 
            // pnlHelp
            // 
            this.pnlHelp.Controls.Add(this.lblHelpArrow);
            this.pnlHelp.Controls.Add(this.lblHelpSub);
            this.pnlHelp.Controls.Add(this.lblHelp);
            this.pnlHelp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHelp.Location = new System.Drawing.Point(18, 612);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(244, 75);
            this.pnlHelp.TabIndex = 5;
            // 
            // lblHelpArrow
            // 
            this.lblHelpArrow.AutoSize = true;
            this.lblHelpArrow.BackColor = System.Drawing.Color.White;
            this.lblHelpArrow.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpArrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblHelpArrow.Location = new System.Drawing.Point(190, 40);
            this.lblHelpArrow.Name = "lblHelpArrow";
            this.lblHelpArrow.Size = new System.Drawing.Size(35, 32);
            this.lblHelpArrow.TabIndex = 2;
            this.lblHelpArrow.Text = "→";
            // 
            // lblHelpSub
            // 
            this.lblHelpSub.AutoSize = true;
            this.lblHelpSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelpSub.Location = new System.Drawing.Point(3, 40);
            this.lblHelpSub.Name = "lblHelpSub";
            this.lblHelpSub.Size = new System.Drawing.Size(145, 15);
            this.lblHelpSub.TabIndex = 1;
            this.lblHelpSub.Text = "Contact your municipality";
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHelp.Location = new System.Drawing.Point(3, 9);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(96, 21);
            this.lblHelp.TabIndex = 0;
            this.lblHelp.Text = "Need help?";
            // 
            // pnlQuickEvents
            // 
            this.pnlQuickEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.pnlQuickEvents.Controls.Add(this.lblUpcomingEventsSub);
            this.pnlQuickEvents.Controls.Add(this.lblUpcomingEvents);
            this.pnlQuickEvents.Controls.Add(this.IconQuickEvents);
            this.pnlQuickEvents.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuickEvents.Location = new System.Drawing.Point(18, 344);
            this.pnlQuickEvents.Name = "pnlQuickEvents";
            this.pnlQuickEvents.Padding = new System.Windows.Forms.Padding(12);
            this.pnlQuickEvents.Size = new System.Drawing.Size(244, 65);
            this.pnlQuickEvents.TabIndex = 4;
            // 
            // lblUpcomingEventsSub
            // 
            this.lblUpcomingEventsSub.AutoSize = true;
            this.lblUpcomingEventsSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingEventsSub.Location = new System.Drawing.Point(66, 38);
            this.lblUpcomingEventsSub.Name = "lblUpcomingEventsSub";
            this.lblUpcomingEventsSub.Size = new System.Drawing.Size(72, 15);
            this.lblUpcomingEventsSub.TabIndex = 2;
            this.lblUpcomingEventsSub.Text = "0 Upcoming";
            // 
            // lblUpcomingEvents
            // 
            this.lblUpcomingEvents.AutoSize = true;
            this.lblUpcomingEvents.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpcomingEvents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblUpcomingEvents.Location = new System.Drawing.Point(63, 12);
            this.lblUpcomingEvents.Name = "lblUpcomingEvents";
            this.lblUpcomingEvents.Size = new System.Drawing.Size(48, 17);
            this.lblUpcomingEvents.TabIndex = 1;
            this.lblUpcomingEvents.Text = "Events";
            // 
            // IconQuickEvents
            // 
            this.IconQuickEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.IconQuickEvents.Dock = System.Windows.Forms.DockStyle.Left;
            this.IconQuickEvents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.IconQuickEvents.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.IconQuickEvents.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.IconQuickEvents.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconQuickEvents.IconSize = 41;
            this.IconQuickEvents.Location = new System.Drawing.Point(12, 12);
            this.IconQuickEvents.Name = "IconQuickEvents";
            this.IconQuickEvents.Size = new System.Drawing.Size(45, 41);
            this.IconQuickEvents.TabIndex = 0;
            this.IconQuickEvents.TabStop = false;
            // 
            // pnlQuickRequests
            // 
            this.pnlQuickRequests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.pnlQuickRequests.Controls.Add(this.lblActiveRequestsSub);
            this.pnlQuickRequests.Controls.Add(this.lblActiveRequests);
            this.pnlQuickRequests.Controls.Add(this.iconQuickRequests);
            this.pnlQuickRequests.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuickRequests.Location = new System.Drawing.Point(18, 279);
            this.pnlQuickRequests.Name = "pnlQuickRequests";
            this.pnlQuickRequests.Padding = new System.Windows.Forms.Padding(12);
            this.pnlQuickRequests.Size = new System.Drawing.Size(244, 65);
            this.pnlQuickRequests.TabIndex = 3;
            // 
            // lblActiveRequestsSub
            // 
            this.lblActiveRequestsSub.AutoSize = true;
            this.lblActiveRequestsSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveRequestsSub.Location = new System.Drawing.Point(66, 38);
            this.lblActiveRequestsSub.Name = "lblActiveRequestsSub";
            this.lblActiveRequestsSub.Size = new System.Drawing.Size(63, 15);
            this.lblActiveRequestsSub.TabIndex = 2;
            this.lblActiveRequestsSub.Text = "0 Requests";
            // 
            // lblActiveRequests
            // 
            this.lblActiveRequests.AutoSize = true;
            this.lblActiveRequests.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveRequests.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblActiveRequests.Location = new System.Drawing.Point(63, 12);
            this.lblActiveRequests.Name = "lblActiveRequests";
            this.lblActiveRequests.Size = new System.Drawing.Size(63, 17);
            this.lblActiveRequests.TabIndex = 1;
            this.lblActiveRequests.Text = "Requests";
            // 
            // iconQuickRequests
            // 
            this.iconQuickRequests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.iconQuickRequests.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconQuickRequests.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.iconQuickRequests.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.iconQuickRequests.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.iconQuickRequests.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconQuickRequests.IconSize = 41;
            this.iconQuickRequests.Location = new System.Drawing.Point(12, 12);
            this.iconQuickRequests.Name = "iconQuickRequests";
            this.iconQuickRequests.Size = new System.Drawing.Size(45, 41);
            this.iconQuickRequests.TabIndex = 0;
            this.iconQuickRequests.TabStop = false;
            // 
            // pnlActivityHeader
            // 
            this.pnlActivityHeader.Controls.Add(this.lblActivityHeader);
            this.pnlActivityHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlActivityHeader.Location = new System.Drawing.Point(18, 224);
            this.pnlActivityHeader.Name = "pnlActivityHeader";
            this.pnlActivityHeader.Size = new System.Drawing.Size(244, 55);
            this.pnlActivityHeader.TabIndex = 2;
            // 
            // lblActivityHeader
            // 
            this.lblActivityHeader.AutoSize = true;
            this.lblActivityHeader.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivityHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblActivityHeader.Location = new System.Drawing.Point(0, 18);
            this.lblActivityHeader.Name = "lblActivityHeader";
            this.lblActivityHeader.Size = new System.Drawing.Size(139, 30);
            this.lblActivityHeader.TabIndex = 1;
            this.lblActivityHeader.Text = "Your Activity";
            this.lblActivityHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlQuickReport
            // 
            this.pnlQuickReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.pnlQuickReport.Controls.Add(this.lblQuickArrow);
            this.pnlQuickReport.Controls.Add(this.lblQuickReportSub);
            this.pnlQuickReport.Controls.Add(this.lblQuickReport);
            this.pnlQuickReport.Controls.Add(this.iconQuickReport);
            this.pnlQuickReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuickReport.Location = new System.Drawing.Point(18, 89);
            this.pnlQuickReport.Name = "pnlQuickReport";
            this.pnlQuickReport.Padding = new System.Windows.Forms.Padding(16);
            this.pnlQuickReport.Size = new System.Drawing.Size(244, 135);
            this.pnlQuickReport.TabIndex = 1;
            // 
            // lblQuickArrow
            // 
            this.lblQuickArrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuickArrow.AutoSize = true;
            this.lblQuickArrow.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickArrow.ForeColor = System.Drawing.Color.White;
            this.lblQuickArrow.Location = new System.Drawing.Point(190, 87);
            this.lblQuickArrow.Name = "lblQuickArrow";
            this.lblQuickArrow.Size = new System.Drawing.Size(35, 32);
            this.lblQuickArrow.TabIndex = 3;
            this.lblQuickArrow.Text = "→";
            // 
            // lblQuickReportSub
            // 
            this.lblQuickReportSub.AutoSize = true;
            this.lblQuickReportSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickReportSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.lblQuickReportSub.Location = new System.Drawing.Point(15, 82);
            this.lblQuickReportSub.Name = "lblQuickReportSub";
            this.lblQuickReportSub.Size = new System.Drawing.Size(142, 15);
            this.lblQuickReportSub.TabIndex = 2;
            this.lblQuickReportSub.Text = "Tell Us What\'s Happening";
            // 
            // lblQuickReport
            // 
            this.lblQuickReport.AutoSize = true;
            this.lblQuickReport.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickReport.ForeColor = System.Drawing.Color.White;
            this.lblQuickReport.Location = new System.Drawing.Point(15, 52);
            this.lblQuickReport.Name = "lblQuickReport";
            this.lblQuickReport.Size = new System.Drawing.Size(153, 25);
            this.lblQuickReport.TabIndex = 1;
            this.lblQuickReport.Text = "Report An Issue";
            // 
            // iconQuickReport
            // 
            this.iconQuickReport.BackColor = System.Drawing.Color.Transparent;
            this.iconQuickReport.IconChar = FontAwesome.Sharp.IconChar.ExclamationTriangle;
            this.iconQuickReport.IconColor = System.Drawing.Color.White;
            this.iconQuickReport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconQuickReport.IconSize = 35;
            this.iconQuickReport.Location = new System.Drawing.Point(15, 12);
            this.iconQuickReport.Name = "iconQuickReport";
            this.iconQuickReport.Size = new System.Drawing.Size(35, 35);
            this.iconQuickReport.TabIndex = 0;
            this.iconQuickReport.TabStop = false;
            // 
            // pnlQuickHeader
            // 
            this.pnlQuickHeader.Controls.Add(this.label1);
            this.pnlQuickHeader.Controls.Add(this.lblQuickTitle);
            this.pnlQuickHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuickHeader.Location = new System.Drawing.Point(18, 24);
            this.pnlQuickHeader.Name = "pnlQuickHeader";
            this.pnlQuickHeader.Size = new System.Drawing.Size(244, 65);
            this.pnlQuickHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(0, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Get things done faster";
            // 
            // lblQuickTitle
            // 
            this.lblQuickTitle.AutoSize = true;
            this.lblQuickTitle.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblQuickTitle.Location = new System.Drawing.Point(0, 2);
            this.lblQuickTitle.Name = "lblQuickTitle";
            this.lblQuickTitle.Size = new System.Drawing.Size(150, 30);
            this.lblQuickTitle.TabIndex = 0;
            this.lblQuickTitle.Text = "Quick Actions";
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(150, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(706, 711);
            this.pnlContent.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1136, 711);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlSidebar);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Municipality Services";
            this.pnlSidebar.ResumeLayout(false);
            this.pnlBottomNav.ResumeLayout(false);
            this.pnlNavigation.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlHelp.ResumeLayout(false);
            this.pnlHelp.PerformLayout();
            this.pnlQuickEvents.ResumeLayout(false);
            this.pnlQuickEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconQuickEvents)).EndInit();
            this.pnlQuickRequests.ResumeLayout(false);
            this.pnlQuickRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconQuickRequests)).EndInit();
            this.pnlActivityHeader.ResumeLayout(false);
            this.pnlActivityHeader.PerformLayout();
            this.pnlQuickReport.ResumeLayout(false);
            this.pnlQuickReport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconQuickReport)).EndInit();
            this.pnlQuickHeader.ResumeLayout(false);
            this.pnlQuickHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlNavigation;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private FontAwesome.Sharp.IconButton btnRequests;
        private FontAwesome.Sharp.IconButton btnReportIssue;
        private FontAwesome.Sharp.IconButton btnEvents;
        private System.Windows.Forms.Panel pnlBottomNav;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnProfile;
        private System.Windows.Forms.Panel pnlQuickHeader;
        private System.Windows.Forms.Label lblQuickTitle;
        private System.Windows.Forms.Panel pnlQuickReport;
        private FontAwesome.Sharp.IconPictureBox iconQuickReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQuickReportSub;
        private System.Windows.Forms.Label lblQuickReport;
        private System.Windows.Forms.Label lblQuickArrow;
        private System.Windows.Forms.Panel pnlActivityHeader;
        private System.Windows.Forms.Panel pnlQuickRequests;
        private FontAwesome.Sharp.IconPictureBox iconQuickRequests;
        private System.Windows.Forms.Label lblActivityHeader;
        private System.Windows.Forms.Label lblActiveRequests;
        private System.Windows.Forms.Label lblActiveRequestsSub;
        private System.Windows.Forms.Panel pnlQuickEvents;
        private System.Windows.Forms.Label lblUpcomingEventsSub;
        private System.Windows.Forms.Label lblUpcomingEvents;
        private FontAwesome.Sharp.IconPictureBox IconQuickEvents;
        private System.Windows.Forms.Panel pnlHelp;
        private System.Windows.Forms.Label lblHelpSub;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblHelpArrow;
    }
}

