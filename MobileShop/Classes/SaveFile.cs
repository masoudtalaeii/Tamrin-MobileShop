namespace MobileShop.Classes
{
    public static class SaveFile
    {


        public static string SaveFileAndImages(this string pathFolder, IFormFile imgUpload)
        {
            var imageName = "no-photo.jpg";
            if (imgUpload != null)
            {
                imageName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(imgUpload.FileName);
                string path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + pathFolder + "/") + imageName;
                using (var stream = new FileStream(path1, FileMode.Create))
                {
                    imgUpload.CopyTo(stream);
                }
                return imageName;
            }
            return imageName;
        }


        public static bool DeleteFile(this string pathFolder, string name)
        {
            if (name == "no-photo.jpg")
            {
                return false;
            }
            var imagePath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/" + pathFolder + "/", name);
            if (File.Exists(imagePath1))
            {
                File.Delete(imagePath1);
                return true;
            }
            return false;
        }

    }

}
