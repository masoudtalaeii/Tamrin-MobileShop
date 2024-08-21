using BE;

namespace BLL
{
    public interface IArticleGroupService
    {
        public List<ArticleGroup> GetAll();
        public void Add(ArticleGroup model);
        public ArticleGroup GetById(int Id);

        public void Edit(ArticleGroup model);
    }
}
