using BE;
using BLL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AboutsService : IAboutsService
    {

        private readonly DB _db;
        public AboutsService(DB db)
        {
            _db = db;
        }
        public void Add(AboutUs model)
        {
            
            _db.aboutUs.Add(model);
            _db.SaveChanges();
        }

        public void Edit(AboutUs model)
        {
            _db.aboutUs.Update(model);
            _db.SaveChanges();
        }

        public List<AboutUs> GetAll()
        {
            return _db.aboutUs.ToList();
        }

        public AboutUs GetById(int id)
        {
            return _db.aboutUs.FirstOrDefault(u => u.AboutUsId == id);
        }
    }
}
