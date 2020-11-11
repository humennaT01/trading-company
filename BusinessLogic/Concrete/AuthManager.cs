using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DALEF.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class AuthManager : IAuthManager
    {
        private readonly UserDalEf _userDal;

        public AuthManager(UserDalEf userDal)
        {
            _userDal = userDal;
        }

        public bool Login(string username, string password)
        {
            return _userDal.Login(username, password);
        }

        public long GetId(string login)
        {
            return _userDal.GetId(login);
        }

        public long GetRoleId(string userLogin)
        {
            return _userDal.GetRoleId(userLogin);
        }

        public long GetPersonId(string userLogin)
        {
            return _userDal.GetPersonId(userLogin);
        }
    }
}
