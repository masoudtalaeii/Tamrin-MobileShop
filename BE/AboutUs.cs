using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class AboutUs
    {
        [Key]
        public int AboutUsId { get; set; }
        [Display(Name = "متن درباره ما")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string AboutMe { get; set; }
        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Phone { get; set; }
        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Moblie { get; set; }
        [Display(Name = "آدرس ما")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Address { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }
    }
}
