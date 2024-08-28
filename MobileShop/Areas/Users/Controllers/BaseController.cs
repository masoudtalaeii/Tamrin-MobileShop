using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "User")]
    public class BaseController : Controller
    {
    }
}
