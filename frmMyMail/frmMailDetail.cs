using MyMailLibrary.DataRepository.DeliverRepository;
using MyMailLibrary.DataRepository.MailRepository;
using MyMailLibrary.DataRepository.UserRepository;
using MyMailLibrary.entity;
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
    public partial class frmMailDetail : Form
    {
        public UserRepository UserRepository { get; set; } = null;
        public MailRepository MailRepository { get; set; } = null;
        public DeliverRepository DeliverRepository { get; set; } = null;
        public Mail Mail { get; set; } = null;
        public User User { get; set; }

        public frmMailDetail()
        {
            InitializeComponent();
        }

        private void frmMailDetail_Load(object sender, EventArgs e)
        {
            txtFrom.Text = UserRepository.GetUserById(Mail.From).Mail;
            txtTo.Text = string.Join(", ", DeliverRepository.GetMailDelivers(Mail.Id).Select(e => UserRepository.GetUserById(e.To).Mail));
            txtSubject.Text = Mail.Subject;
            txtContent.Text = Mail.Content;
            if (Mail.From == User.Id)
            {
                btnDelete.Enabled = false;
                btnReply.Enabled = false;
            }
            else
            {
                Deliver update = DeliverRepository.GetDeliver(Mail.Id, User.Id);
                if (update.ReadStatus == 0)
                {
                    update.ReadStatus = 1;
                    DeliverRepository.Update(update);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            Deliver update = DeliverRepository.GetDeliver(Mail.Id, User.Id);
            if (update.ReadStatus != -1)
            {
                update.ReadStatus = -1;
                DeliverRepository.Update(update);
            }
            else
            {
                DeliverRepository.Delete(update.Id);
            }
            this.Close();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            frmCompose frmCompose = new frmCompose
            {
                Draft = new Mail
                {
                    Id = 0,
                    From = User.Id,
                    Subject = string.Empty,
                    Content = string.Empty,
                    Type = 2,
                },
                DeliverRepository = this.DeliverRepository,
                MailRepository = this.MailRepository,
                UserRepository = this.UserRepository,
            };
            frmCompose.Show();
        }
    }
}
