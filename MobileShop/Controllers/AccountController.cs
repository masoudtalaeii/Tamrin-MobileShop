
using BE;
using BLL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Classes;
using System.Security.Claims;

namespace MobileShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(BE.User model)
        {

            if (model.UserName == null || model.Password == null || model.Family == null || model.Name == null)
            {
                return View(model);
            }
            if (_userService.CheckUserForRegister(model.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری تکراری است ");
                return View(model);
            }
            model.Password = PasswordHelper.EncodePasswordMd5(model.Password);
            model.RoleId = 2;
            _userService.RegisterUser(model);
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            string hashPassword = PasswordHelper.EncodePasswordMd5(model.Password);
            var user = _userService.CheckUserForLogin(model.UserName, hashPassword);

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
                new Claim(ClaimTypes.Role,user.Role.RoleTitle)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = true
            };

            HttpContext.SignInAsync(principal, properties);
            if (user.RoleId == 1)
            {
                return Redirect("/Admin");
            }
            return Redirect("/Users");
        }



        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }


        //public IActionResult ForgotPassword()
        //{
        //    return View();
        //}



        //[HttpPost]
        //public IActionResult ForgotPassword(string UserName, string Pass)
        //{
        //    UserBLL bll = new UserBLL();
        //    var res = bll.RestPass(UserName, Pass);
        //    if (res == true)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View();
        //}




    }
}



