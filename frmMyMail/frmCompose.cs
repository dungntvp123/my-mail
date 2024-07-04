using MyMailLibrary.dao;
using MyMailLibrary.DataRepository.DeliverRepository;
using MyMailLibrary.DataRepository.MailRepository;
using MyMailLibrary.DataRepository.UserRepository;
using MyMailLibrary.entity;
using MyMailWinApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyMail
{
    public partial class frmCompose : Form
    {
        public IDeliverRepository DeliverRepository { get; set; } = null;
        public IMailRepository MailRepository { get; set; } = null;
        public IUserRepository UserRepository { get; set; } = null;

        public bool isSend;
        public Mail Draft { get; set; } = null;
        public frmCompose()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
            if (txtTo.Text != string.Empty)
            {
                isSend = true;
                Draft.Type = 1;
                this.Close();
            }
        }

        private void frmCompose_Load(object sender, EventArgs e)
        {
            txtTo.Text = string.Empty;
            foreach (Deliver deliver in DeliverRepository.GetMailDelivers(Draft.Id))
            {
                txtTo.Text += deliver.To + ", ";
            }
            txtSubject.Text = Draft.Subject;
            txtContent.Text = Draft.Content;
            isSend = false;
        }

        private void frmCompose_FormClosing(object sender, FormClosingEventArgs e)
        {
            Draft.Content = txtContent.Text;
            Draft.Subject = txtSubject.Text;
            List<string> mails = txtTo.Text.Split(",").ToList();
            if (isSend)
            {
                if (Draft.Id == 0)
                {
                    Mail added = MailRepository.AddNew(Draft);
                    foreach (string mail in mails)
                    {
                        User to = UserRepository.GetUserByMail(mail.Trim());
                        if (to != null)
                        {
                            DeliverRepository.AddNew(new Deliver
                            {
                                Id = 0,
                                Mail = added.Id,
                                To = to.Id,
                                ReadStatus = 0,
                            });
                        }
                    }
                }
                else
                {
                    MailRepository.Update(Draft);
                }
            } 
            else
            {
                if (Draft.Id == 0)
                {
                    if (txtContent.Text != string.Empty)
                    {
                        MailRepository.AddNew(Draft);
                    }
                }
                else
                {
                    MailRepository.Update(Draft);
                }
            }
        }
    }
}
