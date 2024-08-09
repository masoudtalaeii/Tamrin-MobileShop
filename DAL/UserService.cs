using BE;
using BLL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class UserService : IUserService
    {
        private readonly DB _db;

        public UserService(DB db)
        {
            _db = db;
        }

        public User CheckUserForLogin(string userName, string password)
        {
            var find = _db.Users
                .Include(r => r.Role)
                .FirstOrDefault(U => U.UserName == userName && U.Password == password);
            if (find != null) { return find; }
            return null;
        }

        public bool CheckUserForRegister(string userName)
        {
            return _db.Users.Any(U => U.UserName == userName );
        }

        public List<User> GetAllUser()
        {
            return _db.Users.ToList();
        }

        public void RegisterUser(User u)
        {
            u.RoleId = 2;
            _db.Users.Add(u);
            _db.SaveChanges();
        }
    }
}
