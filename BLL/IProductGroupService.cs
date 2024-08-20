using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductGroupService
    {
        public List<ProductGroup> GetAllProductGroups();
        public void AddProductGroup(ProductGroup model);
        public ProductGroup GetProductGroupById(int Id);

        public void EditProductGroup(ProductGroup model);
    }
}
