using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL;
using Microsoft.AspNetCore.Authorization;

namespace MobileShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UsersController : Controller
    {
        public IActionResult Index(string filter = "")
        {
            UserBLL bll = new UserBLL();
            var list = bll.read(filter);

            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BE.User model)
        {
            UserBLL bll = new UserBLL();
            bll.Create(model);
            return RedirectToAction("Index");
        }
       
        public IActionResult Edit(int id)
        {
            UserBLL bll = new UserBLL();
            var user = bll.readById(id);
         
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(BE.User model)
        {
            UserBLL bll = new UserBLL();
            bll.Update(model);

            return RedirectToAction("Index");
        }

        public IActionResult CheckUser(int id)
        {
            UserBLL bll = new UserBLL();
            bll.CheckUser(id);

            return RedirectToAction("Index");
        }

    }
}
