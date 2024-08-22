using BE;

namespace BLL
{
    public interface IAboutsService
    {
        public void Add(AboutUs model);
        public List<AboutUs> GetAll();

        public AboutUs GetById(int id);

        public void Edit(AboutUs model);
    }
}
