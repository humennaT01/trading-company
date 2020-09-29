using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEF.Concrete
{
    public class UserDalEf : IUserDal
    {
        private readonly IMapper _mapper;

        public UserDalEf(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserDTO CreateUser(UserDTO user)
        {
            using (var entities = new AdministratorEntities())
            {
                User u = _mapper.Map<User>(user);
                entities.Users.Add(u);
                entities.SaveChanges();
                return _mapper.Map<UserDTO>(u);
            }
        }

        public void DeleteUser(int id)
        {
            using (var entities = new AdministratorEntities())
            {
                var u = entities.Users.SingleOrDefault(uu => uu.UserID == id);
                if (u == null)
                {
                    return;
                }
                entities.Users.Remove(u);
                entities.SaveChanges();
            }
        }

        public List<UserDTO> GetAllUser()
        {
            using (var entities = new AdministratorEntities())
            {
                var users = entities.Users.ToList();
                return _mapper.Map<List<UserDTO>>(users);
            }
        }

        public UserDTO GetUserById(int id)
        {
            using (var entities = new AdministratorEntities())
            {
                var user = entities.Users.SingleOrDefault(u => u.UserID == id);
                return _mapper.Map<UserDTO>(user);
            }
        }

        public UserDTO UpdateUser(UserDTO user)
        {
            using (var entities = new AdministratorEntities())
            {
                int id = user.PersonID;
                User u = _mapper.Map<User>(user);
                var oldUser = entities.Users.SingleOrDefault(uu => uu.UserID == id);
                if (oldUser != null && user != null)
                {
                    oldUser.Login = user.Login;
                    oldUser.Email = user.Email;
                    oldUser.Password = user.Password;
                    oldUser.Status = user.Status;
                    oldUser.PersonID = user.PersonID;
                    oldUser.RoleID = user.RoleID;
                    oldUser.RowUpdateTime = user.RowUpdateTime;
                }
                entities.SaveChanges();
                return _mapper.Map<UserDTO>(u);
            }
        }
    }
}
