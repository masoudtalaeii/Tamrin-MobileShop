using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProductSpecification
    {
        [Key]
        public int ProductSpecificationId { get; set; }

        [Display(Name = "محصول")]

        public int ProductId { get; set; }

        [Display(Name = "عنوان مشخصات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string FeatureTitle { get; set; }

        [Display(Name = "مقدار مشخصات")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string FeatureValue { get; set; }


        public Product Product { get; set; }
    }
}
