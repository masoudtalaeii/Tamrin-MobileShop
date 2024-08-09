using BE;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MobileShop.Controllers
{
    public class OrderController : Controller
    {
    

        //public IActionResult AddToBasket(int ProductId)
        //{
        //    var basketList = new List<int>();
        //    if (HttpContext.Session.GetString("basket") != null)
        //    {
        //        basketList = JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("basket")).ToList();


        //    }

        //basketList.Add(ProductId);
        //    HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(basketList));
        //    ProductBLL bll = new ProductBLL();
        //    var products = bll.searchById(basketList);
        //    return View(products);

        //}


    }
}
