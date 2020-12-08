using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private IAdminManager _adminManager;

        public HomeController(IAdminManager adminManager)
        {
            _adminManager = adminManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult UserList()
        {
            if (LoginController.active == true)
            {
                var users = _adminManager.GetAllUsers();
                return View(users);
            }

            return View("../Login/Login", new LoginViewModel());
        }

        public ActionResult RoleList()
        {
            if (LoginController.active == true)
            {
                var roles = _adminManager.GetAllRoles();
                return View(roles);
            }
            return View("../Login/Login", new LoginViewModel());
        }

        public ActionResult PersonList()
        {
            if (LoginController.active == true)
            {
                var people = _adminManager.GetAllPeople();
                return View(people);
            }
            return View("../Login/Login", new LoginViewModel());
        }
    }
}