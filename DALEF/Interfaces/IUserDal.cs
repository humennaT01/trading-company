using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DALEF.Interfaces
{
    public interface IUserDal
    {
        UserDTO GetUserById(int id);
        List<UserDTO> GetAllUser();
        UserDTO UpdateUser(UserDTO user);
        UserDTO CreateUser(UserDTO user);
        void DeleteUser(int id);


        bool Login(string username, string password);

    }
}
