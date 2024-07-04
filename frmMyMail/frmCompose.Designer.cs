namespace MyMail
{
    partial class frmCompose
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
            txtTo = new TextBox();
            txtSubject = new TextBox();
            txtContent = new TextBox();
            btnSubject = new Label();
            lbTo = new Label();
            btnSend = new Button();
            SuspendLayout();
            // 
            // txtTo
            // 
            txtTo.Location = new Point(79, 12);
            txtTo.Multiline = true;
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(709, 54);
            txtTo.TabIndex = 0;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(79, 89);
            txtSubject.Name = "txtSubject";
            txtSubject.Size = new Size(709, 27);
            txtSubject.TabIndex = 1;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(12, 131);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(776, 261);
            txtContent.TabIndex = 2;
            // 
            // btnSubject
            // 
            btnSubject.AutoSize = true;
            btnSubject.Location = new Point(15, 92);
            btnSubject.Name = "btnSubject";
            btnSubject.Size = new Size(58, 20);
            btnSubject.TabIndex = 3;
            btnSubject.Text = "Subject";
            // 
            // lbTo
            // 
            lbTo.AutoSize = true;
            lbTo.Location = new Point(48, 15);
            lbTo.Name = "lbTo";
            lbTo.Size = new Size(25, 20);
            lbTo.TabIndex = 4;
            lbTo.Text = "To";
            // 
            // btnSend
            // 
            btnSend.Location = new Point(15, 398);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 40);
            btnSend.TabIndex = 5;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // frmCompose
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSend);
            Controls.Add(lbTo);
            Controls.Add(btnSubject);
            Controls.Add(txtContent);
            Controls.Add(txtSubject);
            Controls.Add(txtTo);
            Name = "frmCompose";
            Text = "New Message";
            FormClosing += frmCompose_FormClosing;
            Load += frmCompose_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTo;
        private TextBox txtSubject;
        private TextBox txtContent;
        private Label btnSubject;
        private Label lbTo;
        private Button btnSend;
    }
}