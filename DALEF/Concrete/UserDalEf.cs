using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography;
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
                entities.Users.AddOrUpdate(_mapper.Map<User>(user));
                var us = entities.Users.Single(u => u.UserID == user.UserID);
                entities.SaveChanges();
                return _mapper.Map<UserDTO>(us);
            }
        }



        public bool Login(string username, string password)
        {
            using (var ent = new AdministratorEntities())
            {
                User user = ent.Users.SingleOrDefault(u => u.Login == username);
                return user != null && user.Password.SequenceEqual(hash(password));
            }
        }

        private byte[] hash(string password)
        {
            byte[] data = new byte[64];
            for (int i = 0; i < password.Length; i++)
            {
                data[i] = Convert.ToByte(password[i]);
            }
            return data;
        }

        public long GetId(string login)
        {
            using (var entities = new AdministratorEntities())
            {
                var user = entities.Users.SingleOrDefault(u => u.Login == login);
                return user.UserID;
            }
        }

        public long GetRoleId(string userLogin)
        {
            using (var entities = new AdministratorEntities())
            {
                var user = entities.Users.SingleOrDefault(u => u.Login == userLogin);
                return (long)user.RoleID;

            }
        }

        public long GetPersonId(string userLogin)
        {
            using (var entities = new AdministratorEntities())
            {
                var user = entities.Users.SingleOrDefault(u => u.Login == userLogin);
                return (long)user.PersonID;

            }
        }
    }
}
