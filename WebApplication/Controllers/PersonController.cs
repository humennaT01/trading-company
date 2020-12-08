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
    public class PersonController : Controller
    {
        private IAdminManager _adminManager;
        private IMapper _mapper;
        public PersonController(IAdminManager adminManager, IMapper mapper)
        {
            _adminManager = adminManager;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var people = _adminManager.GetAllPeople();
            return View(people);
        }

        public ActionResult Details(int id)
        {
            PersonViewModel person = _mapper.Map<PersonViewModel>(_adminManager.GetAllPeople().Where(p => p.PersonID == id).FirstOrDefault());
            return View(person);
        }
    }
}