using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductGalleryService
    {
        public void Add(List<ProductGallery> model);
        public List<ProductGallery> GetAll();
        public List<ProductGallery> GetAllByProductId(int id);

        public ProductGallery GetById(int id);
        public void Remove(ProductGallery model);
    }
}
