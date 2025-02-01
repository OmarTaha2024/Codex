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
            btnAdd = new Button();
            btnDelete = new Button();
            txtInstName = new TextBox();
            label1 = new Label();
            btnUpdata = new Button();
            cmbInstructors = new ComboBox();
            label2 = new Label();
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
            // btnAdd
            // 
            btnAdd.Location = new Point(120, 450);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(707, 450);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // txtInstName
            // 
            txtInstName.Location = new Point(99, 404);
            txtInstName.Name = "txtInstName";
            txtInstName.Size = new Size(175, 27);
            txtInstName.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(99, 366);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 5;
            label1.Text = "Instructor Name";
            // 
            // btnUpdata
            // 
            btnUpdata.Location = new Point(707, 259);
            btnUpdata.Name = "btnUpdata";
            btnUpdata.Size = new Size(94, 29);
            btnUpdata.TabIndex = 6;
            btnUpdata.Text = "Save";
            btnUpdata.UseVisualStyleBackColor = true;
            btnUpdata.Click += btnUpdata_Click;
            // 
            // cmbInstructors
            // 
            cmbInstructors.FormattingEnabled = true;
            cmbInstructors.Location = new Point(707, 404);
            cmbInstructors.Name = "cmbInstructors";
            cmbInstructors.Size = new Size(151, 28);
            cmbInstructors.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(707, 366);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 8;
            label2.Text = "Instructors";
            // 
            // InstructorForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(900, 583);
            Controls.Add(label2);
            Controls.Add(cmbInstructors);
            Controls.Add(btnUpdata);
            Controls.Add(label1);
            Controls.Add(txtInstName);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnBack);
            Controls.Add(grdViewInstructor);
            Name = "InstructorForm";
            Text = "InstructorForm";
            FormClosed += InstructorForm_FormClosed;
            Load += InstructorForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewInstructor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdViewInstructor;
        private Button btnBack;
        private Button btnAdd;
        private Button btnDelete;
        private TextBox txtInstName;
        private Label label1;
        private Button btnUpdata;
        private ComboBox cmbInstructors;
        private Label label2;
    }
}