namespace CodexApp
{
    partial class InstructorForm
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
            grdViewInstructor = new DataGridView();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)grdViewInstructor).BeginInit();
            SuspendLayout();
            // 
            // grdViewInstructor
            // 
            grdViewInstructor.BackgroundColor = Color.White;
            grdViewInstructor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewInstructor.Location = new Point(99, 24);
            grdViewInstructor.Name = "grdViewInstructor";
            grdViewInstructor.RowHeadersWidth = 51;
            grdViewInstructor.Size = new Size(702, 214);
            grdViewInstructor.TabIndex = 0;
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
            // InstructorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(900, 583);
            Controls.Add(btnBack);
            Controls.Add(grdViewInstructor);
            Name = "InstructorForm";
            Text = "InstructorForm";
            Load += InstructorForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewInstructor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grdViewInstructor;
        private Button btnBack;
    }
}