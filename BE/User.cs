using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class User
    {
        [Key]
        public int UserId {  get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "فامیلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Family {  get; set; }

        [Display(Name = "ایمیل/نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string UserName {  get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password {  get; set; }

        [Display(Name = "آدرس")]
        public string Adress { get; set; } = "تهران";

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "نقش کاربر")]
        public int RoleId { get; set; } 

        public Role Role { get; set; }

    }
}
