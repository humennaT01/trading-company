using AutoMapper;
using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        private IAdminManager _adminManager;
        private IMapper _mapper;
        public UserController(IAdminManager adminManager, IMapper mapper)
        {
            if (LoginController.active)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>().ReverseMap());

                _adminManager = adminManager;
                _mapper = mapper;
            }
            else
            {
                Redirect("../Login/Login");
            }
        }

        public ActionResult Index()
        {
            if (LoginController.active)
            {
                var users = _adminManager.GetAllUsers();
                return View(users);
            }
            return View("../Login/Login", new LoginViewModel());
        }

        public ActionResult Details(int id)
        {
            if (LoginController.active)
            {
                UserViewModel user = _mapper.Map<UserViewModel>(_adminManager.GetAllUsers().Where(u => u.UserID == id).FirstOrDefault());
                return View(user);
            }
            return View("../Login/Login", new LoginViewModel());
        }

        public ActionResult Create()
        {
            if (LoginController.active)
            {
                var user = new UserViewModel();
                return View(user);
            }
            return View("../Login/Login", new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Create(UserViewModel user)
        {
            if (LoginController.active)
            {
                if (ModelState.IsValid)
                {
                    UserDTO userDTO = _adminManager.CreateUser(_mapper.Map<UserDTO>(user));
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            return View("../Login/Login", new LoginViewModel());
        }

        public ActionResult Edit(int id)
        {
            if (LoginController.active)
            {
                var user = _mapper.Map<UserViewModel>(_adminManager.GetAllUsers().Where(u => u.UserID == id).FirstOrDefault());
                return View(user);
            }
            return View("../Login/Login", new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel user)
        {
            if (LoginController.active)
            {
                if (ModelState.IsValid)
                {
                    _adminManager.UpdateUser(_mapper.Map<UserDTO>(user));
                    return RedirectToAction(nameof(Index));
                }

                return View(user);
            }
            return View("../Login/Login", new LoginViewModel());
        }

        public ActionResult Delete(int id)
        {
            if (LoginController.active)
            {
                var user = _mapper.Map<UserViewModel>(_adminManager.GetAllUsers().Where(u => u.UserID == id).FirstOrDefault());
                return View(user);
            }

            return View("../Login/Login", new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Delete(UserViewModel user)
        {
            if (LoginController.active)
            {
                try
                {
                    _adminManager.DeleteUser(user.UserID);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View("../Login/Login", new LoginViewModel());
        }
    }
}
    
