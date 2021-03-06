﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEF.Interfaces
{
    public interface IRoleDal
    {
        RoleDTO GetRoleById(int id);
        List<RoleDTO> GetAllRole();
        RoleDTO UpdateRole(RoleDTO role);
        RoleDTO CreateRole(RoleDTO role);
        void DeleteRole(int id);
    }
}
