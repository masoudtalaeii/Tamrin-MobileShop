using BE;
using BLL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProducService : IProducService
    {
        private readonly DB _db;
        public ProducService(DB db)
        {
            _db = db;
        }
        public void Add(Product model)
        {
            model.IsActive = true;
            _db.Products.Add(model);
            _db.SaveChanges();
        }

        public void Edit(Product model)
        {
            _db.Products.Update(model);
            _db.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return _db.Products.Include(g=>g.ProductGroup).ToList();
        }

        public Product GetById(int id)
        {
            return _db.Products.Include(g => g.ProductGroup).FirstOrDefault(u => u.ProductId == id);
        }
    }
}
