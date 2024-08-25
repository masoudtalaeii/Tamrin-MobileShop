using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductSpecificationService
    {
        public void Add(ProductSpecification model);
        public List<ProductSpecification> GetAll(int id);

        public ProductSpecification GetById(int id);

        public void Edit(ProductSpecification model);
    }
}
