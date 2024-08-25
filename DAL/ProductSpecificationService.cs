using BE;
using BLL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProductSpecificationService : IProductSpecificationService
    {
        private readonly DB _db;
        public ProductSpecificationService(DB db)
        {
            _db = db;
        }
        public void Add(ProductSpecification model)
        {
            _db.productSpecifications.Add(model);
            _db.SaveChanges();
        }

        public void Edit(ProductSpecification model)
        {
            _db.productSpecifications.Update(model);
            _db.SaveChanges();
        }

        public List<ProductSpecification> GetAll(int id)
        {
            return _db.productSpecifications
                .Include(g => g.Product)
                .Where(f => f.ProductId == id)
                .ToList();
        }

        public ProductSpecification GetById(int id)
        {
            return _db.productSpecifications.Include(g => g.Product).FirstOrDefault(u => u.ProductSpecificationId == id);
        }
    }
}
