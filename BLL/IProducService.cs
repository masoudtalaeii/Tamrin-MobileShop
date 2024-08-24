using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProducService
    {
        public void Add(Product model);
        public List<Product> GetAll();

        public Product GetById(int id);

        public void Edit(Product model);
    }
}
