using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }

        [Display(Name = "نام محصول / فارسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name_Farsi { get; set; }

        [Display(Name = "نام محصول / انگلیسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name_English { get; set; }

        [Display(Name = "قیمت(تومان)")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Price { get; set; }

        [Display(Name = "تصویر محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string pic { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }

        [Display(Name = "گروه محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductGroupId { get; set; }

        public List<ProductComment> ProductComments { get; set; }
        public List<ProductFeature> ProductFeatures { get; set; }
        public List<ProductSpecification> productSpecifications { get; set; }
        public List<ProductGallery> productGalleries { get; set; }
        public ProductGroup ProductGroup { get; set; }

    }
}
