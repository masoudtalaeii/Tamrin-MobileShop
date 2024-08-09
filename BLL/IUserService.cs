using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUserService
    {
        public User CheckUserForLogin(string userName, string password);
        public void RegisterUser(User u);
        public bool CheckUserForRegister(string userName);
        public List<User> GetAllUser();
    }
}
