using BE;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using MobileShop.Classes;

namespace MobileShop.Areas.Admin.Controllers
{
   
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var list = _userService.GetAllUser();
            return View(list);
        }

        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_userService.GetAllRoles(), "RoleId", "RoleTitle");
            return View();
        }
        [HttpPost]
        public IActionResult Create(User model)
        {
            if (model.UserName == null || model.Password == null || model.Family == null|| model.Name==null)
            {
                ViewData["RoleId"] = new SelectList(_userService.GetAllRoles(), "RoleId", "RoleTitle",model.RoleId);
                return View(model);
            }
            if (_userService.CheckUserForRegister(model.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری تکراری است ");
                ViewData["RoleId"] = new SelectList(_userService.GetAllRoles(), "RoleId", "RoleTitle", model.RoleId);
                return View(model);
            }
            model.Password = PasswordHelper.EncodePasswordMd5(model.Password);
            _userService.RegisterUser(model);
            return RedirectToAction("Index", "Users");
        }
      
        
        public IActionResult Edit(int id)
        {
            var user=_userService.GetUserById(id);
            ViewData["RoleId"] = new SelectList(_userService.GetAllRoles(), "RoleId", "RoleTitle",user.RoleId);
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User model)
        {
            if (model.UserName == null || model.Password == null || model.Family == null || model.Name == null)
            {
                ViewData["RoleId"] = new SelectList(_userService.GetAllRoles(), "RoleId", "RoleTitle", model.RoleId);
                return View(model);
            }
           
            model.Password = PasswordHelper.EncodePasswordMd5(model.Password);

            _userService.EditUser(model);
            return RedirectToAction("Index", "Users");
        }

        public IActionResult Details(int id)
        {
            var user = _userService.GetUserById(id);
            return View(user);
        }
    }
}
