namespace CodexApp.Forms.Sessions.Attendence
{
    partial class AttendenceForm
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
            grdViewAttendence = new DataGridView();
            btnUpdata = new Button();
            btnView = new Button();
            cmbSession = new ComboBox();
            cmbCousres = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)grdViewAttendence).BeginInit();
            SuspendLayout();
            // 
            // grdViewAttendence
            // 
            grdViewAttendence.BackgroundColor = Color.White;
            grdViewAttendence.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdViewAttendence.Location = new Point(56, 22);
            grdViewAttendence.Name = "grdViewAttendence";
            grdViewAttendence.RowHeadersWidth = 51;
            grdViewAttendence.Size = new Size(738, 242);
            grdViewAttendence.TabIndex = 0;
            // 
            // btnUpdata
            // 
            btnUpdata.Location = new Point(700, 277);
            btnUpdata.Name = "btnUpdata";
            btnUpdata.Size = new Size(94, 29);
            btnUpdata.TabIndex = 9;
            btnUpdata.Text = "Save";
            btnUpdata.UseVisualStyleBackColor = true;
            btnUpdata.Click += btnUpdata_Click;
            // 
            // btnView
            // 
            btnView.Location = new Point(421, 372);
            btnView.Name = "btnView";
            btnView.Size = new Size(94, 29);
            btnView.TabIndex = 8;
            btnView.Text = "View";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;
            // 
            // cmbSession
            // 
            cmbSession.FormattingEnabled = true;
            cmbSession.Location = new Point(662, 336);
            cmbSession.Name = "cmbSession";
            cmbSession.Size = new Size(151, 28);
            cmbSession.TabIndex = 11;
            cmbSession.SelectedIndexChanged += cmbSession_SelectedIndexChanged;
            // 
            // cmbCousres
            // 
            cmbCousres.FormattingEnabled = true;
            cmbCousres.Location = new Point(56, 336);
            cmbCousres.Name = "cmbCousres";
            cmbCousres.Size = new Size(151, 28);
            cmbCousres.TabIndex = 10;
            cmbCousres.SelectedIndexChanged += cmbCousres_SelectedIndexChanged;
            // 
            // AttendenceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.codex_logo_page_0003;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(877, 652);
            Controls.Add(cmbSession);
            Controls.Add(cmbCousres);
            Controls.Add(btnUpdata);
            Controls.Add(btnView);
            Controls.Add(grdViewAttendence);
            Name = "AttendenceForm";
            Text = "Attendence";
            FormClosing += AttendenceForm_FormClosing;
            Load += AttendenceForm_Load;
            ((System.ComponentModel.ISupportInitialize)grdViewAttendence).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView grdViewAttendence;
        private Button btnUpdata;
        private Button btnView;
        private ComboBox cmbSession;
        private ComboBox cmbCousres;
    }
}