namespace CodexApp
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLogin = new Button();
            Email = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.Location = new Point(199, 200);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(109, 30);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // Email
            // 
            Email.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Email.AutoSize = true;
            Email.BackColor = Color.DarkOrchid;
            Email.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Email.Location = new Point(24, 99);
            Email.Name = "Email";
            Email.Size = new Size(47, 20);
            Email.TabIndex = 4;
            Email.Text = "Email";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.DarkOrchid;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(24, 154);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPassword.Location = new Point(132, 154);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(255, 27);
            txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtUsername.Location = new Point(132, 99);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(255, 27);
            txtUsername.TabIndex = 0;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources._123;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(554, 376);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(Email);
            Controls.Add(btnLogin);
            Font = new Font("Segoe UI", 9F);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Page";
            FormClosing += Login_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Label Email;
        private Label label2;
        private TextBox txtPassword;
        private TextBox txtUsername;
    }
}
