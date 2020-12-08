using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        public static bool active;
        IAuthManager _authManager;
        IAdminManager _adminManager;

        public LoginController(IAuthManager authManager, IAdminManager adminManager)
        {
            _adminManager = adminManager;
            _authManager = authManager;
            //active = false;
        }

        public ActionResult Login()
        {
            active = false;
            var user = new LoginViewModel();
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            var login = _authManager.Login(user.Login, user.Password);
            if (login) 
            {
                active = true;
                return View("../Home/Index"); 
            }
            else
            {
                active = false;
                return View("..");
            }
        }
    }
}