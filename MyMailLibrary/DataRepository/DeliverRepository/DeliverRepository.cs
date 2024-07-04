using MyMailLibrary.dao;
using MyMailLibrary.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailLibrary.DataRepository.DeliverRepository
{
    public class DeliverRepository : IDeliverRepository
    {
        public Deliver AddNew(Deliver delivery) => DeliverDAO.Instance.AddNew(delivery);

        public void Delete(int id) => DeliverDAO.Instance.Delete(id);

        public Deliver GetDeliver(int id) => DeliverDAO.Instance.GetDeliver(id);

        public Deliver GetDeliver(int mailId, int userid) => DeliverDAO.Instance.GetDeliver(mailId, userid);

        public IEnumerable<Deliver> GetMailDelivers(int mailId) => DeliverDAO.Instance.GetMailDelivers(mailId);

        public IEnumerable<Deliver> GetReadStatusDelivers(int userid, int status) => DeliverDAO.Instance.GetReadStatusDelivers(userid, status);

        public IEnumerable<Deliver> GetUserDeliversByMailType(int userid, int mailType, int status) => DeliverDAO.Instance.GetUserDeliversByMailType(userid, mailType, status);

        public void Update(Deliver delivery) => DeliverDAO.Instance.Update(delivery);
    }
}
