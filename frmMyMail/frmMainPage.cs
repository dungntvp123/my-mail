using MyMail;
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

namespace MyMailWinApp
{
    public partial class frmMainPage : Form
    {
        public DeliverRepository DeliverRepository { get; set; } = null;
        public MailRepository MailRepository { get; set; } = null;
        public UserRepository UserRepository { get; set; } = null;
        public frmLogin frmLogin { get; set; }
        private int action = 0;
        public User User { get; set; } = null;
        private List<Mail> data = null;
        public frmMainPage()
        {
            InitializeComponent();
        }

        private void frmMainPage_Load(object sender, EventArgs e)
        {
            lblUsername.Text = User.Username;
            btnInbox_Click(sender, e);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            User = null;
            frmLogin.Show();
            this.Close();
        }

        private void btnCompose_Click(object sender, EventArgs e)
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
            frmCompose.ShowDialog();
        }

        private void btnInbox_Click(object sender, EventArgs e)
        {
            action = 1;
            data = new List<Mail>();

            foreach (Deliver deliver in DeliverRepository.GetUserDeliversByMailType(User.Id, 1, 0))
            {
                data.Add(MailRepository.GetMailById(deliver.Mail));
            }

            foreach (Deliver deliver in DeliverRepository.GetUserDeliversByMailType(User.Id, 1, 1))
            {
                data.Add(MailRepository.GetMailById(deliver.Mail));
            }

            showDGV();
        }

        private void frmMainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            User = null;
            frmLogin.Show();
        }

        private void btnSent_Click(object sender, EventArgs e)
        {
            action = 2;
            data = new List<Mail>();

            foreach (Mail mail in MailRepository.GetMailList(User.Id, 1))
            {
                data.Add(mail);
            }

            showDGV();
        }

        private void btnDraft_Click(object sender, EventArgs e)
        {
            action = 3;
            data = new List<Mail>();

            foreach (Mail mail in MailRepository.GetMailList(User.Id, 2))
            {
                data.Add(mail);
            }

            showDGV();
        }

        private void dgvMailList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Mail mail = MailRepository.GetMailById((int)dgvMailList.SelectedRows[0].Cells[0].Value);

            if (mail.Type != 2)
            {
                frmMailDetail frmMailDetail = new frmMailDetail
                {
                    Mail = mail,
                    DeliverRepository = this.DeliverRepository,
                    MailRepository = this.MailRepository,
                    UserRepository = this.UserRepository,
                    User = this.User,
                };

                frmMailDetail.Show();
            }
            else
            {
                frmCompose frmCompose = new frmCompose
                {
                    Draft = mail,
                    DeliverRepository = this.DeliverRepository,
                    MailRepository = this.MailRepository,
                    UserRepository = this.UserRepository,
                };

                frmCompose.Show();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            switch (action)
            {
                case 1: btnInbox_Click(sender, e); break;
                case 2: btnSent_Click(sender, e); break;
                case 3: btnDraft_Click(sender, e); break;
                case 4: btnBin_Click(sender, e); break;
            }
        }

        private void btnBin_Click(object sender, EventArgs e)
        {
            action = 4;
            data = new List<Mail>();

            foreach (Deliver deliver in DeliverRepository.GetUserDeliversByMailType(User.Id, 1, -1))
            {
                data.Add(MailRepository.GetMailById(deliver.Mail));
            }

            showDGV();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text;
            data = data.Where(o => (key != string.Empty ? o.Subject.Contains(key) : o.Subject.Equals(key))).ToList();
            showDGV();
        }

        private void showDGV()
        {
            switch (action)
            {
                case 1:
                    dgvMailList.DataSource = data.Select(o => new
                    {
                        MailId = o.Id,
                        From = "From: " + UserRepository.GetUserById(o.From).Mail,
                        Subject = "Subject: " + o.Subject,
                    }).ToList();
                    dgvMailList.Columns[0].Visible = false;
                    dgvMailList.Columns[1].Width = 180;
                    break;
                case 2:
                    dgvMailList.DataSource = data.Select(o => new
                    {
                        MailId = o.Id,
                        To = "To: " + string.Join(", ", DeliverRepository.GetMailDelivers(o.Id).Select(e => UserRepository.GetUserById(e.To).Mail)),
                        Subject = "Subject: " + (o.Subject == string.Empty ? "(None Subject)" : o.Subject),
                    }).ToList();
                    dgvMailList.Columns[0].Visible = false;
                    dgvMailList.Columns[1].Width = 180;
                    break;
                case 3:
                    dgvMailList.DataSource = data.Select(o => new
                    {
                        MailId = o.Id,
                        Draft = "Draft",
                        Subject = "Subject: " + (o.Subject == string.Empty ? "(None Subject)" : o.Subject),
                    }).ToList();
                    dgvMailList.Columns[0].Visible = false;
                    dgvMailList.Columns[1].Width = 180;
                    break;
                case 4:
                    dgvMailList.DataSource = data.Select(o => new
                    {
                        MailId = o.Id,
                        From = "From: " + UserRepository.GetUserById(o.From).Mail,
                        Subject = "Subject: " + o.Subject,
                    }).ToList();
                    dgvMailList.Columns[0].Visible = false;
                    dgvMailList.Columns[1].Width = 180;
                    break;
                default: break;
            }
        }

    }
}
