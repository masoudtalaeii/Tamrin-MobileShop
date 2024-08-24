using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class ProductGroup
    {
        [Key]
        public int ProductGroupId { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        public List<Product> products { get; set; }

    }
}
