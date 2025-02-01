namespace CodexApp
{
    partial class CourseForm
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
            grdViewCourse = new DataGridView();
            btnSave = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            label6 = new Label();
            cmbStudents = new ComboBox();
            btnRefresh = new Button();
            cmbCousres = new ComboBox();
            Course = new Label();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)grdViewCourse).BeginInit();
            SuspendLayout();
            // 
            // grdViewCourse
            // 
            grdViewCourse.BackgroundColor = Color.White;
            grdViewCourse.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewCourse.Location = new Point(113, 12);
            grdViewCourse.Name = "grdViewCourse";
            grdViewCourse.RowHeadersWidth = 51;
            grdViewCourse.Size = new Size(923, 267);
            grdViewCourse.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(942, 359);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(942, 415);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 17;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(886, 601);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(868, 514);
            label6.Name = "label6";
            label6.Size = new Size(66, 20);
            label6.TabIndex = 19;
            label6.Text = "Students";
            // 
            // cmbStudents
            // 
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(868, 544);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(151, 28);
            cmbStudents.TabIndex = 20;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(942, 303);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 21;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // cmbCousres
            // 
            cmbCousres.FormattingEnabled = true;
            cmbCousres.Location = new Point(113, 326);
            cmbCousres.Name = "cmbCousres";
            cmbCousres.Size = new Size(179, 28);
            cmbCousres.TabIndex = 2;
            cmbCousres.SelectedIndexChanged += cmbCousres_SelectedIndexChanged;
            // 
            // Course
            // 
            Course.AutoSize = true;
            Course.Location = new Point(113, 303);
            Course.Name = "Course";
            Course.Size = new Size(54, 20);
            Course.TabIndex = 9;
            Course.Text = "Course";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 687);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // CourseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1152, 728);
            Controls.Add(btnRefresh);
            Controls.Add(cmbStudents);
            Controls.Add(label6);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(Course);
            Controls.Add(cmbCousres);
            Controls.Add(btnBack);
            Controls.Add(grdViewCourse);
            Name = "CourseForm";
            Text = "CourseForm";
            FormClosing += CourseForm_FormClosing;
            Load += CourseForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewCourse).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdViewCourse;
        private Button btnSave;
        private Button btnDelete;
        private Button btnSearch;
        private Label label6;
        private ComboBox cmbStudents;
        private Button btnRefresh;
        private ComboBox cmbCousres;
        private Label Course;
        private Button btnBack;
    }
}