namespace CodexApp
{
    partial class SessionsForm
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
            grdViewSessions = new DataGridView();
            btnBack = new Button();
            menuStrip1 = new MenuStrip();
            viewToolStripView = new ToolStripMenuItem();
            toolStripViewTasks = new ToolStripMenuItem();
            toolStripViewQuizes = new ToolStripMenuItem();
            toolStripViewProjects = new ToolStripMenuItem();
            cmbCousres = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)grdViewSessions).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grdViewSessions
            // 
            grdViewSessions.BackgroundColor = Color.White;
            grdViewSessions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewSessions.Location = new Point(72, 31);
            grdViewSessions.Name = "grdViewSessions";
            grdViewSessions.RowHeadersWidth = 51;
            grdViewSessions.Size = new Size(745, 210);
            grdViewSessions.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 542);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { viewToolStripView });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(901, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripView
            // 
            viewToolStripView.DropDownItems.AddRange(new ToolStripItem[] { toolStripViewTasks, toolStripViewQuizes, toolStripViewProjects });
            viewToolStripView.Name = "viewToolStripView";
            viewToolStripView.Size = new Size(55, 24);
            viewToolStripView.Text = "View";
            // 
            // toolStripViewTasks
            // 
            toolStripViewTasks.Name = "toolStripViewTasks";
            toolStripViewTasks.Size = new Size(180, 26);
            toolStripViewTasks.Text = "View Tasks";
            toolStripViewTasks.Click += toolStripViewTasks_Click;
            // 
            // toolStripViewQuizes
            // 
            toolStripViewQuizes.Name = "toolStripViewQuizes";
            toolStripViewQuizes.Size = new Size(180, 26);
            toolStripViewQuizes.Text = "View Quizes";
            toolStripViewQuizes.Click += toolStripViewQuizes_Click;
            // 
            // toolStripViewProjects
            // 
            toolStripViewProjects.Name = "toolStripViewProjects";
            toolStripViewProjects.Size = new Size(180, 26);
            toolStripViewProjects.Text = "View Projects";
            toolStripViewProjects.Click += toolStripViewProjects_Click;
            // 
            // cmbCousres
            // 
            cmbCousres.FormattingEnabled = true;
            cmbCousres.Location = new Point(72, 288);
            cmbCousres.Name = "cmbCousres";
            cmbCousres.Size = new Size(151, 28);
            cmbCousres.TabIndex = 3;
            cmbCousres.SelectedIndexChanged += cmbCousres_SelectedIndexChanged;
            // 
            // SessionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(901, 583);
            Controls.Add(cmbCousres);
            Controls.Add(btnBack);
            Controls.Add(grdViewSessions);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "SessionsForm";
            Text = "SessionsForm";
            Load += SessionsForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewSessions).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdViewSessions;
        private Button btnBack;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem viewToolStripView;
        private ToolStripMenuItem toolStripViewTasks;
        private ToolStripMenuItem toolStripViewQuizes;
        private ToolStripMenuItem toolStripViewProjects;
        private ComboBox cmbCousres;
    }
}