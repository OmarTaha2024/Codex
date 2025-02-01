namespace CodexApp
{
    partial class TasksForm
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
            cmbCousres = new ComboBox();
            grdViewTasks = new DataGridView();
            btnBack = new Button();
            btnView = new Button();
            btnViewSession = new Button();
            cmbStudents = new ComboBox();
            cmbSession = new ComboBox();
            btnUpdata = new Button();
            btnsmallUpdata = new Button();
            ((System.ComponentModel.ISupportInitialize)grdViewTasks).BeginInit();
            SuspendLayout();
            // 
            // cmbCousres
            // 
            cmbCousres.FormattingEnabled = true;
            cmbCousres.Location = new Point(90, 279);
            cmbCousres.Name = "cmbCousres";
            cmbCousres.Size = new Size(151, 28);
            cmbCousres.TabIndex = 0;
            cmbCousres.SelectedIndexChanged += cmbCousres_SelectedIndexChanged;
            // 
            // grdViewTasks
            // 
            grdViewTasks.BackgroundColor = Color.White;
            grdViewTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewTasks.Location = new Point(90, 12);
            grdViewTasks.Name = "grdViewTasks";
            grdViewTasks.RowHeadersWidth = 51;
            grdViewTasks.Size = new Size(803, 220);
            grdViewTasks.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 523);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(94, 29);
            btnBack.TabIndex = 2;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnView
            // 
            btnView.Location = new Point(432, 319);
            btnView.Name = "btnView";
            btnView.Size = new Size(94, 29);
            btnView.TabIndex = 3;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // btnViewSession
            // 
            btnViewSession.Location = new Point(432, 372);
            btnViewSession.Name = "btnViewSession";
            btnViewSession.Size = new Size(94, 29);
            btnViewSession.TabIndex = 4;
            btnViewSession.Text = "Small View";
            btnViewSession.UseVisualStyleBackColor = true;
            btnViewSession.Click += btnViewSession_Click;
            // 
            // cmbStudents
            // 
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(742, 338);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(151, 28);
            cmbStudents.TabIndex = 5;
            cmbStudents.SelectedIndexChanged += cmbStudents_SelectedIndexChanged;
            // 
            // cmbSession
            // 
            cmbSession.FormattingEnabled = true;
            cmbSession.Location = new Point(742, 279);
            cmbSession.Name = "cmbSession";
            cmbSession.Size = new Size(151, 28);
            cmbSession.TabIndex = 6;
            cmbSession.SelectedIndexChanged += cmbSession_SelectedIndexChanged;
            // 
            // btnUpdata
            // 
            btnUpdata.Location = new Point(559, 319);
            btnUpdata.Name = "btnUpdata";
            btnUpdata.Size = new Size(94, 29);
            btnUpdata.TabIndex = 7;
            btnUpdata.Text = "Updata";
            btnUpdata.UseVisualStyleBackColor = true;
            btnUpdata.Click += btnUpdata_Click;
            // 
            // btnsmallUpdata
            // 
            btnsmallUpdata.Location = new Point(540, 372);
            btnsmallUpdata.Name = "btnsmallUpdata";
            btnsmallUpdata.Size = new Size(113, 29);
            btnsmallUpdata.TabIndex = 8;
            btnsmallUpdata.Text = "Small Updata";
            btnsmallUpdata.UseVisualStyleBackColor = true;
            btnsmallUpdata.Click += btnsmallUpdata_Click;
            // 
            // TasksForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0003;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(991, 573);
            Controls.Add(btnsmallUpdata);
            Controls.Add(btnUpdata);
            Controls.Add(cmbSession);
            Controls.Add(cmbStudents);
            Controls.Add(btnViewSession);
            Controls.Add(btnView);
            Controls.Add(btnBack);
            Controls.Add(grdViewTasks);
            Controls.Add(cmbCousres);
            Name = "TasksForm";
            Text = "TasksForm";
            FormClosing += TasksForm_FormClosing;
            Load += TasksForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewTasks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbCousres;
        private DataGridView grdViewTasks;
        private Button btnBack;
        private Button btnView;
        private Button btnViewSession;
        private ComboBox cmbStudents;
        private ComboBox cmbSession;
        private Button btnUpdata;
        private Button btnsmallUpdata;
    }
}