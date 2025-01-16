namespace CodexApp
{
    partial class MentorForm
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
            grdViewMentors = new DataGridView();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)grdViewMentors).BeginInit();
            SuspendLayout();
            // 
            // grdViewMentors
            // 
            grdViewMentors.BackgroundColor = Color.White;
            grdViewMentors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewMentors.Location = new Point(108, 12);
            grdViewMentors.Name = "grdViewMentors";
            grdViewMentors.RowHeadersWidth = 51;
            grdViewMentors.Size = new Size(729, 237);
            grdViewMentors.TabIndex = 0;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(22, 586);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 1;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // MentorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(937, 627);
            Controls.Add(btnBack);
            Controls.Add(grdViewMentors);
            Name = "MentorForm";
            Text = "MentorForm";
            Load += MentorForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewMentors).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grdViewMentors;
        private Button btnBack;
    }
}