using BLL;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Areas.Admin.Controllers
{
    public class ProductCommentsController : BaseController
    {
        private readonly IProductCommentService _productCommentService;
        private readonly IProducService _producService;
        public ProductCommentsController(IProductCommentService productCommentService, IProducService producService)
        {
            _productCommentService = productCommentService;
            _producService = producService;
        }
        public ActionResult AllCommnetById(int id)
        {
            var list = _productCommentService.GetAll(id);
            ViewBag.ProductName = _producService.GetById(id).Name_Farsi;
            return View(list);
        }

        public ActionResult Details(int id)
        {
            var model = _productCommentService.GetById(id);
            return View(model);
        }
        [HttpGet]
        public void ActiveDeActiveComment(int Pid)
        {
           _productCommentService.ActiveDeActiveComment(Pid);
        }


    }
}
