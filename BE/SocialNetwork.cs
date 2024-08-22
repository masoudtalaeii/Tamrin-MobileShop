using System.ComponentModel.DataAnnotations;

namespace BE
{
    public class SocialNetwork
    {
        [Key]
        public int SocialNetworkId { get; set; }

        [Display(Name = "آدرس تلگرام")]
        public string UrlTellgram { get; set; } = "UrlTellgram";

        [Display(Name = "آدرس واتس آپ")]
        public string UrlWhatsUp { get; set; } = "UrlWhatsUp";

        [Display(Name = "آدرس اینستاگرام")]
        public string UrlInstagram { get; set; } = "UrlInstagram";

        [Display(Name = "آدرس ایتا")]
        public string UrlEita { get; set; } = "UrlEita";

        [Display(Name = "آدرس آپارات")]
        public string UrlAparat { get; set; } = "UrlAparat";

        [Display(Name = "آدرس یوتیوب")]
        public string UrlYoutube { get; set; } = "UrlYoutube";

    }
}
