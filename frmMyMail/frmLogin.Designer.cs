namespace MyMail
{
    partial class frmLogin
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
            lblPassword = new Label();
            lblMail = new Label();
            txtPassword = new TextBox();
            txtMail = new TextBox();
            btnLogin = new Button();
            llbForgotPassword = new LinkLabel();
            SuspendLayout();
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(41, 83);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 0;
            lblPassword.Text = "Password";
            // 
            // lblMail
            // 
            lblMail.AutoSize = true;
            lblMail.Location = new Point(73, 29);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(38, 20);
            lblMail.TabIndex = 1;
            lblMail.Text = "Mail";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(117, 80);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(169, 27);
            txtPassword.TabIndex = 2;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(117, 29);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(169, 27);
            txtMail.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(117, 168);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // llbForgotPassword
            // 
            llbForgotPassword.AutoSize = true;
            llbForgotPassword.Location = new Point(117, 130);
            llbForgotPassword.Name = "llbForgotPassword";
            llbForgotPassword.Size = new Size(125, 20);
            llbForgotPassword.TabIndex = 5;
            llbForgotPassword.TabStop = true;
            llbForgotPassword.Text = "forgot password?";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(362, 235);
            Controls.Add(llbForgotPassword);
            Controls.Add(btnLogin);
            Controls.Add(txtMail);
            Controls.Add(txtPassword);
            Controls.Add(lblMail);
            Controls.Add(lblPassword);
            Name = "frmLogin";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPassword;
        private Label lblMail;
        private TextBox txtPassword;
        private TextBox txtMail;
        private Button btnLogin;
        private LinkLabel llbForgotPassword;
    }
}