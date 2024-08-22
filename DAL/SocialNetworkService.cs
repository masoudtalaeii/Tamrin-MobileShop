using BE;
using BLL;

namespace DAL
{
    public class SocialNetworkService : ISocialNetworkService
    {
        private readonly DB _db;
        public SocialNetworkService(DB db)
        {
            _db = db;
        }
        public void Add(SocialNetwork model)
        {

            _db.socialNetworks.Add(model);
            _db.SaveChanges();
        }

        public void Edit(SocialNetwork model)
        {
            _db.socialNetworks.Update(model);
            _db.SaveChanges();
        }

        public List<SocialNetwork> GetAll()
        {
            return _db.socialNetworks.ToList();
        }

        public SocialNetwork GetById(int id)
        {
            return _db.socialNetworks.FirstOrDefault(u => u.SocialNetworkId == id);
        }
    }
}
