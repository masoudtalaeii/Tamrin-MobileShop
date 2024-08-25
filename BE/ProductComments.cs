using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProductComment
    {

        [Key]
        public int ProductCommentId { get; set; }

        [Display(Name = "عنوان نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Text { get; set; }

        [Display(Name = "پشنهاد شده / نشده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool IsLike { get; set; }

        [Display(Name = "تاییده ادمین")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public bool CheckAdmin { get; set; } = false;


        [Display(Name = "نام کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserId { get; set; }

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductId { get; set; }


        [Display(Name = "تاریخ")]
        public DateTime Date { get; set; } = DateTime.Now;


        public Product Product { get; set; }

        public User User { get; set; }

    }
}
