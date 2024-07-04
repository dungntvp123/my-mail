using MyMailLibrary.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailLibrary.DataRepository.DeliverRepository
{
    public interface IDeliverRepository
    {
        public IEnumerable<Deliver> GetMailDelivers(int mailId);
        public Deliver GetDeliver(int id);
        public Deliver AddNew(Deliver delivery);
        public void Update(Deliver delivery);
        public void Delete(int id);
        public IEnumerable<Deliver> GetUserDeliversByMailType(int userid, int mailType, int status);
        public IEnumerable<Deliver> GetReadStatusDelivers(int userid, int status);
        public Deliver GetDeliver(int mailId, int userid);
    }
}
