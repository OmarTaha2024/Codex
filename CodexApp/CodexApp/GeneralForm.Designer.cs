namespace CodexApp
{
    partial class GeneralForm
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
            grdViewCourses = new DataGridView();
            btnViewSessions = new Button();
            btnViewMentors = new Button();
            btnViewStudents = new Button();
            btnViewInstructos = new Button();
            btnViewCourse = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)grdViewCourses).BeginInit();
            SuspendLayout();
            // 
            // grdViewCourses
            // 
            grdViewCourses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grdViewCourses.BackgroundColor = Color.White;
            grdViewCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewCourses.Location = new Point(63, -1);
            grdViewCourses.Name = "grdViewCourses";
            grdViewCourses.RowHeadersWidth = 51;
            grdViewCourses.Size = new Size(673, 288);
            grdViewCourses.TabIndex = 0;
            // 
            // btnViewSessions
            // 
            btnViewSessions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnViewSessions.Location = new Point(667, 629);
            btnViewSessions.Name = "btnViewSessions";
            btnViewSessions.Size = new Size(115, 29);
            btnViewSessions.TabIndex = 1;
            btnViewSessions.Text = "View Sessions";
            btnViewSessions.UseVisualStyleBackColor = true;
            btnViewSessions.Click += btnViewSessions_Click;
            // 
            // btnViewMentors
            // 
            btnViewMentors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnViewMentors.Location = new Point(344, 561);
            btnViewMentors.Name = "btnViewMentors";
            btnViewMentors.Size = new Size(150, 29);
            btnViewMentors.TabIndex = 2;
            btnViewMentors.Text = "View Mentors";
            btnViewMentors.UseVisualStyleBackColor = true;
            btnViewMentors.Click += btnViewMentors_Click;
            // 
            // btnViewStudents
            // 
            btnViewStudents.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnViewStudents.Location = new Point(16, 629);
            btnViewStudents.Name = "btnViewStudents";
            btnViewStudents.Size = new Size(119, 29);
            btnViewStudents.TabIndex = 3;
            btnViewStudents.Text = "ViewStudents";
            btnViewStudents.UseVisualStyleBackColor = true;
            btnViewStudents.Click += btnViewStudents_Click;
            // 
            // btnViewInstructos
            // 
            btnViewInstructos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnViewInstructos.Location = new Point(344, 479);
            btnViewInstructos.Name = "btnViewInstructos";
            btnViewInstructos.Size = new Size(150, 29);
            btnViewInstructos.TabIndex = 4;
            btnViewInstructos.Text = "View Instructos";
            btnViewInstructos.UseVisualStyleBackColor = true;
            btnViewInstructos.Click += btnViewInstructos_Click;
            // 
            // btnViewCourse
            // 
            btnViewCourse.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnViewCourse.Location = new Point(16, 392);
            btnViewCourse.Name = "btnViewCourse";
            btnViewCourse.Size = new Size(119, 29);
            btnViewCourse.TabIndex = 5;
            btnViewCourse.Text = "View Course";
            btnViewCourse.UseVisualStyleBackColor = true;
            btnViewCourse.Click += btnViewCourse_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button6.Location = new Point(667, 392);
            button6.Name = "button6";
            button6.Size = new Size(115, 29);
            button6.TabIndex = 6;
            button6.Text = "View Courses";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // GeneralForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(794, 683);
            Controls.Add(button6);
            Controls.Add(btnViewCourse);
            Controls.Add(btnViewInstructos);
            Controls.Add(btnViewStudents);
            Controls.Add(btnViewMentors);
            Controls.Add(btnViewSessions);
            Controls.Add(grdViewCourses);
            Name = "GeneralForm";
            Text = "GeneralForm";
            Load += GeneralForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewCourses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grdViewCourses;
        private Button btnViewSessions;
        private Button btnViewMentors;
        private Button btnViewStudents;
        private Button btnViewInstructos;
        private Button btnViewCourse;
        private Button button6;
    }
}