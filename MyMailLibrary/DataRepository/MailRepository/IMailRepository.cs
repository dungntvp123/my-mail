using MyMailLibrary.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailLibrary.DataRepository.MailRepository
{
    public interface IMailRepository
    {
        public IEnumerable<Mail> GetMailList(int from, int type);
        public Mail GetMailById(int id);
        public Mail AddNew(Mail mail);
        public void Delete(int id);
        public void Update(Mail mail);

    }
}
