using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Classes;

namespace MobileShop.Areas.Admin.Controllers
{
    public class ProductGalleryController : BaseController
    {
        private readonly IProductGalleryService _productGalleryService;
        public ProductGalleryController(IProductGalleryService productGalleryService)
        {
            _productGalleryService = productGalleryService;
        }

        public IActionResult CreateGallery(int id)
        {
            ProductGallery model = new ProductGallery()
            {
                ProductId = id,
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateGallery(ProductGallery model, List<IFormFile> filePic)
        {
            if (filePic.Count > 0)
            {
                List<ProductGallery> temp = new List<ProductGallery>();
                foreach (var item in filePic)
                {
                    var picname = SaveFile.SaveFileAndImages("/Upload/ProductGallery", item);
                    temp.Add(new ProductGallery()
                    {
                        ProductId = model.ProductId,
                        ImageName = picname
                    });

                }
                _productGalleryService.Add(temp);
                return RedirectToAction("CreateGallery", "ProductGallery", new { id = model.ProductId });
            }
            return View(model);
        }

        public IActionResult DeletePicGallery(int id)
        {
            var Gallery = _productGalleryService.GetById(id);
            if (Gallery != null)
            {
                if (SaveFile.DeleteFile("/Upload/ProductGallery", Gallery.ImageName))
                {
                    _productGalleryService.Remove(Gallery);

                }
            }
            return RedirectToAction("CreateGallery", "ProductGallery", new { id = Gallery.ProductId });

        }

    }
}
