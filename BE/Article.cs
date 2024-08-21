using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string shortDescription { get; set; }

        [Display(Name = "توضیحات کامل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string totallDescription { get; set; }


        [Display(Name = "تصویر")]
        public string pic { get; set; }

        [Display(Name = "تگ ها")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Tag { get; set; }

        [Display(Name = "نویسنده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Author { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime date { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int SeeCount { get; set; }

        [Display(Name = " ")]
        public int ArticleGroupId { get; set; }

        [Display(Name = "وضعیت نمایش")]
        public bool IsActive { get; set; } = true;

        public ArticleGroup articleGroup { get; set; }


    }
}
