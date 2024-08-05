using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class UserBLL
    {
        
        public void Create(User u)
        {
            UserDAL user=new UserDAL();
            user.Create(u);
        }
        public User readById(int id)
        {
            UserDAL user = new UserDAL();
            return user.readById(id);
        }
        public List<User> read(string filter)
        {
            UserDAL user = new UserDAL();
            return user.read(filter);
        }
        public void Update(User model)
        {
            UserDAL user = new UserDAL();
            user.Update(model);

        }

        public void CheckUser(int id)
        {
            UserDAL user = new UserDAL();
            user.CheckUser(id);
        }

        public bool CheckUserForRegister(string userName)
        {
            UserDAL user = new UserDAL();
           return  user.CheckUserForRegister(userName);
        }

        public User CheckUserForLogin(string userName , string password)
        {
            UserDAL user = new UserDAL();
            return user.CheckUserForLogin(userName,password);
        }

        public bool RestPass(string userName, string password)
        {
            UserDAL user = new UserDAL();
            return user.RestPass(userName, password);
        }

    }
}
