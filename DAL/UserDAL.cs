using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class UserDAL
    {
       
        public void Create(User u)
        {
            DB _db = new DB();
            u.RoleId = 2;
            _db.Users.Add(u);
            _db.SaveChanges();
        }
        public User readById(int id)
        {
            DB _db = new DB();
            return _db.Users.FirstOrDefault(U => U.UserId == id);

        }

        public void CheckUser(int id)
        {
            DB _db = new DB();
            var find = _db.Users.FirstOrDefault(U => U.UserId == id);
            find.IsActive = !find.IsActive;
            _db.Users.Update(find);
            _db.SaveChanges();
        }
        public bool  CheckUserForRegister(string userName)
        {
            DB _db = new DB();
            return _db.Users.Any(U => U.UserName == userName);
           
        }

        public User CheckUserForLogin(string userName, string password)
        {
            DB _db = new DB();
            var find = _db.Users.FirstOrDefault(U => U.UserName == userName&& U.Password==password);
            if (find != null) { return find; }
            return null;
        }

        public bool RestPass(string userName, string password)
        {
            DB _db = new DB();
            if (_db.Users.Any(U => U.UserName == userName))
            {    
                var find = _db.Users.FirstOrDefault(U => U.UserName == userName);
               find.Password= password;
                _db.Users.Update(find);
                _db.SaveChanges();
            return true;
            }
            return false;  
         
        }

        public List<User> read(string filter)
        {
            DB _db = new DB();
            if (!string.IsNullOrEmpty(filter))
            {
                var list = _db.Users.Where(u => u.Name.Contains(filter)).ToList();
                return list;
            }
            return _db.Users.ToList();
        }
        public void Update(User model)
        {
            DB _db = new DB();
            _db.Users.Update(model);
            _db.SaveChanges();

        }

    }
}
