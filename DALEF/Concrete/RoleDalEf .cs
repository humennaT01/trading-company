using AutoMapper;
using DALEF.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEF.Concrete
{
    public class RoleDalEf : IRoleDal
    {
        private readonly IMapper _mapper;

        public RoleDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }

        public RoleDTO CreateRole(RoleDTO role)
        {
            using (var entities = new AdministratorEntities())
            {
                Role r = _mapper.Map<Role>(role);
                entities.Roles.Add(r);
                entities.SaveChanges();
                return _mapper.Map<RoleDTO>(r);
            }
        }

        public void DeleteRole(int id)
        {
            using (var entities = new AdministratorEntities())
            {
                var r = entities.Roles.SingleOrDefault(rr => rr.RoleID == id);
                if (r == null)
                {
                    return;
                }
                entities.Roles.Remove(r);
                entities.SaveChanges();
            }
        }

        public List<RoleDTO> GetAllRole()
        {
            using (var entities = new AdministratorEntities())
            {
                var roles = entities.Roles.ToList();
                return _mapper.Map<List<RoleDTO>>(roles);
            }
        }

        public RoleDTO GetRoleById(int id)
        {
            using (var entities = new AdministratorEntities())
            {
                var role = entities.Roles.SingleOrDefault(r => r.RoleID == id);
                return _mapper.Map<RoleDTO>(role);
            }
        }

        public RoleDTO UpdateRole(RoleDTO role)
        {
            using (var entities = new AdministratorEntities())
            {
                entities.Roles.AddOrUpdate(_mapper.Map<Role>(role));
                var rol = entities.Roles.Single(r => r.RoleID == r.RoleID);
                entities.SaveChanges();
                return _mapper.Map<RoleDTO>(rol);
            }
        }
    }
}
