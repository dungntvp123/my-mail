using MyMailLibrary.dao;
using MyMailLibrary.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailLibrary.DataRepository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public User AddNew(User user) => UserDAO.Instance.AddNew(user);

        public void Delete(int id) => UserDAO.Instance.Delete(id);

        public User GetUserById(int id) => UserDAO.Instance.GetUserById(id);

        public User GetUserByMail(string mail) => UserDAO.Instance.GetUserByMail(mail);

        public IEnumerable<User> GetUserList() => UserDAO.Instance.GetUserList();

        public User Login(string mail, string password) => UserDAO.Instance.Login(mail, password);

        public void Update(User user) => UserDAO.Instance.Update(user);
    }
}
