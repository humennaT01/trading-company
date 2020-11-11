namespace CompanyWF
{
    partial class AdminForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isBlockedCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.infoCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.showAllActiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activeUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blockedUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.label1 = new System.Windows.Forms.Label();
            this.findByLogin = new System.Windows.Forms.TextBox();
            this.findByEmail = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Bisque;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserId,
            this.Login,
            this.emailCol,
            this.isBlockedCol,
            this.infoCol});
            this.dataGridView2.Location = new System.Drawing.Point(12, 60);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(712, 375);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // UserId
            // 
            this.UserId.HeaderText = "UserId";
            this.UserId.MinimumWidth = 6;
            this.UserId.Name = "UserId";
            this.UserId.Width = 55;
            // 
            // Login
            // 
            this.Login.HeaderText = "Login";
            this.Login.MinimumWidth = 6;
            this.Login.Name = "Login";
            this.Login.Width = 90;
            // 
            // emailCol
            // 
            this.emailCol.HeaderText = "Email";
            this.emailCol.MinimumWidth = 6;
            this.emailCol.Name = "emailCol";
            this.emailCol.Width = 170;
            // 
            // isBlockedCol
            // 
            this.isBlockedCol.HeaderText = "IsBlocked";
            this.isBlockedCol.MinimumWidth = 6;
            this.isBlockedCol.Name = "isBlockedCol";
            this.isBlockedCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isBlockedCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isBlockedCol.Width = 70;
            // 
            // infoCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            this.infoCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.infoCol.HeaderText = "PersonInfo";
            this.infoCol.MinimumWidth = 6;
            this.infoCol.Name = "infoCol";
            this.infoCol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.infoCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.infoCol.Text = "Info";
            this.infoCol.Width = 90;
            // 
            // userBindingSource
            // 
            this.userBindingSource.CurrentChanged += new System.EventHandler(this.userBindingSource_CurrentChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllActiveToolStripMenuItem,
            this.sortByToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(766, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(103, 447);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // showAllActiveToolStripMenuItem
            // 
            this.showAllActiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeUsersToolStripMenuItem,
            this.blockedUsersToolStripMenuItem,
            this.allToolStripMenuItem});
            this.showAllActiveToolStripMenuItem.Name = "showAllActiveToolStripMenuItem";
            this.showAllActiveToolStripMenuItem.Size = new System.Drawing.Size(90, 40);
            this.showAllActiveToolStripMenuItem.Text = "Show";
            // 
            // activeUsersToolStripMenuItem
            // 
            this.activeUsersToolStripMenuItem.BackColor = System.Drawing.Color.Gainsboro;
            this.activeUsersToolStripMenuItem.Name = "activeUsersToolStripMenuItem";
            this.activeUsersToolStripMenuItem.Size = new System.Drawing.Size(222, 40);
            this.activeUsersToolStripMenuItem.Text = "Active users";
            this.activeUsersToolStripMenuItem.Click += new System.EventHandler(this.activeUsersToolStripMenuItem_Click);
            // 
            // blockedUsersToolStripMenuItem
            // 
            this.blockedUsersToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.blockedUsersToolStripMenuItem.Name = "blockedUsersToolStripMenuItem";
            this.blockedUsersToolStripMenuItem.Size = new System.Drawing.Size(222, 40);
            this.blockedUsersToolStripMenuItem.Text = "Blocked users";
            this.blockedUsersToolStripMenuItem.Click += new System.EventHandler(this.blockedUsersToolStripMenuItem_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(222, 40);
            this.allToolStripMenuItem.Text = "All";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.allToolStripMenuItem_Click);
            // 
            // sortByToolStripMenuItem
            // 
            this.sortByToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byEmailToolStripMenuItem,
            this.byLoginToolStripMenuItem});
            this.sortByToolStripMenuItem.Name = "sortByToolStripMenuItem";
            this.sortByToolStripMenuItem.Size = new System.Drawing.Size(90, 40);
            this.sortByToolStripMenuItem.Text = "Sort";
            // 
            // byEmailToolStripMenuItem
            // 
            this.byEmailToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.byEmailToolStripMenuItem.Name = "byEmailToolStripMenuItem";
            this.byEmailToolStripMenuItem.Size = new System.Drawing.Size(177, 40);
            this.byEmailToolStripMenuItem.Text = "By email";
            this.byEmailToolStripMenuItem.Click += new System.EventHandler(this.byEmailToolStripMenuItem_Click);
            // 
            // byLoginToolStripMenuItem
            // 
            this.byLoginToolStripMenuItem.BackColor = System.Drawing.Color.LightGray;
            this.byLoginToolStripMenuItem.Name = "byLoginToolStripMenuItem";
            this.byLoginToolStripMenuItem.Size = new System.Drawing.Size(177, 40);
            this.byLoginToolStripMenuItem.Text = "By login";
            this.byLoginToolStripMenuItem.Click += new System.EventHandler(this.byLoginToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.saveToolStripMenuItem.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveToolStripMenuItem.ForeColor = System.Drawing.Color.ForestGreen;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(90, 40);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.BackColor = System.Drawing.Color.Brown;
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(90, 40);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "FindBy:";
            // 
            // findByLogin
            // 
            this.findByLogin.Location = new System.Drawing.Point(120, 18);
            this.findByLogin.Multiline = true;
            this.findByLogin.Name = "findByLogin";
            this.findByLogin.Size = new System.Drawing.Size(114, 28);
            this.findByLogin.TabIndex = 4;
            this.findByLogin.TabStop = false;
            this.findByLogin.Text = "Login";
            this.findByLogin.TextChanged += new System.EventHandler(this.findByLogin_TextChanged);
            // 
            // findByEmail
            // 
            this.findByEmail.Location = new System.Drawing.Point(266, 18);
            this.findByEmail.Multiline = true;
            this.findByEmail.Name = "findByEmail";
            this.findByEmail.Size = new System.Drawing.Size(160, 28);
            this.findByEmail.TabIndex = 5;
            this.findByEmail.Text = "Email";
            this.findByEmail.TextChanged += new System.EventHandler(this.findByEmail_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.OliveDrab;
            this.button1.Location = new System.Drawing.Point(448, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(869, 447);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.findByEmail);
            this.Controls.Add(this.findByLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showAllActiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activeUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blockedUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isBlockedCol;
        private System.Windows.Forms.DataGridViewButtonColumn infoCol;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox findByLogin;
        private System.Windows.Forms.TextBox findByEmail;
        private System.Windows.Forms.Button button1;
    }
}