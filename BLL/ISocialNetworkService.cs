using BE;

namespace BLL
{
    public interface ISocialNetworkService
    {
        public void Add(SocialNetwork model);
        public List<SocialNetwork> GetAll();

        public SocialNetwork GetById(int id);

        public void Edit(SocialNetwork model);
    }
}
