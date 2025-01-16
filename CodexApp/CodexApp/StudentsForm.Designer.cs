namespace CodexApp
{
    partial class StudentsForm
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
            grdViewStudents = new DataGridView();
            cmbCousres = new ComboBox();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)grdViewStudents).BeginInit();
            SuspendLayout();
            // 
            // grdViewStudents
            // 
            grdViewStudents.BackgroundColor = Color.White;
            grdViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewStudents.Location = new Point(47, 12);
            grdViewStudents.Name = "grdViewStudents";
            grdViewStudents.RowHeadersWidth = 51;
            grdViewStudents.Size = new Size(1107, 271);
            grdViewStudents.TabIndex = 0;
            // 
            // cmbCousres
            // 
            cmbCousres.FormattingEnabled = true;
            cmbCousres.Location = new Point(47, 332);
            cmbCousres.Name = "cmbCousres";
            cmbCousres.Size = new Size(151, 28);
            cmbCousres.TabIndex = 1;
            cmbCousres.SelectedIndexChanged += cmbCousres_SelectedIndexChanged;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 661);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // StudentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1204, 702);
            Controls.Add(btnBack);
            Controls.Add(cmbCousres);
            Controls.Add(grdViewStudents);
            Name = "StudentsForm";
            Text = "StudentsForm";
            Load += StudentsForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewStudents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grdViewStudents;
        private ComboBox cmbCousres;
        private Button btnBack;
    }
}