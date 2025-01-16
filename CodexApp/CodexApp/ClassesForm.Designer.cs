namespace CodexApp
{
    partial class ClassesForm
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
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)grdViewCourses).BeginInit();
            SuspendLayout();
            // 
            // grdViewCourses
            // 
            grdViewCourses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grdViewCourses.BackgroundColor = Color.White;
            grdViewCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewCourses.Location = new Point(145, 12);
            grdViewCourses.Name = "grdViewCourses";
            grdViewCourses.RowHeadersWidth = 51;
            grdViewCourses.Size = new Size(864, 291);
            grdViewCourses.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnBack.Location = new Point(12, 672);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // ClassesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1140, 713);
            Controls.Add(btnBack);
            Controls.Add(grdViewCourses);
            Name = "ClassesForm";
            Text = "CourssesForm";
            Load += ClassesForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewCourses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grdViewCourses;
        private Button btnBack;
    }
}