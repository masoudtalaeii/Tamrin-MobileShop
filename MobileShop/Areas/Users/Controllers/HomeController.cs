﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MobileShop.Areas.Users.Controllers
{
    
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
