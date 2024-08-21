using BE;
using BLL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ArticleService : IArticleService
    {
        private readonly DB _db;
        public ArticleService(DB db)
        {
            _db = db;
        }
        public void Add(Article model)
        {
            model.IsActive= true;
            model.SeeCount = 0;
            model.date = DateTime.Now;
            _db.Articles.Add(model);
            _db.SaveChanges();
        }

        public void Edit(Article model)
        {
            _db.Articles.Update(model);
            _db.SaveChanges();
        }

        public List<Article> GetAll()
        {
            return _db.Articles.Include(x=>x.articleGroup).ToList();
        }

        public Article GetById(int id)
        {
            return _db.Articles.Include(x=>x.articleGroup).FirstOrDefault(u => u.ArticleId == id);
        }
    }
}
