
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
    public partial class frmLogin : Form
    {
        public UserRepository userRepository;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string mail = txtMail.Text;
            string password = txtPassword.Text;
            userRepository = new UserRepository();
            User user = userRepository.Login(mail, password);
            if (user != null)
            {
                frmMainPage frmMainPage = new frmMainPage
                {
                    frmLogin = this,
                    User = user,
                    DeliverRepository = new DeliverRepository(),
                    MailRepository = new MailRepository(),
                    UserRepository = userRepository,
                };
                txtPassword.Text = string.Empty;
                frmMainPage.Show();
                this.Hide();
            }
        }


    }
}
