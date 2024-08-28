using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "این فیلد نمی تواند خالی بماند")]
        public string Title { get; set; } = "";

        [Display(Name = "پاسخ")]
        [Required(ErrorMessage = "این فیلد نمی تواند خالی بماند")]
        public string Description { get; set; } = "";

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "این فیلد نمی تواند خالی بماند")]
        public bool IsActive { get; set; } = true;

    }
}
