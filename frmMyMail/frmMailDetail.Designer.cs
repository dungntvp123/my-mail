namespace MyMail
{
    partial class frmMailDetail
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
            txtFrom = new TextBox();
            txtSubject = new TextBox();
            txtTo = new TextBox();
            txtContent = new TextBox();
            lblSubject = new Label();
            lbTo = new Label();
            lblFrom = new Label();
            btnDelete = new Button();
            btnReply = new Button();
            SuspendLayout();
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(73, 12);
            txtFrom.Name = "txtFrom";
            txtFrom.ReadOnly = true;
            txtFrom.Size = new Size(243, 27);
            txtFrom.TabIndex = 0;
            // 
            // txtSubject
            // 
            txtSubject.Location = new Point(73, 81);
            txtSubject.Name = "txtSubject";
            txtSubject.ReadOnly = true;
            txtSubject.Size = new Size(715, 27);
            txtSubject.TabIndex = 1;
            // 
            // txtTo
            // 
            txtTo.Location = new Point(373, 12);
            txtTo.Multiline = true;
            txtTo.Name = "txtTo";
            txtTo.ReadOnly = true;
            txtTo.Size = new Size(415, 54);
            txtTo.TabIndex = 2;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(12, 127);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.ReadOnly = true;
            txtContent.Size = new Size(776, 160);
            txtContent.TabIndex = 3;
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Location = new Point(12, 84);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(58, 20);
            lblSubject.TabIndex = 6;
            lblSubject.Text = "Subject";
            // 
            // lbTo
            // 
            lbTo.AutoSize = true;
            lbTo.Location = new Point(342, 15);
            lbTo.Name = "lbTo";
            lbTo.Size = new Size(25, 20);
            lbTo.TabIndex = 7;
            lbTo.Text = "To";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Location = new Point(12, 15);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new Size(43, 20);
            lblFrom.TabIndex = 8;
            lblFrom.Text = "From";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(594, 293);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnReply
            // 
            btnReply.Location = new Point(694, 293);
            btnReply.Name = "btnReply";
            btnReply.Size = new Size(94, 29);
            btnReply.TabIndex = 10;
            btnReply.Text = "Reply";
            btnReply.UseVisualStyleBackColor = true;
            btnReply.Click += btnReply_Click;
            // 
            // frmMailDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 329);
            Controls.Add(btnReply);
            Controls.Add(btnDelete);
            Controls.Add(lblFrom);
            Controls.Add(lbTo);
            Controls.Add(lblSubject);
            Controls.Add(txtContent);
            Controls.Add(txtTo);
            Controls.Add(txtSubject);
            Controls.Add(txtFrom);
            Name = "frmMailDetail";
            Text = "MailDetail";
            Load += frmMailDetail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFrom;
        private TextBox txtSubject;
        private TextBox txtTo;
        private TextBox txtContent;
        private Label lblSubject;
        private Label lbTo;
        private Label lblFrom;
        private Button btnDelete;
        private Button btnReply;
    }
}