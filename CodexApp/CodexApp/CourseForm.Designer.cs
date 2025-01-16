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
            btnBack = new Button();
            cmbCousres = new ComboBox();
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
            // btnBack
            // 
            btnBack.Location = new Point(12, 633);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // cmbCousres
            // 
            cmbCousres.FormattingEnabled = true;
            cmbCousres.Location = new Point(113, 326);
            cmbCousres.Name = "cmbCousres";
            cmbCousres.Size = new Size(151, 28);
            cmbCousres.TabIndex = 2;
            cmbCousres.SelectedIndexChanged += cmbCousres_SelectedIndexChanged;
            // 
            // CourseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1152, 674);
            Controls.Add(cmbCousres);
            Controls.Add(btnBack);
            Controls.Add(grdViewCourse);
            Name = "CourseForm";
            Text = "CourseForm";
            Load += CourseForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewCourse).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grdViewCourse;
        private Button btnBack;
        private ComboBox cmbCousres;
    }
}