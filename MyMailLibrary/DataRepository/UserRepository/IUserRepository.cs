using MyMailLibrary.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailLibrary.DataRepository.UserRepository
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetUserList();
        public User GetUserById(int id);
        public User GetUserByMail(string mail);
        public User AddNew(User user);
        public void Update(User user);
        public void Delete(int id);
        public User Login(string mail, string password);
    }
}
