using BE;
using BLL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProductGalleryService : IProductGalleryService
    {
        private readonly DB _db;
        public ProductGalleryService(DB db)
        {
            _db = db;
        }
        public void Add(List<ProductGallery> model)
        {
            _db.productGalleries.AddRange(model);
            _db.SaveChanges();
        }


        public List<ProductGallery> GetAll()
        {
            return _db.productGalleries.Include(g => g.Product).ToList();
        }
        public List<ProductGallery> GetAllByProductId(int id)
        {
            return _db.productGalleries.Include(g => g.Product).Where(p=>p.ProductId==id).ToList();
        }

        public ProductGallery GetById(int id)
        {
            return _db.productGalleries.FirstOrDefault(u => u.ProductGalleryId == id);
        }
        public void Remove(ProductGallery model)
        {
            _db.productGalleries.Remove(model);
            _db.SaveChanges();
        }
    }
}
