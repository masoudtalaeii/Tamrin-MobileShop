using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductGroupService : IProductGroupService
    {
        private readonly DB _db;
        public ProductGroupService(DB db)
        {
            _db = db;
        }
        public void AddProductGroup(ProductGroup model)
        {
            _db.productGroups.Add(model);
            _db.SaveChanges();
        }

        public void EditProductGroup(ProductGroup model)
        {
            _db.productGroups.Update(model);
            _db.SaveChanges();
        }

        public List<ProductGroup> GetAllProductGroups()
        {
            return _db.productGroups.ToList();
        }

        public ProductGroup GetProductGroupById(int Id)
        {
            return _db.productGroups.FirstOrDefault(u => u.ProductGroupId == Id);
        }
    }
}
