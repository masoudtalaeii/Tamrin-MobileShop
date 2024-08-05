
using BLL;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {

        public IActionResult Index(string filter="")
        {
            ProductBLL pt= new ProductBLL();
            var list=pt.read(filter);
            
            return View(list);
        }
    


        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Create(BE.Product model ,IFormFile up)
        {
            //save pic
            if (up != null)
            {
                model.pic = SaveFile.SaveFileAndImages("/Images/Product", up);
            }


            ProductBLL pt = new ProductBLL();
            pt.Create(model);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ProductBLL pt = new ProductBLL();
            var product = pt.readById(id);

            return View(product);
        }

        
        [HttpPost]
        public IActionResult Edit(BE.Product model)
        {
            
            ProductBLL pt = new ProductBLL();
            pt.Update(model);

            return RedirectToAction("Index");
        }


        //public IActionResult Search(string filter ="p")
        //{
        //    ProductBLL pt = new ProductBLL();
        //    if (!string.IsNullOrEmpty(filter))
        //    {
        //        pt.Search(filter);
        //    }


        //    return View();
        //}
      
        public IActionResult Delete(int id)
        {
            ProductBLL pt = new ProductBLL();
            pt.Delete(id);

            return RedirectToAction("Index");
        }
       

    }

    internal class _ProductRepository
    {
        internal static object GetproductById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
