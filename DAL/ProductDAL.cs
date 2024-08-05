using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
namespace DAL
{
    public class ProductDAL
    {


        public void Create(Product p)
        {
            DB _db = new DB();

            var db = new Product { Name = p.Name
                , Price = p.Price ,
                QuantityinStock=p.QuantityinStock,pic=p.pic };
            _db.Products.Add(db);
            _db.SaveChanges();
        }

        //اینجا هم همین طور
        public List<Product> read(string filter)
        {
            DB _db = new DB();
            if (!string.IsNullOrEmpty(filter))
            {
                var list = _db.Products.Where(b => b.Name.Contains(filter)).ToList();
                return list;
            }
            return _db.Products.ToList();
        }

        public Product readById(int id)
        {
            DB _db = new DB();
            return _db.Products.FirstOrDefault(p => p.ProductId ==id);

        }
      
        public List<Product> searchById(List<int> ids)
        {
            DB _db = new DB();
            return _db.Products.Where(p=>ids.Contains(p.ProductId)).ToList();

        }

     
        public void Update(Product model)
        {
            DB _db = new DB();
            _db.Products.Update(model);
            _db.SaveChanges();
     
         }

        public void Delete(int id)
        {
            DB _db = new DB();
            var model= _db.Products.FirstOrDefault(p => p.ProductId==id);
            _db.Products.Remove(model);
            _db.SaveChanges();
        }
        public void Delete(Product model)
        {
            DB _db = new DB();
            _db.Products.Remove(model);
            _db.SaveChanges();
        }
    }
  
}

    


