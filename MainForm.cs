using MunicipalityServiceApp2.Models;
using MunicipalityServiceApp2.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalityServiceApp2
{
    public partial class MainForm : Form
    {
        // =========================================================
        // COLOURS
        // =========================================================

        private readonly Color activeBackColor =
            ColorTranslator.FromHtml("#EFF6FF");

        private readonly Color activeColor =
            ColorTranslator.FromHtml("#2563EB");

        private readonly Color normalBackColor =
            Color.White;

        private readonly Color normalColor =
            ColorTranslator.FromHtml("#111827");

        private readonly Color hoverBackColor =
            ColorTranslator.FromHtml("#F9FAFB");

        private readonly Color pageBackground =
            ColorTranslator.FromHtml("#F6F7F9");

        private readonly Color secondaryText =
            ColorTranslator.FromHtml("#6B7280");

        private readonly Color borderColor =
            ColorTranslator.FromHtml("#E5E7EB");

        private readonly Stack<Event> viewedEvents = new Stack<Event>();

        private readonly RecommendationService recommendationService = new RecommendationService();


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public MainForm()
        {
            InitializeComponent();

            new EventSeedService().Seed();

            SetupNavigation();

            SetActiveButton(btnDashboard);
            ShowDashboard();
        }


        // =========================================================
        // NAVIGATION SETUP
        // =========================================================

        private void SetupNavigation()
        {
            SetupNavButton(btnDashboard);
            SetupNavButton(btnReportIssue);
            SetupNavButton(btnRequests);
            SetupNavButton(btnEvents);

            SetupNavButton(btnSettings);
            SetupNavButton(btnProfile);

            btnDashboard.Click += NavButton_Click;
            btnReportIssue.Click += NavButton_Click;
            btnRequests.Click += NavButton_Click;
            btnEvents.Click += NavButton_Click;
            btnSettings.Click += NavButton_Click;
            btnProfile.Click += NavButton_Click;

            SetupQuickReportAction();
            SetupQuickRequestsAction();
            SetupQuickEventsAction();
        }


        private void SetupNavButton(FontAwesome.Sharp.IconButton button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            button.BackColor = normalBackColor;
            button.ForeColor = normalColor;
            button.IconColor = normalColor;

            button.Cursor = Cursors.Hand;

            button.MouseEnter += NavButton_MouseEnter;
            button.MouseLeave += NavButton_MouseLeave;
        }


        private void NavButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is FontAwesome.Sharp.IconButton button)
            {
                if (button.BackColor != activeBackColor)
                {
                    button.BackColor = hoverBackColor;
                }
            }
        }


        private void NavButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is FontAwesome.Sharp.IconButton button)
            {
                if (button.BackColor != activeBackColor)
                {
                    button.BackColor = normalBackColor;
                }
            }
        }


        // =========================================================
        // NAVIGATION
        // =========================================================

        private void NavButton_Click(object sender, EventArgs e)
        {
            if (sender is FontAwesome.Sharp.IconButton clickedButton)
            {
                SetActiveButton(clickedButton);

                if (clickedButton == btnDashboard)
                    ShowDashboard();

                else if (clickedButton == btnReportIssue)
                    ShowReportIssue();

                else if (clickedButton == btnRequests)
                    ShowRequests();

                else if (clickedButton == btnEvents)
                    ShowEvents();

                else if (clickedButton == btnSettings)
                    ShowManageRequests();

                else if (clickedButton == btnProfile)
                    ShowProfile();
            }
        }


        private void SetActiveButton(FontAwesome.Sharp.IconButton activeButton)
        {
            ResetNavButton(btnDashboard);
            ResetNavButton(btnReportIssue);
            ResetNavButton(btnRequests);
            ResetNavButton(btnEvents);
            ResetNavButton(btnSettings);
            ResetNavButton(btnProfile);

            activeButton.BackColor = activeBackColor;
            activeButton.ForeColor = activeColor;
            activeButton.IconColor = activeColor;
        }


        private void ResetNavButton(FontAwesome.Sharp.IconButton button)
        {
            button.BackColor = normalBackColor;
            button.ForeColor = normalColor;
            button.IconColor = normalColor;
        }


        // =========================================================
        // RIGHT PANEL - REPORT
        // =========================================================

        private void SetupQuickReportAction()
        {
            pnlQuickReport.Cursor = Cursors.Hand;
            iconQuickReport.Cursor = Cursors.Hand;
            lblQuickReport.Cursor = Cursors.Hand;
            lblQuickReportSub.Cursor = Cursors.Hand;
            lblQuickArrow.Cursor = Cursors.Hand;

            pnlQuickReport.Click += QuickReport_Click;
            iconQuickReport.Click += QuickReport_Click;
            lblQuickReport.Click += QuickReport_Click;
            lblQuickReportSub.Click += QuickReport_Click;
            lblQuickArrow.Click += QuickReport_Click;
        }


        private void QuickReport_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnReportIssue);
            ShowReportIssue();
        }


        // =========================================================
        // RIGHT PANEL - REQUESTS
        // =========================================================

        private void SetupQuickRequestsAction()
        {
            pnlQuickRequests.Cursor = Cursors.Hand;
            iconQuickRequests.Cursor = Cursors.Hand;
            lblActiveRequests.Cursor = Cursors.Hand;
            lblActiveRequestsSub.Cursor = Cursors.Hand;

            pnlQuickRequests.Click += QuickRequests_Click;
            iconQuickRequests.Click += QuickRequests_Click;
            lblActiveRequests.Click += QuickRequests_Click;
            lblActiveRequestsSub.Click += QuickRequests_Click;
        }


        private void QuickRequests_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnRequests);
            ShowRequests();
        }


        // =========================================================
        // RIGHT PANEL - EVENTS
        // =========================================================

        private void SetupQuickEventsAction()
        {
            pnlQuickEvents.Cursor = Cursors.Hand;
            IconQuickEvents.Cursor = Cursors.Hand;
            lblUpcomingEvents.Cursor = Cursors.Hand;
            lblUpcomingEventsSub.Cursor = Cursors.Hand;

            pnlQuickEvents.Click += QuickEvents_Click;
            IconQuickEvents.Click += QuickEvents_Click;
            lblUpcomingEvents.Click += QuickEvents_Click;
            lblUpcomingEventsSub.Click += QuickEvents_Click;
        }


        private void QuickEvents_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnEvents);
            ShowEvents();
        }


        // =========================================================
        // DASHBOARD
        // =========================================================

        private void ShowDashboard()
        {
            ClearContent();

            Panel page = CreatePage();
            pnlContent.Controls.Add(page);

            // =========================
            // PAGE HEADER
            // =========================

            Label title = CreateTitle("Good day 👋");
            title.Location = new Point(32, 28);
            page.Controls.Add(title);

            Label subtitle = CreateSubtitle(
                "Here is an overview of your municipal service requests."
            );
            subtitle.Location = new Point(34, 68);
            page.Controls.Add(subtitle);


            // =========================
            // LOAD DATABASE DATA
            // =========================

            IssueService issueService = new IssueService();

            int totalRequests = issueService.GetTotalIssues();
            int activeRequests = issueService.GetActiveIssues();
            int resolvedRequests = issueService.GetResolvedIssues();

            List<Issue> recentIssues =
                issueService.GetRecentIssues(5);


            // =========================
            // STAT CARDS
            // =========================

            Panel totalCard = CreateStatCard(
                "TOTAL REQUESTS",
                totalRequests.ToString(),
                "All submitted issues",
                "#2563EB"
            );

            totalCard.Location = new Point(32, 115);
            totalCard.Width = 190;
            totalCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left;

            page.Controls.Add(totalCard);


            Panel activeCard = CreateStatCard(
                "ACTIVE",
                activeRequests.ToString(),
                "Pending or in progress",
                "#F59E0B"
            );

            activeCard.Location = new Point(238, 115);
            activeCard.Width = 190;
            activeCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left;

            page.Controls.Add(activeCard);


            Panel resolvedCard = CreateStatCard(
                "RESOLVED",
                resolvedRequests.ToString(),
                "Successfully completed",
                "#10B981"
            );

            resolvedCard.Location = new Point(444, 115);
            resolvedCard.Width = 190;
            resolvedCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left;

            page.Controls.Add(resolvedCard);


            // =========================
            // RECENT REQUESTS CARD
            // =========================

            Panel recentCard = CreateCard(
                32,
                250,
                page.ClientSize.Width - 64,
                330
            );

            recentCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(recentCard);


            Label recentTitle = CreateCardTitle(
                "Recent Requests"
            );

            recentTitle.Location = new Point(24, 20);
            recentCard.Controls.Add(recentTitle);


            Label recentSubtitle = CreateSmallText(
                "Your latest municipal service requests."
            );

            recentSubtitle.Location = new Point(25, 48);
            recentCard.Controls.Add(recentSubtitle);


            // =========================
            // EMPTY STATE
            // =========================

            if (recentIssues.Count == 0)
            {
                Label emptyTitle = new Label
                {
                    Text = "No requests yet",
                    Font = new Font(
                        "Segoe UI",
                        12F,
                        FontStyle.Bold
                    ),
                    ForeColor = normalColor,
                    AutoSize = true
                };

                emptyTitle.Location = new Point(
                    25,
                    105
                );

                recentCard.Controls.Add(emptyTitle);


                Label emptySubtitle = CreateSmallText(
                    "When you report an issue, it will appear here."
                );

                emptySubtitle.Location = new Point(
                    25,
                    132
                );

                recentCard.Controls.Add(emptySubtitle);


                Button btnReport = CreatePrimaryButton(
                    "Report an Issue  →",
                    150,
                    40
                );

                btnReport.Location = new Point(
                    25,
                    175
                );

                btnReport.Click += (s, e) =>
                {
                    SetActiveButton(btnReportIssue);
                    ShowReportIssue();
                };

                recentCard.Controls.Add(btnReport);
            }
            else
            {
                // =========================
                // DISPLAY RECENT REQUESTS
                // =========================

                int y = 88;

                foreach (Issue issue in recentIssues)
                {
                    Panel row = new Panel
                    {
                        Location = new Point(20, y),
                        Size = new Size(
                            recentCard.Width - 40,
                            42
                        ),
                        BackColor = Color.White,
                        Anchor =
                            AnchorStyles.Top |
                            AnchorStyles.Left |
                            AnchorStyles.Right
                    };

                    ApplyRoundedCorners(row, 8);


                    // CATEGORY
                    Label category = new Label
                    {
                        Text = issue.Category,
                        Font = new Font(
                            "Segoe UI",
                            9F,
                            FontStyle.Bold
                        ),
                        ForeColor = normalColor,
                        AutoSize = true,
                        Location = new Point(12, 12)
                    };

                    row.Controls.Add(category);


                    // LOCATION
                    Label location = CreateSmallText(
                        issue.Location
                    );

                    location.Location = new Point(
                        150,
                        13
                    );

                    row.Controls.Add(location);


                    // STATUS
                    Label status = new Label
                    {
                        Text = issue.Status,
                        Font = new Font(
                            "Segoe UI",
                            8.5F,
                            FontStyle.Bold
                        ),
                        AutoSize = true
                    };

                    if (issue.Status == "Resolved")
                    {
                        status.ForeColor = ColorTranslator.FromHtml(
                            "#10B981"
                        );
                    }
                    else if (issue.Status == "In Progress")
                    {
                        status.ForeColor = ColorTranslator.FromHtml(
                            "#2563EB"
                        );
                    }
                    else
                    {
                        status.ForeColor = ColorTranslator.FromHtml(
                            "#F59E0B"
                        );
                    }

                    status.Location = new Point(
                        recentCard.Width - 125,
                        13
                    );

                    status.Anchor =
                        AnchorStyles.Top |
                        AnchorStyles.Right;

                    row.Controls.Add(status);


                    recentCard.Controls.Add(row);

                    y += 48;
                }


                // =========================
                // VIEW ALL BUTTON
                // =========================

                Button btnViewAll = new Button
                {
                    Text = "View all requests  →",
                    AutoSize = true,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.White,
                    ForeColor = activeColor,
                    Font = new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Bold
                    ),
                    Location = new Point(
                        25,
                        recentCard.Height - 42
                    ),
                    Cursor = Cursors.Hand,
                    Anchor =
                        AnchorStyles.Bottom |
                        AnchorStyles.Left
                };

                btnViewAll.FlatAppearance.BorderSize = 0;

                btnViewAll.Click += (s, e) =>
                {
                    SetActiveButton(btnRequests);
                    ShowRequests();
                };

                recentCard.Controls.Add(btnViewAll);
            }


            // =========================
            // REPORT ISSUE CTA
            // =========================

            Panel reportCard = CreateCard(
                32,
                600,
                page.ClientSize.Width - 64,
                90
            );

            reportCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(reportCard);


            Label reportTitle = new Label
            {
                Text = "Have a problem in your community?",
                Font = new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold
                ),
                ForeColor = normalColor,
                AutoSize = true,
                Location = new Point(22, 18)
            };

            reportCard.Controls.Add(reportTitle);


            Label reportSubtitle = CreateSmallText(
                "Report it and help improve your community."
            );

            reportSubtitle.Location = new Point(
                23,
                45
            );

            reportCard.Controls.Add(reportSubtitle);


            Button btnReportIssueDashboard =
                CreatePrimaryButton(
                    "Report Issue  →",
                    145,
                    40
                );

            btnReportIssueDashboard.Location =
                new Point(
                    reportCard.Width - 170,
                    25
                );

            btnReportIssueDashboard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Right;

            btnReportIssueDashboard.Click += (s, e) =>
            {
                SetActiveButton(btnReportIssue);
                ShowReportIssue();
            };

            reportCard.Controls.Add(
                btnReportIssueDashboard
            );
        }
        // =========================================================
        // REPORT ISSUE
        // =========================================================

        private void ShowReportIssue()
        {
            ClearContent();

            Panel page = CreatePage();

            pnlContent.Controls.Add(page);


            Label title = CreateTitle("Report an Issue");
            title.Location = new Point(32, 28);
            page.Controls.Add(title);


            Label subtitle = CreateSubtitle(
                "Tell us what's happening in your community."
            );

            subtitle.Location = new Point(34, 68);
            page.Controls.Add(subtitle);


            Panel formCard = CreateCard(
                32,
                112,
                page.ClientSize.Width - 64,
                490
            );

            formCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(formCard);


            // -----------------------------------------------------
            // CARD HEADER
            // -----------------------------------------------------

            Label sectionTitle = new Label
            {
                Text = "Issue Details",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = normalColor,
                AutoSize = true,
                Location = new Point(26, 24)
            };

            formCard.Controls.Add(sectionTitle);


            Label sectionSubtitle = CreateSmallText(
                "Provide enough information for the municipality to assist you."
            );

            sectionSubtitle.Location = new Point(27, 51);
            formCard.Controls.Add(sectionSubtitle);


            // -----------------------------------------------------
            // LOCATION
            // -----------------------------------------------------

            Label locationLabel = CreateFieldLabel("Location");
            locationLabel.Location = new Point(27, 92);
            formCard.Controls.Add(locationLabel);


            TextBox txtLocation = CreateTextBox(
                "Where is the issue located?"
            );

            txtLocation.Location = new Point(27, 117);
            txtLocation.Width = formCard.Width - 54;
            txtLocation.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            formCard.Controls.Add(txtLocation);


            // -----------------------------------------------------
            // CATEGORY
            // -----------------------------------------------------

            Label categoryLabel = CreateFieldLabel("Category");
            categoryLabel.Location = new Point(27, 167);
            formCard.Controls.Add(categoryLabel);


            ComboBox cmbCategory = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9.5F),
                BackColor = Color.White,
                ForeColor = normalColor,
                FlatStyle = FlatStyle.Flat,
                Width = formCard.Width - 54,
                Height = 35
            };

            cmbCategory.Items.AddRange(new object[]
            {
                "Sanitation",
                "Roads",
                "Water",
                "Electricity",
                "Waste Management",
                "Other"
            });

            cmbCategory.SelectedIndex = -1;
            cmbCategory.Location = new Point(27, 192);

            formCard.Controls.Add(cmbCategory);


            // -----------------------------------------------------
            // DESCRIPTION
            // -----------------------------------------------------

            Label descriptionLabel = CreateFieldLabel("Description");
            descriptionLabel.Location = new Point(27, 242);
            formCard.Controls.Add(descriptionLabel);


            TextBox txtDescription = new TextBox
            {
                Multiline = true,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = normalColor,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                ScrollBars = ScrollBars.Vertical,
                Width = formCard.Width - 54,
                Height = 85,
                Location = new Point(27, 267),
                Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Left |
                    AnchorStyles.Right
            };

            formCard.Controls.Add(txtDescription);


            // -----------------------------------------------------
            // ATTACHMENT
            // -----------------------------------------------------

            Label attachmentLabel = CreateFieldLabel("Attachment");
            attachmentLabel.Location = new Point(27, 367);
            formCard.Controls.Add(attachmentLabel);


            Label attachmentName = CreateSmallText(
                "No file selected"
            );

            attachmentName.Location = new Point(145, 392);
            formCard.Controls.Add(attachmentName);


            Button btnAttachment = new Button
            {
                Text = "📎  Choose File",
                Size = new Size(110, 34),
                Location = new Point(27, 387),
                BackColor = Color.White,
                ForeColor = normalColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font(
                    "Segoe UI",
                    8.5F,
                    FontStyle.Bold
                ),
                Cursor = Cursors.Hand
            };

            btnAttachment.FlatAppearance.BorderColor =
                borderColor;

            btnAttachment.Click += (s, e) =>
            {
                using (OpenFileDialog dialog =
                    new OpenFileDialog())
                {
                    dialog.Title = "Select an attachment";
                    dialog.Filter =
                        "Images|*.jpg;*.jpeg;*.png;*.gif|" +
                        "Documents|*.pdf;*.doc;*.docx|" +
                        "All files|*.*";

                    if (dialog.ShowDialog() ==
                        DialogResult.OK)
                    {
                        attachmentName.Text =
                            Path.GetFileName(dialog.FileName);
                    }
                }
            };

            formCard.Controls.Add(btnAttachment);


            // -----------------------------------------------------
            // SUBMIT
            // -----------------------------------------------------

            Button btnSubmit = CreatePrimaryButton(
                "Submit Issue  →",
                150,
                42
            );

            btnSubmit.Anchor =
                AnchorStyles.Bottom |
                AnchorStyles.Right;

            btnSubmit.Location = new Point(
                formCard.Width - 176,
                formCard.Height - 58
            );

            btnSubmit.Click += (s, e) =>
            {
                // -----------------------------------------------------
                // VALIDATION
                // -----------------------------------------------------

                string location = txtLocation.Text.Trim();
                string category = cmbCategory.SelectedItem?.ToString();
                string description = txtDescription.Text.Trim();

                if (string.IsNullOrWhiteSpace(location))
                {
                    MessageBox.Show(
                        "Please enter the issue location.",
                        "Missing Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtLocation.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(category))
                {
                    MessageBox.Show(
                        "Please select an issue category.",
                        "Missing Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    cmbCategory.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(description))
                {
                    MessageBox.Show(
                        "Please describe the issue.",
                        "Missing Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    txtDescription.Focus();
                    return;
                }


                // -----------------------------------------------------
                // SAVE TO DATABASE
                // -----------------------------------------------------

                try
                {
                    IssueService issueService = new IssueService();

                    Issue issue = issueService.CreateIssue(
                        location,
                        category,
                        description
                    );

                    MessageBox.Show(
                        $"Issue #{issue.Id} has been submitted successfully.",
                        "Issue Submitted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Return to dashboard
                    SetActiveButton(btnDashboard);
                    ShowDashboard();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Something went wrong while submitting your issue.\n\n" +
                        ex.Message,
                        "Submission Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            };

            formCard.Controls.Add(btnSubmit);
        }


        // =========================================================
        // REQUESTS
        // =========================================================

        private void ShowRequests()
        {
            ClearContent();

            Panel page = CreatePage();
            pnlContent.Controls.Add(page);

            // =========================
            // PAGE HEADER
            // =========================

            Label title = CreateTitle("My Requests");
            title.Location = new Point(32, 28);
            page.Controls.Add(title);

            Label subtitle = CreateSubtitle(
                "Track the progress of issues you've reported."
            );

            subtitle.Location = new Point(34, 68);
            page.Controls.Add(subtitle);


            // =========================
            // LOAD DATABASE DATA
            // =========================

            IssueService issueService = new IssueService();

            List<Issue> issues = issueService.GetAllIssues();

            int totalRequests = issues.Count;

            int activeRequests = issues.Count(i =>
                i.Status == "Pending" ||
                i.Status == "In Progress");

            int resolvedRequests = issues.Count(i =>
                i.Status == "Resolved");


            // =========================
            // SUMMARY CARD
            // =========================

            Panel summaryCard = CreateCard(
                32,
                112,
                page.ClientSize.Width - 64,
                110
            );

            summaryCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(summaryCard);


            // TOTAL

            Label total = CreateFieldLabel(
                "TOTAL REQUESTS"
            );

            total.Location = new Point(25, 20);
            summaryCard.Controls.Add(total);


            Label totalValue = new Label
            {
                Text = totalRequests.ToString(),
                Font = new Font(
                    "Segoe UI",
                    25F,
                    FontStyle.Bold
                ),
                ForeColor = activeColor,
                AutoSize = true,
                Location = new Point(24, 42)
            };

            summaryCard.Controls.Add(totalValue);


            // ACTIVE

            Label status = CreateFieldLabel(
                "ACTIVE"
            );

            status.Location = new Point(220, 20);
            summaryCard.Controls.Add(status);


            Label activeValue = new Label
            {
                Text = activeRequests.ToString(),
                Font = new Font(
                    "Segoe UI",
                    25F,
                    FontStyle.Bold
                ),
                ForeColor = ColorTranslator.FromHtml(
                    "#F59E0B"
                ),
                AutoSize = true,
                Location = new Point(219, 42)
            };

            summaryCard.Controls.Add(activeValue);


            // RESOLVED

            Label resolved = CreateFieldLabel(
                "RESOLVED"
            );

            resolved.Location = new Point(410, 20);
            summaryCard.Controls.Add(resolved);


            Label resolvedValue = new Label
            {
                Text = resolvedRequests.ToString(),
                Font = new Font(
                    "Segoe UI",
                    25F,
                    FontStyle.Bold
                ),
                ForeColor = ColorTranslator.FromHtml(
                    "#10B981"
                ),
                AutoSize = true,
                Location = new Point(409, 42)
            };

            summaryCard.Controls.Add(resolvedValue);


            // =========================
            // REQUESTS CARD
            // =========================

            Panel requestsCard = CreateCard(
                32,
                245,
                page.ClientSize.Width - 64,
                390
            );

            requestsCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(requestsCard);


            Label requestsTitle = CreateCardTitle(
                "Submitted Requests"
            );

            requestsTitle.Location =
                new Point(24, 20);

            requestsCard.Controls.Add(
                requestsTitle
            );


            Label requestsSubtitle = CreateSmallText(
                "Your most recently submitted municipal issues."
            );

            requestsSubtitle.Location =
                new Point(25, 48);

            requestsCard.Controls.Add(
                requestsSubtitle
            );


            // =========================
            // EMPTY STATE
            // =========================

            if (issues.Count == 0)
            {
                FontAwesome.Sharp.IconPictureBox requestIcon =
                    CreateIcon(
                        FontAwesome.Sharp.IconChar.ClipboardList,
                        "#CBD5E1",
                        42,
                        60,
                        105
                    );

                requestsCard.Controls.Add(
                    requestIcon
                );


                Label noRequests = CreateCardTitle(
                    "Nothing to track yet"
                );

                noRequests.Location = new Point(
                    (requestsCard.Width -
                     noRequests.PreferredWidth) / 2,
                    155
                );

                requestsCard.Controls.Add(
                    noRequests
                );


                Label requestText = CreateSmallText(
                    "Once you report an issue, its status will appear here."
                );

                requestText.Location = new Point(
                    (requestsCard.Width -
                     requestText.PreferredWidth) / 2,
                    185
                );

                requestsCard.Controls.Add(
                    requestText
                );


                Button requestButton =
                    CreatePrimaryButton(
                        "Report an Issue  →",
                        160,
                        38
                    );

                requestButton.Location = new Point(
                    (requestsCard.Width - 160) / 2,
                    225
                );

                requestButton.Click += (s, e) =>
                {
                    SetActiveButton(btnReportIssue);
                    ShowReportIssue();
                };

                requestsCard.Controls.Add(
                    requestButton
                );

                return;
            }


            // =========================
            // REQUEST LIST
            // =========================

            int y = 88;

            foreach (Issue issue in issues)
            {
                Panel requestRow = new Panel
                {
                    Location = new Point(20, y),
                    Size = new Size(
                        requestsCard.Width - 40,
                        58
                    ),
                    BackColor = Color.White,
                    Anchor =
                        AnchorStyles.Top |
                        AnchorStyles.Left |
                        AnchorStyles.Right,
                    Cursor = Cursors.Hand
                };

                ApplyRoundedCorners(
                    requestRow,
                    8
                );


                // ID

                Label idLabel = new Label
                {
                    Text = $"#{issue.Id}",
                    Font = new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Bold
                    ),
                    ForeColor = activeColor,
                    AutoSize = true,
                    Location = new Point(14, 20)
                };

                requestRow.Controls.Add(
                    idLabel
                );


                // CATEGORY

                Label categoryLabel = new Label
                {
                    Text = issue.Category,
                    Font = new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Bold
                    ),
                    ForeColor = normalColor,
                    AutoSize = true,
                    Location = new Point(65, 11)
                };

                requestRow.Controls.Add(
                    categoryLabel
                );


                // LOCATION

                Label locationLabel =
                    CreateSmallText(
                        issue.Location
                    );

                locationLabel.Location =
                    new Point(65, 31);

                requestRow.Controls.Add(
                    locationLabel
                );


                // DATE

                Label dateLabel =
                    CreateSmallText(
                        issue.DateReported.ToString(
                            "dd MMM yyyy"
                        )
                    );

                dateLabel.AutoSize = true;
                dateLabel.Location =
                    new Point(
                        requestsCard.Width - 255,
                        20
                    );

                dateLabel.Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Right;

                requestRow.Controls.Add(
                    dateLabel
                );


                // STATUS

                Label statusLabel = new Label
                {
                    Text = issue.Status,
                    Font = new Font(
                        "Segoe UI",
                        8.5F,
                        FontStyle.Bold
                    ),
                    AutoSize = true
                };

                if (issue.Status == "Resolved")
                {
                    statusLabel.ForeColor =
                        ColorTranslator.FromHtml(
                            "#10B981"
                        );
                }
                else if (issue.Status == "In Progress")
                {
                    statusLabel.ForeColor =
                        ColorTranslator.FromHtml(
                            "#2563EB"
                        );
                }
                else
                {
                    statusLabel.ForeColor =
                        ColorTranslator.FromHtml(
                            "#F59E0B"
                        );
                }

                statusLabel.Location =
                    new Point(
                        requestsCard.Width - 105,
                        20
                    );

                statusLabel.Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Right;

                requestRow.Controls.Add(
                    statusLabel
                );

                requestRow.Click += (s, e) =>
                {
                    ShowRequestDetails(issue);
                };

                foreach (Control control in requestRow.Controls)
                {
                    control.Click += (s, e) =>
                    {
                        ShowRequestDetails(issue);
                    };
                }


                requestsCard.Controls.Add(
                    requestRow
                );

                y += 68;
            }
        }

        // =========================================================
        // SHOW REQUESTS
        // =========================================================

        private void ShowRequestDetails(Issue issue)
        {
            ClearContent();

            Panel page = CreatePage();
            pnlContent.Controls.Add(page);

            // =========================
            // BACK BUTTON
            // =========================

            Button btnBack = new Button
            {
                Text = "←  Back to My Requests",
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = activeColor,
                Font = new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                ),
                Location = new Point(32, 20),
                Cursor = Cursors.Hand
            };

            btnBack.FlatAppearance.BorderSize = 0;

            btnBack.Click += (s, e) =>
            {
                SetActiveButton(btnRequests);
                ShowRequests();
            };

            page.Controls.Add(btnBack);


            // =========================
            // HEADER
            // =========================

            Label title = CreateTitle(
                $"Request #{issue.Id}"
            );

            title.Location = new Point(32, 62);
            page.Controls.Add(title);


            Label subtitle = CreateSubtitle(
                "View the details and current progress of your request."
            );

            subtitle.Location = new Point(34, 102);
            page.Controls.Add(subtitle);


            // =========================
            // MAIN DETAILS CARD
            // =========================

            Panel detailsCard = CreateCard(
                32,
                145,
                page.ClientSize.Width - 64,
                400
            );

            detailsCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(detailsCard);


            // =========================
            // CATEGORY
            // =========================

            Label categoryLabel =
                CreateFieldLabel("CATEGORY");

            categoryLabel.Location =
                new Point(28, 25);

            detailsCard.Controls.Add(
                categoryLabel
            );


            Label categoryValue = new Label
            {
                Text = issue.Category,
                Font = new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold
                ),
                ForeColor = normalColor,
                AutoSize = true,
                Location = new Point(27, 48)
            };

            detailsCard.Controls.Add(
                categoryValue
            );


            // =========================
            // STATUS
            // =========================

            Label statusLabel =
                CreateFieldLabel("STATUS");

            statusLabel.Location =
                new Point(270, 25);

            detailsCard.Controls.Add(
                statusLabel
            );


            Label statusValue = new Label
            {
                Text = issue.Status,
                Font = new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                ),
                AutoSize = true,
                Padding = new Padding(
                    10,
                    5,
                    10,
                    5
                )
            };


            if (issue.Status == "Resolved")
            {
                statusValue.ForeColor =
                    ColorTranslator.FromHtml(
                        "#047857"
                    );

                statusValue.BackColor =
                    ColorTranslator.FromHtml(
                        "#D1FAE5"
                    );
            }
            else if (issue.Status == "In Progress")
            {
                statusValue.ForeColor =
                    ColorTranslator.FromHtml(
                        "#1D4ED8"
                    );

                statusValue.BackColor =
                    ColorTranslator.FromHtml(
                        "#DBEAFE"
                    );
            }
            else
            {
                statusValue.ForeColor =
                    ColorTranslator.FromHtml(
                        "#B45309"
                    );

                statusValue.BackColor =
                    ColorTranslator.FromHtml(
                        "#FEF3C7"
                    );
            }

            statusValue.Location =
                new Point(269, 44);

            detailsCard.Controls.Add(
                statusValue
            );


            // =========================
            // DATE
            // =========================

            Label dateLabel =
                CreateFieldLabel(
                    "DATE REPORTED"
                );

            dateLabel.Location =
                new Point(470, 25);

            detailsCard.Controls.Add(
                dateLabel
            );


            Label dateValue = new Label
            {
                Text = issue.DateReported.ToString(
                    "dd MMM yyyy, HH:mm"
                ),
                Font = new Font(
                    "Segoe UI",
                    9.5F
                ),
                ForeColor = normalColor,
                AutoSize = true,
                Location = new Point(469, 48)
            };

            detailsCard.Controls.Add(
                dateValue
            );


            // =========================
            // DIVIDER
            // =========================

            Panel divider = new Panel
            {
                Height = 1,
                Width = detailsCard.Width - 56,
                BackColor = borderColor,
                Location = new Point(28, 90),
                Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Left |
                    AnchorStyles.Right
            };

            detailsCard.Controls.Add(
                divider
            );


            // =========================
            // LOCATION
            // =========================

            Label locationLabel =
                CreateFieldLabel("LOCATION");

            locationLabel.Location =
                new Point(28, 115);

            detailsCard.Controls.Add(
                locationLabel
            );


            Label locationValue = new Label
            {
                Text = issue.Location,
                Font = new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold
                ),
                ForeColor = normalColor,
                AutoSize = true,
                Location = new Point(27, 138)
            };

            detailsCard.Controls.Add(
                locationValue
            );


            // =========================
            // DESCRIPTION
            // =========================

            Label descriptionLabel =
                CreateFieldLabel(
                    "DESCRIPTION"
                );

            descriptionLabel.Location =
                new Point(28, 185);

            detailsCard.Controls.Add(
                descriptionLabel
            );


            Label descriptionValue = new Label
            {
                Text = issue.Description,
                Font = new Font(
                    "Segoe UI",
                    9.5F
                ),
                ForeColor = normalColor,
                AutoSize = false,
                Location = new Point(27, 210),
                Size = new Size(
                    detailsCard.Width - 54,
                    70
                ),
                Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Left |
                    AnchorStyles.Right
            };

            detailsCard.Controls.Add(
                descriptionValue
            );


            // =========================
            // ATTACHMENT
            // =========================

            Label attachmentLabel =
                CreateFieldLabel(
                    "ATTACHMENT"
                );

            attachmentLabel.Location =
                new Point(28, 305);

            detailsCard.Controls.Add(
                attachmentLabel
            );


            string attachmentText =
                string.IsNullOrWhiteSpace(
                    issue.AttachmentPath
                )
                    ? "No attachment"
                    : Path.GetFileName(
                        issue.AttachmentPath
                      );

            Label attachmentValue =
                CreateSmallText(
                    attachmentText
                );

            attachmentValue.Location =
                new Point(27, 328);

            detailsCard.Controls.Add(
                attachmentValue
            );


            // =========================
            // STATUS PROGRESS CARD
            // =========================

            Panel progressCard = CreateCard(
                32,
                565,
                page.ClientSize.Width - 64,
                120
            );

            progressCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(
                progressCard
            );


            Label progressTitle =
                CreateCardTitle(
                    "Request Progress"
                );

            progressTitle.Location =
                new Point(24, 18);

            progressCard.Controls.Add(
                progressTitle
            );


            // =========================
            // PROGRESS LINE
            // =========================

            Panel progressLine = new Panel
            {
                Height = 4,
                BackColor =
                    ColorTranslator.FromHtml(
                        "#E5E7EB"
                    ),
                Location = new Point(
                    55,
                    67
                ),
                Width = progressCard.Width - 110,
                Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Left |
                    AnchorStyles.Right
            };

            progressCard.Controls.Add(
                progressLine
            );


            int currentStep = 1;

            if (issue.Status == "In Progress")
                currentStep = 2;

            if (issue.Status == "Resolved")
                currentStep = 3;


            int[] stepPositions =
            {
        55,
        progressCard.Width / 2,
        progressCard.Width - 55
    };


            string[] stepNames =
            {
        "Pending",
        "In Progress",
        "Resolved"
    };


            for (int i = 0; i < 3; i++)
            {
                bool completed = i + 1 <= currentStep;

                Label step = new Label
                {
                    Text = completed
                        ? "●"
                        : "○",
                    Font = new Font(
                        "Segoe UI",
                        16F,
                        FontStyle.Bold
                    ),
                    ForeColor = completed
                        ? activeColor
                        : ColorTranslator.FromHtml(
                            "#CBD5E1"
                          ),
                    AutoSize = true,
                    Location = new Point(
                        stepPositions[i] - 8,
                        54
                    )
                };

                progressCard.Controls.Add(
                    step
                );


                Label stepLabel = new Label
                {
                    Text = stepNames[i],
                    Font = new Font(
                        "Segoe UI",
                        8.5F,
                        FontStyle.Bold
                    ),
                    ForeColor = completed
                        ? normalColor
                        : secondaryText,
                    AutoSize = true,
                    Location = new Point(
                        stepPositions[i] -
                        (
                            TextRenderer.MeasureText(
                                stepNames[i],
                                new Font(
                                    "Segoe UI",
                                    8.5F,
                                    FontStyle.Bold
                                )
                            ).Width / 2
                        ),
                        88
                    )
                };

                progressCard.Controls.Add(
                    stepLabel
                );
            }
        }

        // =========================================================
        // SHOW MANAGE REQUESTS
        // =========================================================

        private void ShowManageRequests()
        {
            ClearContent();

            Panel page = CreatePage();
            pnlContent.Controls.Add(page);

            // =========================
            // HEADER
            // =========================

            Label title = CreateTitle("Manage Requests");
            title.Location = new Point(32, 28);
            page.Controls.Add(title);

            Label subtitle = CreateSubtitle(
                "Review submitted issues and update their progress."
            );

            subtitle.Location = new Point(34, 68);
            page.Controls.Add(subtitle);


            // =========================
            // LOAD DATA
            // =========================

            IssueService issueService = new IssueService();

            List<Issue> issues = issueService.GetAllIssues();


            // =========================
            // SUMMARY
            // =========================

            Panel summaryCard = CreateCard(
                32,
                112,
                page.ClientSize.Width - 64,
                110
            );

            summaryCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(summaryCard);


            Label totalLabel =
                CreateFieldLabel("TOTAL");

            totalLabel.Location =
                new Point(25, 20);

            summaryCard.Controls.Add(
                totalLabel
            );


            Label totalValue = new Label
            {
                Text = issues.Count.ToString(),
                Font = new Font(
                    "Segoe UI",
                    25F,
                    FontStyle.Bold
                ),
                ForeColor = activeColor,
                AutoSize = true,
                Location = new Point(24, 42)
            };

            summaryCard.Controls.Add(
                totalValue
            );


            Label pendingLabel =
                CreateFieldLabel("PENDING");

            pendingLabel.Location =
                new Point(180, 20);

            summaryCard.Controls.Add(
                pendingLabel
            );


            Label pendingValue = new Label
            {
                Text = issues.Count(i =>
                    i.Status == "Pending").ToString(),
                Font = new Font(
                    "Segoe UI",
                    25F,
                    FontStyle.Bold
                ),
                ForeColor =
                    ColorTranslator.FromHtml(
                        "#F59E0B"
                    ),
                AutoSize = true,
                Location = new Point(179, 42)
            };

            summaryCard.Controls.Add(
                pendingValue
            );


            Label progressLabel =
                CreateFieldLabel("IN PROGRESS");

            progressLabel.Location =
                new Point(340, 20);

            summaryCard.Controls.Add(
                progressLabel
            );


            Label progressValue = new Label
            {
                Text = issues.Count(i =>
                    i.Status == "In Progress").ToString(),
                Font = new Font(
                    "Segoe UI",
                    25F,
                    FontStyle.Bold
                ),
                ForeColor = activeColor,
                AutoSize = true,
                Location = new Point(339, 42)
            };

            summaryCard.Controls.Add(
                progressValue
            );


            Label resolvedLabel =
                CreateFieldLabel("RESOLVED");

            resolvedLabel.Location =
                new Point(520, 20);

            summaryCard.Controls.Add(
                resolvedLabel
            );


            Label resolvedValue = new Label
            {
                Text = issues.Count(i =>
                    i.Status == "Resolved").ToString(),
                Font = new Font(
                    "Segoe UI",
                    25F,
                    FontStyle.Bold
                ),
                ForeColor =
                    ColorTranslator.FromHtml(
                        "#10B981"
                    ),
                AutoSize = true,
                Location = new Point(519, 42)
            };

            summaryCard.Controls.Add(
                resolvedValue
            );


            // =========================
            // REQUEST LIST
            // =========================

            Panel requestsCard = CreateCard(
                32,
                245,
                page.ClientSize.Width - 64,
                400
            );

            requestsCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(
                requestsCard
            );


            Label requestsTitle =
                CreateCardTitle(
                    "Submitted Requests"
                );

            requestsTitle.Location =
                new Point(24, 20);

            requestsCard.Controls.Add(
                requestsTitle
            );


            Label requestsSubtitle =
                CreateSmallText(
                    "Select a request to manage its status."
                );

            requestsSubtitle.Location =
                new Point(25, 48);

            requestsCard.Controls.Add(
                requestsSubtitle
            );


            // =========================
            // EMPTY STATE
            // =========================

            if (issues.Count == 0)
            {
                Label empty = CreateCardTitle(
                    "No requests available"
                );

                empty.Location =
                    new Point(25, 110);

                requestsCard.Controls.Add(
                    empty
                );

                return;
            }


            // =========================
            // REQUEST ROWS
            // =========================

            int y = 88;

            foreach (Issue issue in issues)
            {
                Panel row = new Panel
                {
                    Location = new Point(20, y),
                    Size = new Size(
                        requestsCard.Width - 40,
                        62
                    ),
                    BackColor = Color.White,
                    Anchor =
                        AnchorStyles.Top |
                        AnchorStyles.Left |
                        AnchorStyles.Right
                };

                ApplyRoundedCorners(
                    row,
                    8
                );


                // REQUEST ID

                Label idLabel = new Label
                {
                    Text = $"#{issue.Id}",
                    Font = new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Bold
                    ),
                    ForeColor = activeColor,
                    AutoSize = true,
                    Location = new Point(
                        14,
                        22
                    )
                };

                row.Controls.Add(
                    idLabel
                );


                // CATEGORY

                Label categoryLabel = new Label
                {
                    Text = issue.Category,
                    Font = new Font(
                        "Segoe UI",
                        9F,
                        FontStyle.Bold
                    ),
                    ForeColor = normalColor,
                    AutoSize = true,
                    Location = new Point(
                        65,
                        13
                    )
                };

                row.Controls.Add(
                    categoryLabel
                );


                // LOCATION

                Label locationLabel =
                    CreateSmallText(
                        issue.Location
                    );

                locationLabel.Location =
                    new Point(
                        65,
                        34
                    );

                row.Controls.Add(
                    locationLabel
                );


                // STATUS

                Label statusLabel = new Label
                {
                    Text = issue.Status,
                    Font = new Font(
                        "Segoe UI",
                        8.5F,
                        FontStyle.Bold
                    ),
                    AutoSize = true
                };


                if (issue.Status == "Resolved")
                {
                    statusLabel.ForeColor =
                        ColorTranslator.FromHtml(
                            "#10B981"
                        );
                }
                else if (
                    issue.Status == "In Progress")
                {
                    statusLabel.ForeColor =
                        activeColor;
                }
                else
                {
                    statusLabel.ForeColor =
                        ColorTranslator.FromHtml(
                            "#F59E0B"
                        );
                }


                statusLabel.Location =
                    new Point(
                        requestsCard.Width - 255,
                        22
                    );

                statusLabel.Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Right;

                row.Controls.Add(
                    statusLabel
                );


                // MANAGE BUTTON

                Button manageButton =
                    CreatePrimaryButton(
                        "Manage",
                        90,
                        34
                    );

                manageButton.Location =
                    new Point(
                        requestsCard.Width - 115,
                        14
                    );

                manageButton.Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Right;

                manageButton.Click += (s, e) =>
                {
                    ShowManageRequestDetails(issue);
                };

                row.Controls.Add(
                    manageButton
                );


                requestsCard.Controls.Add(
                    row
                );

                y += 72;


                // Prevent overflow from making the
                // page look broken with many records.

                if (y > requestsCard.Height - 65)
                {
                    break;
                }
            }
        }

        // =========================================================
        // SHOW MANAGE REQUESTS DETAILS
        // =========================================================
        private void ShowManageRequestDetails(Issue issue)
        {
            ClearContent();

            Panel page = CreatePage();
            pnlContent.Controls.Add(page);


            // =========================
            // BACK
            // =========================

            Button btnBack = new Button
            {
                Text = "←  Back to Manage Requests",
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = activeColor,
                Font = new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                ),
                Location = new Point(
                    32,
                    20
                ),
                Cursor = Cursors.Hand
            };

            btnBack.FlatAppearance.BorderSize = 0;

            btnBack.Click += (s, e) =>
            {
                ShowManageRequests();
            };

            page.Controls.Add(
                btnBack
            );


            // =========================
            // HEADER
            // =========================

            Label title = CreateTitle(
                $"Manage Request #{issue.Id}"
            );

            title.Location =
                new Point(32, 62);

            page.Controls.Add(
                title
            );


            Label subtitle = CreateSubtitle(
                "Review the request and update its current status."
            );

            subtitle.Location =
                new Point(34, 102);

            page.Controls.Add(
                subtitle
            );


            // =========================
            // DETAILS CARD
            // =========================

            Panel detailsCard = CreateCard(
                32,
                145,
                page.ClientSize.Width - 64,
                300
            );

            detailsCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(
                detailsCard
            );


            // CATEGORY

            Label categoryLabel =
                CreateFieldLabel("CATEGORY");

            categoryLabel.Location =
                new Point(25, 25);

            detailsCard.Controls.Add(
                categoryLabel
            );


            Label categoryValue = new Label
            {
                Text = issue.Category,
                Font = new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold
                ),
                ForeColor = normalColor,
                AutoSize = true,
                Location = new Point(
                    24,
                    48
                )
            };

            detailsCard.Controls.Add(
                categoryValue
            );


            // LOCATION

            Label locationLabel =
                CreateFieldLabel("LOCATION");

            locationLabel.Location =
                new Point(250, 25);

            detailsCard.Controls.Add(
                locationLabel
            );


            Label locationValue = new Label
            {
                Text = issue.Location,
                Font = new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold
                ),
                ForeColor = normalColor,
                AutoSize = true,
                Location = new Point(
                    249,
                    48
                )
            };

            detailsCard.Controls.Add(
                locationValue
            );


            // DESCRIPTION

            Label descriptionLabel =
                CreateFieldLabel(
                    "DESCRIPTION"
                );

            descriptionLabel.Location =
                new Point(25, 95);

            detailsCard.Controls.Add(
                descriptionLabel
            );


            Label descriptionValue = new Label
            {
                Text = issue.Description,
                Font = new Font(
                    "Segoe UI",
                    9.5F
                ),
                ForeColor = normalColor,
                AutoSize = false,
                Location = new Point(
                    24,
                    118
                ),
                Size = new Size(
                    detailsCard.Width - 48,
                    65
                ),
                Anchor =
                    AnchorStyles.Top |
                    AnchorStyles.Left |
                    AnchorStyles.Right
            };

            detailsCard.Controls.Add(
                descriptionValue
            );


            // CURRENT STATUS

            Label currentStatusLabel =
                CreateFieldLabel(
                    "CURRENT STATUS"
                );

            currentStatusLabel.Location =
                new Point(25, 205);

            detailsCard.Controls.Add(
                currentStatusLabel
            );


            Label currentStatusValue = new Label
            {
                Text = issue.Status,
                Font = new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold
                ),
                ForeColor = activeColor,
                AutoSize = true,
                Location = new Point(
                    24,
                    228
                )
            };

            detailsCard.Controls.Add(
                currentStatusValue
            );


            // =========================
            // STATUS UPDATE CARD
            // =========================

            Panel updateCard = CreateCard(
                32,
                470,
                page.ClientSize.Width - 64,
                190
            );

            updateCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(
                updateCard
            );


            Label updateTitle =
                CreateCardTitle(
                    "Update Status"
                );

            updateTitle.Location =
                new Point(24, 20);

            updateCard.Controls.Add(
                updateTitle
            );


            Label updateSubtitle =
                CreateSmallText(
                    "Choose the new status for this request."
                );

            updateSubtitle.Location =
                new Point(25, 48);

            updateCard.Controls.Add(
                updateSubtitle
            );


            // COMBOBOX

            ComboBox cmbStatus = new ComboBox
            {
                DropDownStyle =
                    ComboBoxStyle.DropDownList,
                Font = new Font(
                    "Segoe UI",
                    9.5F
                ),
                BackColor = Color.White,
                ForeColor = normalColor,
                FlatStyle = FlatStyle.Flat,
                Width = 250,
                Height = 35,
                Location = new Point(
                    25,
                    82
                )
            };

            cmbStatus.Items.AddRange(
                new object[]
                {
            "Pending",
            "In Progress",
            "Resolved"
                }
            );

            cmbStatus.SelectedItem =
                issue.Status;

            updateCard.Controls.Add(
                cmbStatus
            );


            // UPDATE BUTTON

            Button btnUpdate =
                CreatePrimaryButton(
                    "Update Status  →",
                    155,
                    40
                );

            btnUpdate.Location =
                new Point(
                    290,
                    80
                );

            btnUpdate.Click += (s, e) =>
            {
                string newStatus =
                    cmbStatus.SelectedItem?.ToString();

                if (string.IsNullOrWhiteSpace(
                    newStatus))
                {
                    MessageBox.Show(
                        "Please select a status.",
                        "Missing Status",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }


                if (newStatus == issue.Status)
                {
                    MessageBox.Show(
                        "The request is already set to this status.",
                        "No Changes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    return;
                }


                try
                {
                    IssueService service =
                        new IssueService();

                    bool updated =
                        service.UpdateIssueStatus(
                            issue.Id,
                            newStatus
                        );


                    if (!updated)
                    {
                        MessageBox.Show(
                            "The request could not be updated.",
                            "Update Failed",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );

                        return;
                    }


                    MessageBox.Show(
                        $"Request #{issue.Id} has been updated to {newStatus}.",
                        "Status Updated",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );


                    // Reload the request from DB

                    Issue updatedIssue =
                        service.GetIssueById(
                            issue.Id
                        );


                    ShowManageRequestDetails(
                        updatedIssue
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Something went wrong while updating the request.\n\n" +
                        ex.Message,
                        "Update Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            };

            updateCard.Controls.Add(
                btnUpdate
            );
        }

        // =========================================================
        // SHOW EVENTS + ANNOUNCEMENTS
        // =========================================================

        private void ShowEvents()
        {
            ClearContent();

            Panel page = CreatePage();
            page.AutoScroll = true;

            EventService eventService = new EventService();

            List<Event> allEvents =
                eventService.GetUpcomingEvents();

            // =========================================================
            // PAGE HEADER
            // =========================================================

            Label title = CreateTitle(
                "Events & Announcements");

            title.Location = new Point(32, 28);
            page.Controls.Add(title);

            Label subtitle = CreateSubtitle(
                "Discover upcoming community activities and important municipal notices.");

            subtitle.Location = new Point(32, 70);
            page.Controls.Add(subtitle);

            // =========================================================
            // SEARCH / FILTER CARD
            // =========================================================

            Panel filterCard = CreateCard(
                32,
                108,
                642,
                158);

            page.Controls.Add(filterCard);

            Label filterTitle =
                CreateCardTitle("Find something");

            filterTitle.Location =
                new Point(20, 15);

            filterCard.Controls.Add(filterTitle);

            // ---------------------------------------------------------
            // SEARCH
            // ---------------------------------------------------------

            Label searchLabel =
                CreateFieldLabel("Search");

            searchLabel.Location =
                new Point(20, 50);

            filterCard.Controls.Add(searchLabel);

            TextBox txtSearch =
                CreateTextBox("");

            txtSearch.Location =
                new Point(20, 74);

            txtSearch.Size =
                new Size(250, 30);

            filterCard.Controls.Add(txtSearch);

            Label searchHint =
                CreateSmallText(
                    "Name, location or description");

            searchHint.Location =
                new Point(20, 111);

            filterCard.Controls.Add(searchHint);

            // ---------------------------------------------------------
            // CATEGORY
            // ---------------------------------------------------------

            Label categoryLabel =
                CreateFieldLabel("Category");

            categoryLabel.Location =
                new Point(290, 50);

            filterCard.Controls.Add(categoryLabel);

            ComboBox cmbCategory = new ComboBox
            {
                Location = new Point(290, 74),
                Size = new Size(145, 30),
                Font = new Font(
                    "Segoe UI",
                    9.5F),
                DropDownStyle =
                    ComboBoxStyle.DropDownList,
                BackColor = Color.White
            };

            cmbCategory.Items.Add(
                "All Categories");

            HashSet<string> categories =
                eventService.GetUniqueCategories(
                    allEvents);

            foreach (string category in
                     categories.OrderBy(c => c))
            {
                cmbCategory.Items.Add(category);
            }

            cmbCategory.SelectedIndex = 0;

            filterCard.Controls.Add(cmbCategory);

            // ---------------------------------------------------------
            // DATE
            // ---------------------------------------------------------

            Label dateLabel =
                CreateFieldLabel("Date");

            dateLabel.Location =
                new Point(455, 50);

            filterCard.Controls.Add(dateLabel);

            DateTimePicker dtpDate =
                new DateTimePicker
                {
                    Location = new Point(455, 74),
                    Size = new Size(165, 30),
                    Font = new Font(
                        "Segoe UI",
                        9F),
                    Format =
                        DateTimePickerFormat.Short,
                    ShowCheckBox = true,
                    Checked = false
                };

            filterCard.Controls.Add(dtpDate);

            // =========================================================
            // DYNAMIC CONTENT CONTAINER
            // =========================================================

            Panel contentContainer = new Panel
            {
                Location = new Point(32, 286),
                Size = new Size(642, 100),
                BackColor = Color.Transparent
            };

            page.Controls.Add(contentContainer);

            // =========================================================
            // RENDER PAGE CONTENT
            // =========================================================

            Action renderContent = null;

            renderContent = () =>
            {
                contentContainer.Controls.Clear();

                int currentY = 0;

                string searchText =
                    txtSearch.Text.Trim();

                string selectedCategory =
                    cmbCategory.SelectedItem == null
                        ? ""
                        : cmbCategory.SelectedItem.ToString();

                if (selectedCategory ==
                    "All Categories")
                {
                    selectedCategory = "";
                }

                DateTime? selectedDate = null;

                if (dtpDate.Checked)
                {
                    selectedDate =
                        dtpDate.Value.Date;
                }

                // =====================================================
                // RECORD USER SEARCH
                // =====================================================

                if (!string.IsNullOrWhiteSpace(searchText) ||
                    !string.IsNullOrWhiteSpace(selectedCategory))
                {
                    recommendationService.RecordSearch(
                        searchText,
                        selectedCategory);
                }

                // =====================================================
                // FILTER EVENTS
                // =====================================================

                List<Event> filteredEvents =
                    eventService.SearchEvents(
                        allEvents,
                        selectedCategory,
                        selectedDate);

                // Additional text search
                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    filteredEvents =
                        filteredEvents
                            .Where(e =>
                                (e.Title != null &&
                                 e.Title.IndexOf(
                                     searchText,
                                     StringComparison.OrdinalIgnoreCase) >= 0)
                                ||
                                (e.Location != null &&
                                 e.Location.IndexOf(
                                     searchText,
                                     StringComparison.OrdinalIgnoreCase) >= 0)
                                ||
                                (e.Description != null &&
                                 e.Description.IndexOf(
                                     searchText,
                                     StringComparison.OrdinalIgnoreCase) >= 0))
                            .ToList();
                }

                // =====================================================
                // RECOMMENDATIONS
                // =====================================================

                List<Event> recommendations =
                    recommendationService
                        .GetRecommendations(
                            allEvents,
                            3);

                bool showRecommendations =
                    recommendations.Count > 0;

                if (showRecommendations)
                {
                    Label recommendationTitle =
                        CreateCardTitle(
                            "Recommended For You");

                    recommendationTitle.Location =
                        new Point(0, currentY);

                    contentContainer.Controls.Add(
                        recommendationTitle);

                    currentY += 27;

                    Label recommendationSubtitle =
                        CreateSmallText(
                            "Based on your searches and interests.");

                    recommendationSubtitle.Location =
                        new Point(0, currentY);

                    contentContainer.Controls.Add(
                        recommendationSubtitle);

                    currentY += 30;

                    foreach (Event recommendedEvent
                             in recommendations)
                    {
                        Panel recommendationCard =
                            CreateCard(
                                0,
                                currentY,
                                642,
                                82);

                        recommendationCard.Cursor =
                            Cursors.Hand;

                        // Accent bar
                        Panel accentBar =
                            new Panel
                            {
                                Width = 4,
                                Dock = DockStyle.Left,
                                BackColor = activeColor
                            };

                        recommendationCard.Controls.Add(
                            accentBar);

                        // Title
                        Label recommendedTitle =
                            CreateCardTitle(
                                recommendedEvent.Title);

                        recommendedTitle.Location =
                            new Point(20, 12);

                        recommendationCard.Controls.Add(
                            recommendedTitle);

                        // Details
                        Label recommendedDetails =
                            CreateSmallText(
                                recommendedEvent.Category +
                                "  •  " +
                                recommendedEvent.EventDate
                                    .ToString("dd MMM yyyy") +
                                "  •  " +
                                recommendedEvent.EventDate
                                    .ToString("HH:mm"));

                        recommendedDetails.Location =
                            new Point(20, 40);

                        recommendationCard.Controls.Add(
                            recommendedDetails);

                        // Location
                        Label recommendedLocation =
                            CreateSmallText(
                                recommendedEvent.Location);

                        recommendedLocation.Location =
                            new Point(20, 61);

                        recommendationCard.Controls.Add(
                            recommendedLocation);

                        recommendationCard.Click +=
                            (s, e) =>
                            {
                                viewedEvents.Push(
                                    recommendedEvent);

                                ShowEventDetails(
                                    recommendedEvent);
                            };

                        foreach (Control child
                                 in recommendationCard.Controls)
                        {
                            child.Cursor =
                                Cursors.Hand;

                            child.Click +=
                                (s, e) =>
                                {
                                    viewedEvents.Push(
                                        recommendedEvent);

                                    ShowEventDetails(
                                        recommendedEvent);
                                };
                        }

                        contentContainer.Controls.Add(
                            recommendationCard);

                        currentY += 94;
                    }

                    currentY += 18;
                }

                // =====================================================
                // UPCOMING EVENTS HEADER
                // =====================================================

                Label eventsTitle =
                    CreateCardTitle(
                        "Upcoming Events");

                eventsTitle.Location =
                    new Point(0, currentY);

                contentContainer.Controls.Add(
                    eventsTitle);

                currentY += 27;

                Label eventsSubtitle =
                    CreateSmallText(
                        filteredEvents.Count +
                        " event" +
                        (filteredEvents.Count == 1
                            ? ""
                            : "s") +
                        " matching your filters.");

                eventsSubtitle.Location =
                    new Point(0, currentY);

                contentContainer.Controls.Add(
                    eventsSubtitle);

                currentY += 30;

                // =====================================================
                // SORTED DICTIONARY
                // =====================================================

                SortedDictionary<DateTime, List<Event>>
                    eventsByDate =
                        eventService.BuildEventsByDate(
                            filteredEvents);

                foreach (KeyValuePair<DateTime, List<Event>> group
                         in eventsByDate)
                {
                    // Date separator
                    Label dateHeading =
                        new Label
                        {
                            Text = group.Key.ToString(
                                "dddd, dd MMMM yyyy"),
                            Font = new Font(
                                "Segoe UI",
                                9F,
                                FontStyle.Bold),
                            ForeColor = activeColor,
                            AutoSize = true,
                            Location =
                                new Point(0, currentY)
                        };

                    contentContainer.Controls.Add(
                        dateHeading);

                    currentY += 27;

                    foreach (Event currentEvent
                             in group.Value)
                    {
                        Panel eventCard =
                            CreateCard(
                                0,
                                currentY,
                                642,
                                100);

                        eventCard.Cursor =
                            Cursors.Hand;

                        // -------------------------------------------------
                        // PRIORITY BAR
                        // -------------------------------------------------

                        Color priorityColor;

                        switch (currentEvent.Priority)
                        {
                            case "High":
                                priorityColor =
                                    ColorTranslator.FromHtml(
                                        "#EF4444");
                                break;

                            case "Medium":
                                priorityColor =
                                    ColorTranslator.FromHtml(
                                        "#F59E0B");
                                break;

                            default:
                                priorityColor =
                                    ColorTranslator.FromHtml(
                                        "#10B981");
                                break;
                        }

                        Panel priorityBar =
                            new Panel
                            {
                                Width = 4,
                                Dock = DockStyle.Left,
                                BackColor =
                                    priorityColor
                            };

                        eventCard.Controls.Add(
                            priorityBar);

                        // -------------------------------------------------
                        // EVENT TITLE
                        // -------------------------------------------------

                        Label eventTitle =
                            CreateCardTitle(
                                currentEvent.Title);

                        eventTitle.Location =
                            new Point(22, 13);

                        eventCard.Controls.Add(
                            eventTitle);

                        // -------------------------------------------------
                        // CATEGORY
                        // -------------------------------------------------

                        Label eventCategory =
                            CreateSmallText(
                                currentEvent.Category +
                                "  •  " +
                                currentEvent.Priority +
                                " Priority");

                        eventCategory.Location =
                            new Point(22, 40);

                        eventCard.Controls.Add(
                            eventCategory);

                        // -------------------------------------------------
                        // LOCATION
                        // -------------------------------------------------

                        Label eventLocation =
                            CreateSmallText(
                                currentEvent.Location);

                        eventLocation.Location =
                            new Point(22, 65);

                        eventCard.Controls.Add(
                            eventLocation);

                        // -------------------------------------------------
                        // TIME
                        // -------------------------------------------------

                        Label eventTime =
                            CreateSmallText(
                                currentEvent.EventDate
                                    .ToString("HH:mm"));

                        eventTime.Location =
                            new Point(565, 15);

                        eventCard.Controls.Add(
                            eventTime);

                        // -------------------------------------------------
                        // CLICK
                        // -------------------------------------------------

                        eventCard.Click +=
                            (s, e) =>
                            {
                                viewedEvents.Push(
                                    currentEvent);

                                ShowEventDetails(
                                    currentEvent);
                            };

                        foreach (Control child
                                 in eventCard.Controls)
                        {
                            child.Cursor =
                                Cursors.Hand;

                            child.Click +=
                                (s, e) =>
                                {
                                    viewedEvents.Push(
                                        currentEvent);

                                    ShowEventDetails(
                                        currentEvent);
                                };
                        }

                        contentContainer.Controls.Add(
                            eventCard);

                        currentY += 112;
                    }
                }

                // =====================================================
                // NO EVENTS
                // =====================================================

                if (filteredEvents.Count == 0)
                {
                    Panel emptyCard =
                        CreateCard(
                            0,
                            currentY,
                            642,
                            95);

                    Label emptyTitle =
                        CreateCardTitle(
                            "No events found");

                    emptyTitle.Location =
                        new Point(22, 20);

                    emptyCard.Controls.Add(
                        emptyTitle);

                    Label emptyText =
                        CreateSmallText(
                            "Try changing your search or filters.");

                    emptyText.Location =
                        new Point(22, 49);

                    emptyCard.Controls.Add(
                        emptyText);

                    contentContainer.Controls.Add(
                        emptyCard);

                    currentY += 110;
                }

                // =====================================================
                // ANNOUNCEMENTS
                // =====================================================

                currentY += 18;

                Label announcementsTitle =
                    CreateCardTitle(
                        "Announcements");

                announcementsTitle.Location =
                    new Point(0, currentY);

                contentContainer.Controls.Add(
                    announcementsTitle);

                currentY += 27;

                Label announcementsSubtitle =
                    CreateSmallText(
                        "Important notices from the municipality.");

                announcementsSubtitle.Location =
                    new Point(0, currentY);

                contentContainer.Controls.Add(
                    announcementsSubtitle);

                currentY += 30;

                List<Announcement> announcements =
                    eventService.GetActiveAnnouncements();

                foreach (Announcement announcement
                         in announcements)
                {
                    Panel announcementCard =
                        CreateCard(
                            0,
                            currentY,
                            642,
                            100);

                    // Priority colour
                    Color priorityColor;

                    switch (announcement.Priority)
                    {
                        case "High":
                            priorityColor =
                                ColorTranslator.FromHtml(
                                    "#EF4444");
                            break;

                        case "Medium":
                            priorityColor =
                                ColorTranslator.FromHtml(
                                    "#F59E0B");
                            break;

                        default:
                            priorityColor =
                                ColorTranslator.FromHtml(
                                    "#10B981");
                            break;
                    }

                    Panel priorityBar =
                        new Panel
                        {
                            Width = 4,
                            Dock = DockStyle.Left,
                            BackColor =
                                priorityColor
                        };

                    announcementCard.Controls.Add(
                        priorityBar);

                    // Title
                    Label announcementTitle =
                        CreateCardTitle(
                            announcement.Title);

                    announcementTitle.Location =
                        new Point(22, 13);

                    announcementCard.Controls.Add(
                        announcementTitle);

                    // Category / priority
                    Label announcementDetails =
                        CreateSmallText(
                            announcement.Category +
                            "  •  " +
                            announcement.Priority +
                            " Priority");

                    announcementDetails.Location =
                        new Point(22, 40);

                    announcementCard.Controls.Add(
                        announcementDetails);

                    // Message
                    string message =
                        announcement.Message ?? "";

                    if (message.Length > 95)
                    {
                        message =
                            message.Substring(0, 95) +
                            "...";
                    }

                    Label announcementMessage =
                        CreateSmallText(message);

                    announcementMessage.Location =
                        new Point(22, 65);

                    announcementCard.Controls.Add(
                        announcementMessage);

                    contentContainer.Controls.Add(
                        announcementCard);

                    currentY += 112;
                }

                // =====================================================
                // NO ANNOUNCEMENTS
                // =====================================================

                if (announcements.Count == 0)
                {
                    Label noAnnouncements =
                        CreateSmallText(
                            "There are currently no active announcements.");

                    noAnnouncements.Location =
                        new Point(0, currentY + 5);

                    contentContainer.Controls.Add(
                        noAnnouncements);

                    currentY += 35;
                }

                // =====================================================
                // UPDATE CONTAINER HEIGHT
                // =====================================================

                contentContainer.Height =
                    currentY + 20;

                page.AutoScrollMinSize =
                    new Size(
                        0,
                        contentContainer.Bottom + 30);
            };

            // =========================================================
            // SEARCH / FILTER EVENTS
            // =========================================================

            txtSearch.TextChanged +=
                (s, e) =>
                {
                    renderContent();
                };

            cmbCategory.SelectedIndexChanged +=
                (s, e) =>
                {
                    renderContent();
                };

            dtpDate.ValueChanged +=
                (s, e) =>
                {
                    if (dtpDate.Checked)
                    {
                        renderContent();
                    }
                };

            dtpDate.MouseUp +=
                (s, e) =>
                {
                    renderContent();
                };

            // =========================================================
            // ADD PAGE TO MAIN CONTENT
            // =========================================================

            pnlContent.Controls.Add(page);

            // Initial render
            renderContent();
        }
        // =========================================================
        // SHOW EVENT DETAILS
        // =========================================================

        private void ShowEventDetails(Event currentEvent)
        {
            ClearContent();

            Panel page = CreatePage();

            Button btnBack = new Button
            {
                Text = "← Back to Events",
                Location = new Point(32, 28),
                Size = new Size(145, 35),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,
                ForeColor = normalColor,
                Font = new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            btnBack.FlatAppearance.BorderColor =
                borderColor;

            btnBack.Click += (s, e) =>
            {
                ShowEvents();
            };

            page.Controls.Add(btnBack);

            Label title = CreateTitle(
                currentEvent.Title);

            title.Location = new Point(32, 82);

            page.Controls.Add(title);

            Label category = CreateSmallText(
                currentEvent.Category +
                "  •  " +
                currentEvent.Priority +
                " Priority");

            category.Location = new Point(32, 125);

            page.Controls.Add(category);

            Panel detailsCard = CreateCard(
                32,
                165,
                850,
                350);

            Label dateLabel = CreateFieldLabel(
                "Date");

            dateLabel.Location =
                new Point(25, 25);

            Label dateValue = CreateSmallText(
                currentEvent.EventDate.ToString(
                    "dddd, dd MMMM yyyy • HH:mm"));

            dateValue.Location =
                new Point(25, 50);

            Label locationLabel = CreateFieldLabel(
                "Location");

            locationLabel.Location =
                new Point(25, 90);

            Label locationValue = CreateSmallText(
                currentEvent.Location);

            locationValue.Location =
                new Point(25, 115);

            Label descriptionLabel =
                CreateFieldLabel(
                    "Description");

            descriptionLabel.Location =
                new Point(25, 155);

            Label descriptionValue =
                CreateSmallText(
                    currentEvent.Description);

            descriptionValue.Location =
                new Point(25, 180);

            descriptionValue.MaximumSize =
                new Size(760, 0);

            detailsCard.Controls.Add(dateLabel);
            detailsCard.Controls.Add(dateValue);
            detailsCard.Controls.Add(locationLabel);
            detailsCard.Controls.Add(locationValue);
            detailsCard.Controls.Add(descriptionLabel);
            detailsCard.Controls.Add(descriptionValue);

            page.Controls.Add(detailsCard);

            // =========================================================
            // STACK HISTORY
            // =========================================================

            Panel historyCard = CreateCard(
                32,
                535,
                850,
                100);

            Label historyTitle =
                CreateCardTitle(
                    "Recently Viewed Events");

            historyTitle.Location =
                new Point(20, 15);

            Label historyText =
                CreateSmallText(
                    viewedEvents.Count +
                    " event(s) currently in viewing history.");

            historyText.Location =
                new Point(20, 48);

            historyCard.Controls.Add(historyTitle);
            historyCard.Controls.Add(historyText);

            page.Controls.Add(historyCard);

            pnlContent.Controls.Add(page);
        }
        
        // =========================================================
        // SETTINGS
        // =========================================================

        private void ShowSettings()
        {
            ClearContent();

            Panel page = CreatePage();

            pnlContent.Controls.Add(page);


            Label title = CreateTitle("Settings");
            title.Location = new Point(32, 28);
            page.Controls.Add(title);


            Label subtitle = CreateSubtitle(
                "Manage your application preferences."
            );

            subtitle.Location = new Point(34, 68);
            page.Controls.Add(subtitle);


            Panel settingsCard = CreateCard(
                32,
                125,
                page.ClientSize.Width - 64,
                300
            );

            settingsCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(settingsCard);


            AddSettingRow(
                settingsCard,
                "Notifications",
                "Receive updates about your municipal requests.",
                true,
                25
            );

            AddSettingRow(
                settingsCard,
                "Email updates",
                "Receive important request updates by email.",
                true,
                105
            );

            AddSettingRow(
                settingsCard,
                "Application version",
                "Municipality Service Application 2.0",
                false,
                185
            );
        }


        // =========================================================
        // PROFILE
        // =========================================================

        private void ShowProfile()
        {
            ClearContent();

            Panel page = CreatePage();

            pnlContent.Controls.Add(page);


            Label title = CreateTitle("My Profile");
            title.Location = new Point(32, 28);
            page.Controls.Add(title);


            Label subtitle = CreateSubtitle(
                "Manage your citizen profile information."
            );

            subtitle.Location = new Point(34, 68);
            page.Controls.Add(subtitle);


            Panel profileCard = CreateCard(
                32,
                125,
                page.ClientSize.Width - 64,
                340
            );

            profileCard.Anchor =
                AnchorStyles.Top |
                AnchorStyles.Left |
                AnchorStyles.Right;

            page.Controls.Add(profileCard);


            // Avatar
            Panel avatar = new Panel
            {
                Size = new Size(75, 75),
                Location = new Point(28, 28),
                BackColor = activeBackColor
            };

            ApplyRoundedCorners(avatar, 38);
            profileCard.Controls.Add(avatar);


            FontAwesome.Sharp.IconPictureBox userIcon =
    CreateIcon(
        FontAwesome.Sharp.IconChar.User,
        "#2563EB",
        28,
        22,
        22
    );
            avatar.Controls.Add(userIcon);


            Label citizen = new Label
            {
                Text = "Citizen",
                Font = new Font(
                    "Segoe UI",
                    15F,
                    FontStyle.Bold
                ),
                ForeColor = normalColor,
                AutoSize = true,
                Location = new Point(120, 32)
            };

            profileCard.Controls.Add(citizen);


            Label profileSub = CreateSmallText(
                "Your citizen account"
            );

            profileSub.Location = new Point(121, 60);
            profileCard.Controls.Add(profileSub);


            AddProfileField(
                profileCard,
                "Full Name",
                "Not provided",
                120,
                145
            );

            AddProfileField(
                profileCard,
                "Email Address",
                "Not provided",
                120,
                210
            );

            AddProfileField(
                profileCard,
                "Phone Number",
                "Not provided",
                120,
                275
            );
        }


        // =========================================================
        // SETTINGS ROW
        // =========================================================

        private void AddSettingRow(
            Panel parent,
            string title,
            string subtitle,
            bool showToggle,
            int top)
        {
            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold
                ),
                ForeColor = normalColor,
                AutoSize = true,
                Location = new Point(25, top)
            };

            parent.Controls.Add(lblTitle);


            Label lblSub = CreateSmallText(subtitle);

            lblSub.Location = new Point(25, top + 25);
            parent.Controls.Add(lblSub);


            if (showToggle)
            {
                CheckBox toggle = new CheckBox
                {
                    Appearance = Appearance.Button,
                    Text = "ON",
                    Checked = true,
                    Size = new Size(50, 27),
                    Location = new Point(
                        parent.Width - 80,
                        top + 3
                    ),
                    Anchor = AnchorStyles.Top |
                             AnchorStyles.Right,
                    FlatStyle = FlatStyle.Flat,
                    BackColor = activeColor,
                    ForeColor = Color.White,
                    Font = new Font(
                        "Segoe UI",
                        7F,
                        FontStyle.Bold
                    ),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand
                };

                toggle.FlatAppearance.BorderSize = 0;

                toggle.CheckedChanged += (s, e) =>
                {
                    toggle.Text =
                        toggle.Checked ? "ON" : "OFF";

                    toggle.BackColor =
                        toggle.Checked
                            ? activeColor
                            : ColorTranslator.FromHtml("#D1D5DB");
                };

                parent.Controls.Add(toggle);
            }
        }


        // =========================================================
        // PROFILE FIELD
        // =========================================================

        private void AddProfileField(
            Panel parent,
            string title,
            string value,
            int left,
            int top)
        {
            Label lblTitle = CreateFieldLabel(title);

            lblTitle.Location = new Point(left, top);
            parent.Controls.Add(lblTitle);


            Label lblValue = new Label
            {
                Text = value,
                Font = new Font(
                    "Segoe UI",
                    9.5F
                ),
                ForeColor = secondaryText,
                AutoSize = true,
                Location = new Point(left, top + 24)
            };

            parent.Controls.Add(lblValue);
        }


        // =========================================================
        // UI HELPERS
        // =========================================================

        private Panel CreatePage()
        {
            return new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = pageBackground,
                Padding = new Padding(32, 28, 32, 28)
            };
        }


        private Panel CreateCard(
            int x,
            int y,
            int width,
            int height)
        {
            Panel card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = Color.White
            };

            ApplyRoundedCorners(card, 14);

            return card;
        }


        private Label CreateTitle(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font(
                    "Segoe UI",
                    22F,
                    FontStyle.Bold
                ),
                ForeColor = normalColor,
                AutoSize = true
            };
        }


        private Label CreateSubtitle(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font(
                    "Segoe UI",
                    9.5F
                ),
                ForeColor = secondaryText,
                AutoSize = true
            };
        }


        private Label CreateCardTitle(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font(
                    "Segoe UI",
                    12F,
                    FontStyle.Bold
                ),
                ForeColor = normalColor,
                AutoSize = true
            };
        }


        private Label CreateSmallText(string text)
        {
            return new Label
            {
                Text = text,
                Font = new Font(
                    "Segoe UI",
                    9F
                ),
                ForeColor = secondaryText,
                AutoSize = true
            };
        }


        private Label CreateFieldLabel(string text)
        {
            return new Label
            {
                Text = text.ToUpper(),
                Font = new Font(
                    "Segoe UI",
                    8F,
                    FontStyle.Bold
                ),
                ForeColor = secondaryText,
                AutoSize = true
            };
        }


        private TextBox CreateTextBox(string placeholder)
        {
            return new TextBox
            {
                Text = placeholder,
                Font = new Font(
                    "Segoe UI",
                    9.5F
                ),
                ForeColor = secondaryText,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Height = 32
            };
        }


        private Button CreatePrimaryButton(
            string text,
            int width,
            int height)
        {
            Button button = new Button
            {
                Text = text,
                Size = new Size(width, height),
                BackColor = activeColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold
                ),
                Cursor = Cursors.Hand
            };

            button.FlatAppearance.BorderSize = 0;

            return button;
        }


        private FontAwesome.Sharp.IconPictureBox CreateIcon(
            FontAwesome.Sharp.IconChar iconChar,
            string colour,
            int size,
            int x,
            int y)
        {
            return new FontAwesome.Sharp.IconPictureBox
            {
                IconChar = iconChar,
                IconColor = ColorTranslator.FromHtml(colour),
                IconSize = size,
                Size = new Size(70, 70),
                SizeMode = PictureBoxSizeMode.CenterImage,
                Location = new Point(x, y)
            };
        }


        private Panel CreateStatCard(
            string title,
            string value,
            string subtitle,
            string accent)
        {
            Panel card = new Panel
            {
                Height = 115,
                BackColor = Color.White
            };

            ApplyRoundedCorners(card, 14);


            Panel accentBar = new Panel
            {
                Width = 4,
                Dock = DockStyle.Left,
                BackColor = ColorTranslator.FromHtml(accent)
            };

            card.Controls.Add(accentBar);


            Label lblTitle = CreateFieldLabel(title);
            lblTitle.Location = new Point(22, 18);
            card.Controls.Add(lblTitle);


            Label lblValue = new Label
            {
                Text = value,
                Font = new Font(
                    "Segoe UI",
                    24F,
                    FontStyle.Bold
                ),
                ForeColor = normalColor,
                AutoSize = true,
                Location = new Point(21, 38)
            };

            card.Controls.Add(lblValue);


            Label lblSubtitle = CreateSmallText(subtitle);
            lblSubtitle.Location = new Point(23, 82);
            card.Controls.Add(lblSubtitle);


            return card;
        }


        // =========================================================
        // ROUNDED CORNERS
        // =========================================================

        private void ApplyRoundedCorners(
            Control control,
            int radius)
        {
            control.Resize += (sender, e) =>
            {
                using (GraphicsPath path =
                    new GraphicsPath())
                {
                    Rectangle rect =
                        new Rectangle(
                            0,
                            0,
                            control.Width,
                            control.Height
                        );

                    int diameter = radius * 2;

                    if (control.Width < diameter ||
                        control.Height < diameter)
                    {
                        return;
                    }

                    path.AddArc(
                        rect.X,
                        rect.Y,
                        diameter,
                        diameter,
                        180,
                        90
                    );

                    path.AddArc(
                        rect.Right - diameter,
                        rect.Y,
                        diameter,
                        diameter,
                        270,
                        90
                    );

                    path.AddArc(
                        rect.Right - diameter,
                        rect.Bottom - diameter,
                        diameter,
                        diameter,
                        0,
                        90
                    );

                    path.AddArc(
                        rect.X,
                        rect.Bottom - diameter,
                        diameter,
                        diameter,
                        90,
                        90
                    );

                    path.CloseFigure();

                    control.Region =
                        new Region(path);
                }
            };
        }


        // =========================================================
        // CLEAR CONTENT
        // =========================================================

        private void ClearContent()
        {
            pnlContent.Controls.Clear();
        }
    }
}