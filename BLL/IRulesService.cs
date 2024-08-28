using BE;

namespace BLL
{
    public interface IRulesService
    {
        public void Add(Rules model);
        public List<Rules> GetAll();
        public List<Rules> GetAllForSite();

        public Rules GetById(int id);

        public void Edit(Rules model);
    }
}
