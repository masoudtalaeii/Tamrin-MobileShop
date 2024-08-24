using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class ProductFeature
    {
        [Key]
        public int ProductFeatureId { get; set; }

        [Display(Name = "محصول")]

        public int ProductId { get; set; }

        [Display(Name = "عنوان ویژگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string FeatureTitle { get; set; }

        [Display(Name = "مقدار ویژگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string FeatureValue { get; set; }


        public Product Product { get; set; }

    }
}
