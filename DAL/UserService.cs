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
            return _db.Users.Any(U => U.UserName == userName);
        }

        public void EditUser(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public List<Role> GetAllRoles()
        {
            return _db.roles.ToList();
        }

        public List<User> GetAllUser()
        {
            return _db.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _db.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public void RegisterUser(User u)
        {
            _db.Users.Add(u);
            _db.SaveChanges();
        }

        public int GetUserIdByUserName(string username)
        {
            return _db.Users.FirstOrDefault(l => l.UserName == username).UserId;
        }


    }
}
