using BE;
using BLL;
using Microsoft.AspNetCore.Mvc;
using MobileShop.Classes;

namespace MobileShop.Areas.Users.Controllers
{

    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult EditProfile()
        {

            var userID = _userService.GetUserIdByUserName(User.Identity.Name);
            var user = _userService.GetUserById(userID);
            return View(user);
        }

        [HttpPost]
        public IActionResult EditProfile(User model)
        {
            if (model.UserName == null || model.Password == null || model.Family == null || model.Name == null)
            {
                return View(model);
            }

            model.Password = PasswordHelper.EncodePasswordMd5(model.Password);

            _userService.EditUser(model);
            return RedirectToAction("Logout", "Account");
        }
    }
}
