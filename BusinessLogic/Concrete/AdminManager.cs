using AutoMapper;
using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DALEF;
using DALEF.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class AdminManager : IAdminManager
    {

        private readonly IPersonDal _personDal;
        private readonly IUserDal _userDal;
        private readonly IRoleDal _roleDal;

        public AdminManager(IPersonDal personDal, IUserDal userDal, IRoleDal roleDal)
        {
            _personDal = personDal;
            _userDal = userDal;
            _roleDal = roleDal;
        }

        public UserDTO ActivateUser(long id)
        {
            UserDTO user = _userDal.GetUserById((int)id);
            user.Status = false;
            return _userDal.UpdateUser(user);
        }

        public UserDTO BlockUser(long id)
        {
            UserDTO user = _userDal.GetUserById((int)id);
            user.Status = true;
            return _userDal.UpdateUser(user);
        }

        public UserDTO FindUserByEmail(string email)
        {
            var user = _userDal.GetAllUser().Where(u => u.Email == email).FirstOrDefault();
            if (user != null)
            {
                return user;
            };
            return null;
        }

        public UserDTO FindUserByLogin(string login)
        {
            var user = _userDal.GetAllUser().Where(u => u.Login == login).FirstOrDefault();
            if (user != null)
            {
                return user;
            };
            return null;
        }

        public List<UserDTO> SortedUsersByEmails()
        {
            var users = _userDal.GetAllUser().OrderBy(u => u.Email).ToList();
            return users;
        }

        public List<UserDTO> SortedUsersByLogins()
        {
            var users = _userDal.GetAllUser();
            return users.OrderBy(u => u.Login).ToList();
        }

        public List<UserDTO> GetAllUsers()
        {
            return _userDal.GetAllUser();
        }

        public PersonDTO GetInfoAboutPerson(long id)
        {
            return _personDal.GetPersonById((int)id);
        }
    }
}
