using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class ProductBLL
    {

        public void Create(Product p)
        {
            ProductDAL dal = new ProductDAL();
             dal.Create(p);
        }

        
        public List<Product> read(string filter = null)
        {
            ProductDAL product = new ProductDAL();
            return product.read(filter);

        }
        public Product readById(int id)
        {
            ProductDAL product = new ProductDAL();
            return product.readById(id);

        }
        public void Update(Product p)
        {
            ProductDAL dal = new ProductDAL();
            dal.Update(p);
        }
        public void Delete(int id)
        {
            ProductDAL dal = new ProductDAL();
            dal.Delete(id);
        }

        public void Delete(Product model)
        {
            ProductDAL dal = new ProductDAL();
            dal.Delete(model);
        }
        public List<Product> searchById(List<int> ids)
        {
            ProductDAL dal = new ProductDAL();
            return dal.searchById(ids);
        }


    }
}
