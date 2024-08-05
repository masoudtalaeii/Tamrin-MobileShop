using BLL;
using DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using BE;
using MobileShop.Classes;

namespace MobileShop.Controllers
{
    public class AccountController : Controller
    {

        
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(BE.User model)
        {


            UserBLL bll = new UserBLL();

            if (model.UserName==null || model.Password==null ||  model.Family==null)
            {
                return View(model);
            }
            if (bll.CheckUserForRegister(model.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری تکراری است ");
                return View(model);
            }
            model.Password = PasswordHelper.EncodePasswordMd5(model.Password);

            bll.Create(model);
            return RedirectToAction("Index", "Home");
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel model)
        {
            UserBLL bll = new UserBLL();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string hashPassword = PasswordHelper.EncodePasswordMd5(model.Password);
            var user = bll.CheckUserForLogin(model.UserName,hashPassword);

            if (user == null)
            {
                ModelState.AddModelError("UserName", "نام کاربری شما یافت نشد لطفا ثبت نام کنید");
                return View(model);
            }

            if (!user.IsActive)
            {
                ModelState.AddModelError("UserName", "نام کاربری شما فعال نیست");
                return View(model);
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            HttpContext.SignInAsync(principal, properties);
            return Redirect("/Admin");
        }



        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }



        [HttpPost]
        public IActionResult ForgotPassword(string UserName, string Pass)
        {
            UserBLL bll = new UserBLL();
            var res = bll.RestPass(UserName, Pass);
            if (res == true)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }




    }
}



