using BE;
using BLL;

namespace DAL
{
    public class RulesService : IRulesService
    {
        private readonly DB _db;

        public RulesService(DB db)
        {
            _db = db;
        }

        public void Add(Rules model)
        {

            _db.Rules.Add(model);
            _db.SaveChanges();
        }

        public void Edit(Rules model)
        {
            _db.Rules.Update(model);
            _db.SaveChanges();
        }

        public List<Rules> GetAll()
        {
            return _db.Rules.ToList();
        }
        public List<Rules> GetAllForSite()
        {
            return _db.Rules.Where(x=>x.IsActive).ToList();
        }
        public Rules GetById(int id)
        {
            return _db.Rules.FirstOrDefault(u => u.RulesId == id);
        }
    }
}
