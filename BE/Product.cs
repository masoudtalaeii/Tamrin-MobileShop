using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price {  get; set; }
        public int QuantityinStock { get; set; }
        public string pic {  get; set; }

     
    }
}
