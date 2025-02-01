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
            btnAdd = new Button();
            label1 = new Label();
            txtMentorName = new TextBox();
            btnDelete = new Button();
            btnUpdata = new Button();
            cmbMentors = new ComboBox();
            label2 = new Label();
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
            // btnAdd
            // 
            btnAdd.Location = new Point(82, 502);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 409);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 3;
            label1.Text = "Mentor Name";
            // 
            // txtMentorName
            // 
            txtMentorName.Location = new Point(82, 449);
            txtMentorName.Name = "txtMentorName";
            txtMentorName.Size = new Size(183, 27);
            txtMentorName.TabIndex = 4;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(743, 502);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdata
            // 
            btnUpdata.Location = new Point(743, 282);
            btnUpdata.Name = "btnUpdata";
            btnUpdata.Size = new Size(94, 29);
            btnUpdata.TabIndex = 6;
            btnUpdata.Text = "Save";
            btnUpdata.UseVisualStyleBackColor = true;
            btnUpdata.Click += btnUpdata_Click;
            // 
            // cmbMentors
            // 
            cmbMentors.FormattingEnabled = true;
            cmbMentors.Location = new Point(718, 448);
            cmbMentors.Name = "cmbMentors";
            cmbMentors.Size = new Size(151, 28);
            cmbMentors.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(718, 409);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 8;
            label2.Text = "Mentors";
            // 
            // MentorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(937, 627);
            Controls.Add(label2);
            Controls.Add(cmbMentors);
            Controls.Add(btnUpdata);
            Controls.Add(btnDelete);
            Controls.Add(txtMentorName);
            Controls.Add(label1);
            Controls.Add(btnAdd);
            Controls.Add(btnBack);
            Controls.Add(grdViewMentors);
            Name = "MentorForm";
            Text = "MentorForm";
            FormClosing += MentorForm_FormClosing;
            Load += MentorForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewMentors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdViewMentors;
        private Button btnBack;
        private Button btnAdd;
        private Label label1;
        private TextBox txtMentorName;
        private Button btnDelete;
        private Button btnUpdata;
        private ComboBox cmbMentors;
        private Label label2;
    }
}