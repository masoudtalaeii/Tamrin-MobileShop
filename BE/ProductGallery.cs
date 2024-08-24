using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class ProductGallery
    {
        public int ProductGalleryId { get; set; }


        [Display(Name = "نام تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string ImageName { get; set; }

        [Display(Name = "محصول")]
        public int ProductId { get; set; }


        public Product Product { get; set; }

    }
}
