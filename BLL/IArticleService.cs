using BE;

namespace BLL
{
    public interface IArticleService
    {
        public void Add(Article model);
        public List<Article> GetAll();

        public Article GetById(int id);

        public void Edit(Article model);
        public List<Article> GetAllForSite();
        public List<Article> GetAllByGroupId(int id);
    }
}
