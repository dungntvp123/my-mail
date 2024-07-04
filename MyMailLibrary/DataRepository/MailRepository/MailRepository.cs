using MyMailLibrary.dao;
using MyMailLibrary.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailLibrary.DataRepository.MailRepository
{
    public class MailRepository : IMailRepository
    {
        public Mail AddNew(Mail mail) => MailDAO.Instance.AddNew(mail);

        public void Delete(int id) => MailDAO.Instance.Delete(id);

        public Mail GetMailById(int id) => MailDAO.Instance.GetMailById(id);

        public IEnumerable<Mail> GetMailList(int from, int type) => MailDAO.Instance.GetMailList(from, type);

        public void Update(Mail mail) => MailDAO.Instance.Update(mail);
    }
}
