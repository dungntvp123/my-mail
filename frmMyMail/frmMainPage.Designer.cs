namespace MyMailWinApp
{
    partial class frmMainPage
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
            gbxSideBar = new GroupBox();
            gbxUserInfo = new GroupBox();
            btnLogout = new Button();
            lblUsername = new Label();
            btnBin = new Button();
            btnSent = new Button();
            btnInbox = new Button();
            btnDraft = new Button();
            btnCompose = new Button();
            gbxNavBar = new GroupBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            dgvMailList = new DataGridView();
            btnRefresh = new Button();
            gbxSideBar.SuspendLayout();
            gbxUserInfo.SuspendLayout();
            gbxNavBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMailList).BeginInit();
            SuspendLayout();
            // 
            // gbxSideBar
            // 
            gbxSideBar.Controls.Add(gbxUserInfo);
            gbxSideBar.Controls.Add(btnBin);
            gbxSideBar.Controls.Add(btnSent);
            gbxSideBar.Controls.Add(btnInbox);
            gbxSideBar.Controls.Add(btnDraft);
            gbxSideBar.Controls.Add(btnCompose);
            gbxSideBar.Location = new Point(12, 12);
            gbxSideBar.Name = "gbxSideBar";
            gbxSideBar.Size = new Size(250, 511);
            gbxSideBar.TabIndex = 0;
            gbxSideBar.TabStop = false;
            // 
            // gbxUserInfo
            // 
            gbxUserInfo.Controls.Add(btnLogout);
            gbxUserInfo.Controls.Add(lblUsername);
            gbxUserInfo.Dock = DockStyle.Bottom;
            gbxUserInfo.Location = new Point(3, 355);
            gbxUserInfo.Name = "gbxUserInfo";
            gbxUserInfo.Size = new Size(244, 153);
            gbxUserInfo.TabIndex = 2;
            gbxUserInfo.TabStop = false;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(6, 88);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Sign out";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Arial Narrow", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblUsername.Location = new Point(6, 38);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(57, 22);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "(None)";
            // 
            // btnBin
            // 
            btnBin.Location = new Point(0, 287);
            btnBin.Name = "btnBin";
            btnBin.Size = new Size(250, 29);
            btnBin.TabIndex = 6;
            btnBin.Text = "Bin";
            btnBin.UseVisualStyleBackColor = true;
            btnBin.Click += btnBin_Click;
            // 
            // btnSent
            // 
            btnSent.Location = new Point(0, 195);
            btnSent.Name = "btnSent";
            btnSent.Size = new Size(250, 29);
            btnSent.TabIndex = 2;
            btnSent.Text = "Sent";
            btnSent.UseVisualStyleBackColor = true;
            btnSent.Click += btnSent_Click;
            // 
            // btnInbox
            // 
            btnInbox.Location = new Point(0, 151);
            btnInbox.Name = "btnInbox";
            btnInbox.Size = new Size(250, 29);
            btnInbox.TabIndex = 3;
            btnInbox.Text = "Inbox";
            btnInbox.UseVisualStyleBackColor = true;
            btnInbox.Click += btnInbox_Click;
            // 
            // btnDraft
            // 
            btnDraft.Location = new Point(0, 241);
            btnDraft.Name = "btnDraft";
            btnDraft.Size = new Size(250, 29);
            btnDraft.TabIndex = 4;
            btnDraft.Text = "Draft";
            btnDraft.UseVisualStyleBackColor = true;
            btnDraft.Click += btnDraft_Click;
            // 
            // btnCompose
            // 
            btnCompose.Location = new Point(58, 55);
            btnCompose.Name = "btnCompose";
            btnCompose.Size = new Size(130, 53);
            btnCompose.TabIndex = 5;
            btnCompose.Text = "Compose";
            btnCompose.UseVisualStyleBackColor = true;
            btnCompose.Click += btnCompose_Click;
            // 
            // gbxNavBar
            // 
            gbxNavBar.Controls.Add(btnSearch);
            gbxNavBar.Controls.Add(txtSearch);
            gbxNavBar.Location = new Point(268, 12);
            gbxNavBar.Name = "gbxNavBar";
            gbxNavBar.Size = new Size(793, 74);
            gbxNavBar.TabIndex = 1;
            gbxNavBar.TabStop = false;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(556, 25);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(158, 26);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(392, 27);
            txtSearch.TabIndex = 2;
            // 
            // dgvMailList
            // 
            dgvMailList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMailList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMailList.ColumnHeadersVisible = false;
            dgvMailList.Location = new Point(268, 163);
            dgvMailList.Name = "dgvMailList";
            dgvMailList.RowHeadersVisible = false;
            dgvMailList.RowHeadersWidth = 51;
            dgvMailList.RowTemplate.Height = 29;
            dgvMailList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMailList.Size = new Size(793, 357);
            dgvMailList.TabIndex = 2;
            dgvMailList.CellClick += dgvMailList_CellClick;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(268, 119);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // frmMainPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1073, 535);
            Controls.Add(btnRefresh);
            Controls.Add(dgvMailList);
            Controls.Add(gbxNavBar);
            Controls.Add(gbxSideBar);
            Name = "frmMainPage";
            Text = "Main Page";
            FormClosed += frmMainPage_FormClosed;
            Load += frmMainPage_Load;
            gbxSideBar.ResumeLayout(false);
            gbxUserInfo.ResumeLayout(false);
            gbxUserInfo.PerformLayout();
            gbxNavBar.ResumeLayout(false);
            gbxNavBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMailList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbxSideBar;
        private GroupBox gbxUserInfo;
        private Button btnLogout;
        private Label lblUsername;
        private Button btnSent;
        private Button btnInbox;
        private Button btnDraft;
        private Button btnCompose;
        private GroupBox gbxNavBar;
        private Button btnSearch;
        private TextBox txtSearch;
        private DataGridView dgvMailList;
        private Button btnRefresh;
        private Button btnBin;
    }
}