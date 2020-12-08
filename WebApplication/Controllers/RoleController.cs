using AutoMapper;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class RoleController : Controller
    {
        private IAdminManager _adminManager;
        private IMapper _mapper;
        public RoleController(IAdminManager adminManager, IMapper mapper)
        {
            _adminManager = adminManager;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var roles = _adminManager.GetAllRoles();
            return View(roles);
        }

        public ActionResult Details(int id)
        {
            RoleViewModel role = _mapper.Map<RoleViewModel>(_adminManager.GetAllRoles().Where(r => r.RoleID == id).FirstOrDefault());
            return View(role);
        }
    }
}