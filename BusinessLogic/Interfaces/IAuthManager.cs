﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAuthManager
    {
        bool Login(string username, string password);
        long GetId(string login);
        long GetRoleId(string userLogin);
        long GetPersonId(string userLogin);
    }
}
