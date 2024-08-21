using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class ArticleGroup
    {
        [Key]
        public int ArticleGroupId { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        public List<Article> Articles { get; set; }

    }
}
