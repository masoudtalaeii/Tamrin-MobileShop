using BE;
using BLL;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ProductCommentService : IProductCommentService
    {
        private readonly DB _db;
        public ProductCommentService(DB db)
        {
            _db = db;
        }



        public List<ProductComment> GetAll(int id)
        {
            return _db.productComments
                .Include(p=>p.Product)
                .Include(p=>p.User)
                .Where(p=>p.ProductId==id)
                .OrderByDescending(x => x.CheckAdmin == false)
                .ThenByDescending(x => x.Date)
                .ToList();
        }

        public ProductComment GetById(int id)
        {
            return _db.productComments
                .Include(p => p.Product)
                .Include(p => p.User)
                .FirstOrDefault(u => u.ProductCommentId == id);
        }
        public void ActiveDeActiveComment(int id)
        {
            var  find= _db.productComments.FirstOrDefault(u => u.ProductCommentId == id);
            find.CheckAdmin = !find.CheckAdmin;
            _db.productComments.Update(find);
            _db.SaveChanges();

        }
    }
}
