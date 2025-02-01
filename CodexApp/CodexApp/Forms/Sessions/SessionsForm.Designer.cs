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
            viewAttendenceToolStripMenuItem = new ToolStripMenuItem();
            cmbCousres = new ComboBox();
            btnAdd = new Button();
            txtMatrialLink = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnSave = new Button();
            btnDelete = new Button();
            txtSessionName = new TextBox();
            txtnewMaterial = new TextBox();
            label4 = new Label();
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
            grdViewSessions.CellContentClick += grdViewSessions_CellContentClick;
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
            viewToolStripView.DropDownItems.AddRange(new ToolStripItem[] { toolStripViewTasks, toolStripViewQuizes, toolStripViewProjects, viewAttendenceToolStripMenuItem });
            viewToolStripView.Name = "viewToolStripView";
            viewToolStripView.Size = new Size(55, 24);
            viewToolStripView.Text = "View";
            // 
            // toolStripViewTasks
            // 
            toolStripViewTasks.Name = "toolStripViewTasks";
            toolStripViewTasks.Size = new Size(204, 26);
            toolStripViewTasks.Text = "View Tasks";
            toolStripViewTasks.Click += toolStripViewTasks_Click;
            // 
            // toolStripViewQuizes
            // 
            toolStripViewQuizes.Name = "toolStripViewQuizes";
            toolStripViewQuizes.Size = new Size(204, 26);
            toolStripViewQuizes.Text = "View Quizes";
            toolStripViewQuizes.Click += toolStripViewQuizes_Click;
            // 
            // toolStripViewProjects
            // 
            toolStripViewProjects.Name = "toolStripViewProjects";
            toolStripViewProjects.Size = new Size(204, 26);
            toolStripViewProjects.Text = "View Projects";
            toolStripViewProjects.Click += toolStripViewProjects_Click;
            // 
            // viewAttendenceToolStripMenuItem
            // 
            viewAttendenceToolStripMenuItem.Name = "viewAttendenceToolStripMenuItem";
            viewAttendenceToolStripMenuItem.Size = new Size(204, 26);
            viewAttendenceToolStripMenuItem.Text = "View Attendence";
            viewAttendenceToolStripMenuItem.Click += viewAttendenceToolStripMenuItem_Click;
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
            // btnAdd
            // 
            btnAdd.Location = new Point(72, 467);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add Session ";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtMatrialLink
            // 
            txtMatrialLink.Location = new Point(72, 414);
            txtMatrialLink.Name = "txtMatrialLink";
            txtMatrialLink.Size = new Size(158, 27);
            txtMatrialLink.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 391);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 7;
            label1.Text = "Session Link";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 265);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 8;
            label2.Text = "Courses";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 328);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 9;
            label3.Text = "Session Name";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(723, 324);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(723, 370);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtSessionName
            // 
            txtSessionName.Location = new Point(72, 351);
            txtSessionName.Name = "txtSessionName";
            txtSessionName.Size = new Size(151, 27);
            txtSessionName.TabIndex = 6;
            // 
            // txtnewMaterial
            // 
            txtnewMaterial.Location = new Point(698, 289);
            txtnewMaterial.Name = "txtnewMaterial";
            txtnewMaterial.Size = new Size(151, 27);
            txtnewMaterial.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(698, 256);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 13;
            label4.Text = "New Material";
            // 
            // SessionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(901, 583);
            Controls.Add(label4);
            Controls.Add(txtnewMaterial);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSessionName);
            Controls.Add(txtMatrialLink);
            Controls.Add(btnAdd);
            Controls.Add(cmbCousres);
            Controls.Add(btnBack);
            Controls.Add(grdViewSessions);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "SessionsForm";
            Text = "SessionsForm";
            FormClosing += SessionsForm_FormClosing;
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
        private Button btnAdd;
        private TextBox txtMatrialLink;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnSave;
        private Button btnDelete;
        private TextBox txtSessionName;
        private TextBox txtnewMaterial;
        private Label label4;
        private ToolStripMenuItem viewAttendenceToolStripMenuItem;
    }
}