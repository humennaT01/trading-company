using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IAdminManager
    {
        UserDTO ActivateUser(long id);
        UserDTO BlockUser(long id);
        UserDTO FindUserByEmail(string email);
        UserDTO FindUserByLogin(string login);
        List<UserDTO> SortedUsersByEmails();
        List<UserDTO> SortedUsersByLogins();
        List<UserDTO> GetAllUsers();
        PersonDTO GetInfoAboutPerson(long id);

        UserDTO CreateUser(UserDTO user);
        UserDTO UpdateUser(UserDTO user);
        void DeleteUser(long id);
        UserDTO GetUser(long id);
        List<RoleDTO> GetAllRoles();
        List<PersonDTO> GetAllPeople();

    }
}
