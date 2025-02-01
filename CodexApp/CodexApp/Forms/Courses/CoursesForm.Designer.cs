namespace CodexApp
{
    partial class CoursesForm
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
            btnAdd = new Button();
            txtCourseName = new TextBox();
            cmbCoursetype = new ComboBox();
            txtMaketingCost = new TextBox();
            txtSalesCost = new TextBox();
            txtinstCost = new TextBox();
            txtmentorCost = new TextBox();
            txtWorkspace = new TextBox();
            dptstartdata = new DateTimePicker();
            dptenddata = new DateTimePicker();
            cmbCourseInst = new ComboBox();
            cmbCourseMentor = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtRound = new TextBox();
            label12 = new Label();
            btnSave = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)grdViewCourses).BeginInit();
            SuspendLayout();
            // 
            // grdViewCourses
            // 
            grdViewCourses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grdViewCourses.BackgroundColor = Color.White;
            grdViewCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewCourses.Location = new Point(12, 12);
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
            // btnAdd
            // 
            btnAdd.Location = new Point(974, 672);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // txtCourseName
            // 
            txtCourseName.Location = new Point(918, 27);
            txtCourseName.Name = "txtCourseName";
            txtCourseName.Size = new Size(193, 27);
            txtCourseName.TabIndex = 3;
            // 
            // cmbCoursetype
            // 
            cmbCoursetype.FormattingEnabled = true;
            cmbCoursetype.Location = new Point(916, 138);
            cmbCoursetype.Name = "cmbCoursetype";
            cmbCoursetype.Size = new Size(193, 28);
            cmbCoursetype.TabIndex = 4;
            // 
            // txtMaketingCost
            // 
            txtMaketingCost.Location = new Point(916, 192);
            txtMaketingCost.Name = "txtMaketingCost";
            txtMaketingCost.Size = new Size(193, 27);
            txtMaketingCost.TabIndex = 5;
            // 
            // txtSalesCost
            // 
            txtSalesCost.Location = new Point(916, 245);
            txtSalesCost.Name = "txtSalesCost";
            txtSalesCost.Size = new Size(193, 27);
            txtSalesCost.TabIndex = 6;
            // 
            // txtinstCost
            // 
            txtinstCost.Location = new Point(916, 298);
            txtinstCost.Name = "txtinstCost";
            txtinstCost.Size = new Size(193, 27);
            txtinstCost.TabIndex = 7;
            // 
            // txtmentorCost
            // 
            txtmentorCost.Location = new Point(917, 351);
            txtmentorCost.Name = "txtmentorCost";
            txtmentorCost.Size = new Size(193, 27);
            txtmentorCost.TabIndex = 8;
            // 
            // txtWorkspace
            // 
            txtWorkspace.Location = new Point(918, 404);
            txtWorkspace.Name = "txtWorkspace";
            txtWorkspace.Size = new Size(193, 27);
            txtWorkspace.TabIndex = 8;
            // 
            // dptstartdata
            // 
            dptstartdata.Location = new Point(860, 575);
            dptstartdata.Name = "dptstartdata";
            dptstartdata.Size = new Size(250, 27);
            dptstartdata.TabIndex = 9;
            // 
            // dptenddata
            // 
            dptenddata.Location = new Point(861, 639);
            dptenddata.Name = "dptenddata";
            dptenddata.Size = new Size(250, 27);
            dptenddata.TabIndex = 10;
            // 
            // cmbCourseInst
            // 
            cmbCourseInst.FormattingEnabled = true;
            cmbCourseInst.Location = new Point(917, 457);
            cmbCourseInst.Name = "cmbCourseInst";
            cmbCourseInst.Size = new Size(193, 28);
            cmbCourseInst.TabIndex = 11;
            // 
            // cmbCourseMentor
            // 
            cmbCourseMentor.FormattingEnabled = true;
            cmbCourseMentor.Location = new Point(917, 511);
            cmbCourseMentor.Name = "cmbCourseMentor";
            cmbCourseMentor.Size = new Size(193, 28);
            cmbCourseMentor.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(918, 4);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 13;
            label1.Text = "Course Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(916, 115);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 14;
            label2.Text = "Course Type";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(918, 169);
            label3.Name = "label3";
            label3.Size = new Size(125, 20);
            label3.TabIndex = 15;
            label3.Text = "Marketing Course";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(917, 222);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 16;
            label4.Text = "Sales Cost";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(916, 275);
            label5.Name = "label5";
            label5.Size = new Size(65, 20);
            label5.TabIndex = 17;
            label5.Text = "Inst Cost";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(916, 328);
            label6.Name = "label6";
            label6.Size = new Size(90, 20);
            label6.TabIndex = 18;
            label6.Text = "Mentor Cost";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(917, 381);
            label7.Name = "label7";
            label7.Size = new Size(116, 20);
            label7.TabIndex = 19;
            label7.Text = "WorkSpace Cost";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(918, 434);
            label8.Name = "label8";
            label8.Size = new Size(77, 20);
            label8.TabIndex = 20;
            label8.Text = "Instructors";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(917, 488);
            label9.Name = "label9";
            label9.Size = new Size(63, 20);
            label9.TabIndex = 21;
            label9.Text = "Mentors";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(861, 552);
            label10.Name = "label10";
            label10.Size = new Size(76, 20);
            label10.TabIndex = 22;
            label10.Text = "Start Data";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(861, 616);
            label11.Name = "label11";
            label11.Size = new Size(70, 20);
            label11.TabIndex = 23;
            label11.Text = "End Data";
            // 
            // txtRound
            // 
            txtRound.Location = new Point(916, 85);
            txtRound.Name = "txtRound";
            txtRound.Size = new Size(193, 27);
            txtRound.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(916, 57);
            label12.Name = "label12";
            label12.Size = new Size(101, 20);
            label12.TabIndex = 25;
            label12.Text = "Course Round";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(23, 328);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 26;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(23, 381);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 27;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // CoursesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0002;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1140, 713);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(label12);
            Controls.Add(txtRound);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmbCourseMentor);
            Controls.Add(cmbCourseInst);
            Controls.Add(dptenddata);
            Controls.Add(dptstartdata);
            Controls.Add(txtWorkspace);
            Controls.Add(txtmentorCost);
            Controls.Add(txtinstCost);
            Controls.Add(txtSalesCost);
            Controls.Add(txtMaketingCost);
            Controls.Add(cmbCoursetype);
            Controls.Add(txtCourseName);
            Controls.Add(btnAdd);
            Controls.Add(btnBack);
            Controls.Add(grdViewCourses);
            Name = "CoursesForm";
            Text = "CourssesForm";
            FormClosing += CoursesForm_FormClosing;
            Load += ClassesForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewCourses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView grdViewCourses;
        private Button btnBack;
        private Button btnAdd;
        private TextBox txtCourseName;
        private ComboBox cmbCoursetype;
        private TextBox txtMaketingCost;
        private TextBox txtSalesCost;
        private TextBox txtinstCost;
        private TextBox txtmentorCost;
        private TextBox txtWorkspace;
        private DateTimePicker dptstartdata;
        private DateTimePicker dptenddata;
        private ComboBox cmbCourseInst;
        private ComboBox cmbCourseMentor;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtRound;
        private Label label12;
        private Button btnSave;
        private Button btnDelete;
    }
}