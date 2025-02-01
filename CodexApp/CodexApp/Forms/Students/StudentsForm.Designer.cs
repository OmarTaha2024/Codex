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
            cmbSession = new ComboBox();
            btnView = new Button();
            button1 = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ddlPaymentType = new ComboBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtStudentName = new TextBox();
            btnAdd = new Button();
            Course = new Label();
            cmbStudents = new ComboBox();
            label6 = new Label();
            btnSearch = new Button();
            btnDelete = new Button();
            btnUpdata = new Button();
            label5 = new Label();
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
            cmbCousres.Location = new Point(47, 311);
            cmbCousres.Name = "cmbCousres";
            cmbCousres.Size = new Size(151, 28);
            cmbCousres.TabIndex = 1;
            cmbCousres.SelectedIndexChanged += cmbCousres_SelectedIndexChanged;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 687);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // cmbSession
            // 
            cmbSession.FormattingEnabled = true;
            cmbSession.Location = new Point(1017, 484);
            cmbSession.Name = "cmbSession";
            cmbSession.Size = new Size(151, 28);
            cmbSession.TabIndex = 3;
            cmbSession.SelectedIndexChanged += cmbSession_SelectedIndexChanged;
            // 
            // btnView
            // 
            btnView.Location = new Point(537, 400);
            btnView.Name = "btnView";
            btnView.Size = new Size(94, 29);
            btnView.TabIndex = 4;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // button1
            // 
            button1.Location = new Point(526, 462);
            button1.Name = "button1";
            button1.Size = new Size(119, 29);
            button1.TabIndex = 5;
            button1.Text = "View Session";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 522);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 24;
            label4.Text = "Payment Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 462);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 23;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 402);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 22;
            label2.Text = "Phone";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 342);
            label1.Name = "label1";
            label1.Size = new Size(104, 20);
            label1.TabIndex = 21;
            label1.Text = "Student Name";
            // 
            // ddlPaymentType
            // 
            ddlPaymentType.FormattingEnabled = true;
            ddlPaymentType.Location = new Point(47, 545);
            ddlPaymentType.Name = "ddlPaymentType";
            ddlPaymentType.Size = new Size(179, 28);
            ddlPaymentType.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(47, 425);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(179, 27);
            txtPhone.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(47, 485);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(179, 27);
            txtEmail.TabIndex = 4;
            // 
            // txtStudentName
            // 
            txtStudentName.Location = new Point(47, 365);
            txtStudentName.Name = "txtStudentName";
            txtStudentName.Size = new Size(179, 27);
            txtStudentName.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(88, 600);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // Course
            // 
            Course.AutoSize = true;
            Course.Location = new Point(47, 286);
            Course.Name = "Course";
            Course.Size = new Size(54, 20);
            Course.TabIndex = 27;
            Course.Text = "Course";
            // 
            // cmbStudents
            // 
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(1017, 556);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(151, 28);
            cmbStudents.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1017, 533);
            label6.Name = "label6";
            label6.Size = new Size(66, 20);
            label6.TabIndex = 29;
            label6.Text = "Students";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1037, 600);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(94, 29);
            btnSearch.TabIndex = 28;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1037, 646);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 31;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdata
            // 
            btnUpdata.Location = new Point(1060, 311);
            btnUpdata.Name = "btnUpdata";
            btnUpdata.Size = new Size(94, 29);
            btnUpdata.TabIndex = 32;
            btnUpdata.Text = "Save";
            btnUpdata.UseVisualStyleBackColor = true;
            btnUpdata.Click += btnUpdata_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1017, 461);
            label5.Name = "label5";
            label5.Size = new Size(64, 20);
            label5.TabIndex = 33;
            label5.Text = "Sessions";
            // 
            // StudentsForm
            // 
            AcceptButton = btnAdd;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1204, 728);
            Controls.Add(label5);
            Controls.Add(btnUpdata);
            Controls.Add(btnDelete);
            Controls.Add(cmbStudents);
            Controls.Add(label6);
            Controls.Add(btnSearch);
            Controls.Add(Course);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ddlPaymentType);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtStudentName);
            Controls.Add(btnAdd);
            Controls.Add(button1);
            Controls.Add(btnView);
            Controls.Add(cmbSession);
            Controls.Add(btnBack);
            Controls.Add(cmbCousres);
            Controls.Add(grdViewStudents);
            Name = "StudentsForm";
            Text = "StudentsForm";
            FormClosing += StudentsForm_FormClosing;
            Load += StudentsForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdViewStudents;
        private ComboBox cmbCousres;
        private Button btnBack;
        private ComboBox cmbSession;
        private Button btnView;
        private Button button1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox ddlPaymentType;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtStudentName;
        private Button btnAdd;
        private Label Course;
        private ComboBox cmbStudents;
        private Label label6;
        private Button btnSearch;
        private Button btnDelete;
        private Button btnUpdata;
        private Label label5;
    }
}