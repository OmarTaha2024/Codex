namespace CodexApp
{
    partial class QuizesForm
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
            grdViewQuizes = new DataGridView();
            cmbCousres = new ComboBox();
            btnBack = new Button();
            cmbSession = new ComboBox();
            cmbStudents = new ComboBox();
            btnView = new Button();
            btnViewSession = new Button();
            ((System.ComponentModel.ISupportInitialize)grdViewQuizes).BeginInit();
            SuspendLayout();
            // 
            // grdViewQuizes
            // 
            grdViewQuizes.BackgroundColor = Color.White;
            grdViewQuizes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewQuizes.Location = new Point(85, 12);
            grdViewQuizes.Name = "grdViewQuizes";
            grdViewQuizes.RowHeadersWidth = 51;
            grdViewQuizes.Size = new Size(769, 222);
            grdViewQuizes.TabIndex = 0;
            // 
            // cmbCousres
            // 
            cmbCousres.FormattingEnabled = true;
            cmbCousres.Location = new Point(85, 289);
            cmbCousres.Name = "cmbCousres";
            cmbCousres.Size = new Size(151, 28);
            cmbCousres.TabIndex = 1;
            cmbCousres.SelectedIndexChanged += cmbCousres_SelectedIndexChanged;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 550);
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
            cmbSession.Location = new Point(703, 289);
            cmbSession.Name = "cmbSession";
            cmbSession.Size = new Size(151, 28);
            cmbSession.TabIndex = 3;
            cmbSession.SelectedIndexChanged += cmbSession_SelectedIndexChanged;
            // 
            // cmbStudents
            // 
            cmbStudents.FormattingEnabled = true;
            cmbStudents.Location = new Point(703, 343);
            cmbStudents.Name = "cmbStudents";
            cmbStudents.Size = new Size(151, 28);
            cmbStudents.TabIndex = 4;
            cmbStudents.SelectedIndexChanged += cmbStudents_SelectedIndexChanged;
            // 
            // btnView
            // 
            btnView.Location = new Point(423, 358);
            btnView.Name = "btnView";
            btnView.Size = new Size(94, 29);
            btnView.TabIndex = 5;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // btnViewSession
            // 
            btnViewSession.Location = new Point(423, 417);
            btnViewSession.Name = "btnViewSession";
            btnViewSession.Size = new Size(94, 29);
            btnViewSession.TabIndex = 6;
            btnViewSession.Text = "Small View";
            btnViewSession.UseVisualStyleBackColor = true;
            btnViewSession.Click += btnViewSession_Click;
            // 
            // QuizesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0003;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(943, 602);
            Controls.Add(btnViewSession);
            Controls.Add(btnView);
            Controls.Add(cmbStudents);
            Controls.Add(cmbSession);
            Controls.Add(btnBack);
            Controls.Add(cmbCousres);
            Controls.Add(grdViewQuizes);
            Name = "QuizesForm";
            Text = "QuizesForm";
            Load += QuizesForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewQuizes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grdViewQuizes;
        private ComboBox cmbCousres;
        private Button btnBack;
        private ComboBox cmbSession;
        private ComboBox cmbStudents;
        private Button btnView;
        private Button btnViewSession;
    }
}