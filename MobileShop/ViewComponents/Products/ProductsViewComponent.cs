using Microsoft.AspNetCore.Mvc;

namespace MobileShop.ViewComponents.Products
{
    public class ProductsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BLL.ProductBLL bLL = new BLL.ProductBLL();

            return View ("_Products",bLL.read());
        }
    }
}
