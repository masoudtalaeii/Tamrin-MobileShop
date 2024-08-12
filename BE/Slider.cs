using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Silder
    {
        [Key]
        public int SliderId { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string pic { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; } = true;
    }
}
