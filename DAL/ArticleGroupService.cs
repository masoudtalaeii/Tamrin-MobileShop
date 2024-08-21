using BE;
using BLL;


namespace DAL
{
    public class ArticleGroupService : IArticleGroupService
    {
        private readonly DB _db;
        public ArticleGroupService(DB db)
        {
            _db = db;
        }
        public void Add(ArticleGroup model)
        {
            _db.ArticleGroups.Add(model);
            _db.SaveChanges();
        }

        public void Edit(ArticleGroup model)
        {
            _db.ArticleGroups.Update(model);
            _db.SaveChanges();
        }

        public List<ArticleGroup> GetAll()
        {
            return _db.ArticleGroups.ToList();
        }

        public ArticleGroup GetById(int Id)
        {
            return _db.ArticleGroups.FirstOrDefault(u => u.ArticleGroupId == Id);
        }
    }
}
