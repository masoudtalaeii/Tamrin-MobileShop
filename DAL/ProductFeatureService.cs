using BE;
using BLL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductFeatureService: IProductFeatureService
    {
        private readonly DB _db;
        public ProductFeatureService(DB db)
        {
            _db = db;
        }
        public void Add(ProductFeature model)
        {
            _db.productFeatures.Add(model);
            _db.SaveChanges();
        }

        public void Edit(ProductFeature model)
        {
            _db.productFeatures.Update(model);
            _db.SaveChanges();
        }

        public List<ProductFeature> GetAll(int id)
        {
            return _db.productFeatures
                .Include(g => g.Product)
                .Where(f=>f.ProductId==id)
                .ToList();
        }

        public ProductFeature GetById(int id)
        {
            return _db.productFeatures.Include(g => g.Product).FirstOrDefault(u => u.ProductFeatureId == id);
        }
    }
}
