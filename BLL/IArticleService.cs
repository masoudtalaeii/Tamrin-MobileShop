using BE;

namespace BLL
{
    public interface IArticleService
    {
        public void Add(Article model);
        public List<Article> GetAll();

        public Article GetById(int id);

        public void Edit(Article model);
    }
}
