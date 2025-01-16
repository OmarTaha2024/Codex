namespace CodexApp
{
    partial class TasksForm
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
            cmbCousres = new ComboBox();
            grdViewTasks = new DataGridView();
            btnBack = new Button();
            btnView = new Button();
            btnViewSession = new Button();
            cmbStudents = new ComboBox();
            cmbSession = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)grdViewTasks).BeginInit();
            SuspendLayout();
            // 
            // cmbCousres
            // 
            cmbCousres.FormattingEnabled = true;
            cmbCousres.Location = new Point(90, 279);
            cmbCousres.Name = "cmbCousres";
            cmbCousres.Size = new Size(151, 28);
            cmbCousres.TabIndex = 0;
            cmbCousres.SelectedIndexChanged += cmbCousres_SelectedIndexChanged;
            // 
            // grdViewTasks
            // 
            grdViewTasks.BackgroundColor = Color.White;
            grdViewTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewTasks.Location = new Point(90, 12);
            grdViewTasks.Name = "grdViewTasks";
            grdViewTasks.RowHeadersWidth = 51;
            grdViewTasks.Size = new Size(803, 220);
            grdViewTasks.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 523);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnView
            // 
            btnView.Location = new Point(477, 321);
            btnView.Name = "btnView";
            btnView.Size = new Size(94, 29);
            btnView.TabIndex = 3;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // btnViewSession
            // 
            btnViewSession.Location = new Point(477, 380);
            btnViewSession.Name = "btnViewSession";
            btnViewSession.Size = new Size(94, 29);
            btnViewSession.TabIndex = 4;
            btnViewSession.Text = "Small View";
            btnViewSession.UseVisualStyleBackColor = true;
            btnViewSession.Click += btnViewSession_Click;
            // 
            // cmbStudents
            // 
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(742, 338);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(151, 28);
            cmbStudents.TabIndex = 5;
            cmbStudents.SelectedIndexChanged += cmbStudents_SelectedIndexChanged;
            // 
            // cmbSession
            // 
            cmbSession.FormattingEnabled = true;
            cmbSession.Location = new Point(742, 279);
            cmbSession.Name = "cmbSession";
            cmbSession.Size = new Size(151, 28);
            cmbSession.TabIndex = 6;
            cmbSession.SelectedIndexChanged += cmbSession_SelectedIndexChanged;
            // 
            // TasksForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0003;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(991, 573);
            Controls.Add(cmbSession);
            Controls.Add(cmbStudents);
            Controls.Add(btnViewSession);
            Controls.Add(btnView);
            Controls.Add(btnBack);
            Controls.Add(grdViewTasks);
            Controls.Add(cmbCousres);
            Name = "TasksForm";
            Text = "TasksForm";
            Load += TasksForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewTasks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbCousres;
        private DataGridView grdViewTasks;
        private Button btnBack;
        private Button btnView;
        private Button btnViewSession;
        private ComboBox cmbStudents;
        private ComboBox cmbSession;
    }
}