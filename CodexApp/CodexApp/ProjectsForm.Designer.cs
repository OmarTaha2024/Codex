namespace CodexApp
{
    partial class ProjectsForm
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
            grdViewProjects = new DataGridView();
            cmbCousres = new ComboBox();
            btnBack = new Button();
            cmbSession = new ComboBox();
            btnView = new Button();
            cmbStudents = new ComboBox();
            btnViewSession = new Button();
            ((System.ComponentModel.ISupportInitialize)grdViewProjects).BeginInit();
            SuspendLayout();
            // 
            // grdViewProjects
            // 
            grdViewProjects.BackgroundColor = Color.White;
            grdViewProjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewProjects.Location = new Point(70, 12);
            grdViewProjects.Name = "grdViewProjects";
            grdViewProjects.RowHeadersWidth = 51;
            grdViewProjects.Size = new Size(758, 206);
            grdViewProjects.TabIndex = 0;
            // 
            // cmbCousres
            // 
            cmbCousres.FormattingEnabled = true;
            cmbCousres.Location = new Point(70, 260);
            cmbCousres.Name = "cmbCousres";
            cmbCousres.Size = new Size(151, 28);
            cmbCousres.TabIndex = 1;
            cmbCousres.SelectedIndexChanged += cmbCousres_SelectedIndexChanged;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 503);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // cmbSession
            // 
            cmbSession.FormattingEnabled = true;
            cmbSession.Location = new Point(677, 260);
            cmbSession.Name = "cmbSession";
            cmbSession.Size = new Size(151, 28);
            cmbSession.TabIndex = 3;
            cmbSession.SelectedIndexChanged += cmbSession_SelectedIndexChanged;
            // 
            // btnView
            // 
            btnView.Location = new Point(404, 324);
            btnView.Name = "btnView";
            btnView.Size = new Size(94, 29);
            btnView.TabIndex = 4;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // cmbStudents
            // 
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(677, 325);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(151, 28);
            cmbStudents.TabIndex = 5;
            cmbStudents.SelectedIndexChanged += cmbStudents_SelectedIndexChanged;
            // 
            // btnViewSession
            // 
            btnViewSession.Location = new Point(392, 377);
            btnViewSession.Name = "btnViewSession";
            btnViewSession.Size = new Size(119, 29);
            btnViewSession.TabIndex = 6;
            btnViewSession.Text = "Small View";
            btnViewSession.UseVisualStyleBackColor = true;
            btnViewSession.Click += btnViewSession_Click;
            // 
            // ProjectsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0003;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(903, 544);
            Controls.Add(btnViewSession);
            Controls.Add(cmbStudents);
            Controls.Add(btnView);
            Controls.Add(cmbSession);
            Controls.Add(btnBack);
            Controls.Add(cmbCousres);
            Controls.Add(grdViewProjects);
            Name = "ProjectsForm";
            Text = "ProjectsForm";
            Load += ProjectsForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewProjects).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grdViewProjects;
        private ComboBox cmbCousres;
        private Button btnBack;
        private ComboBox cmbSession;
        private Button btnView;
        private ComboBox cmbStudents;
        private Button btnViewSession;
    }
}