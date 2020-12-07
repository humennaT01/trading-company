using BusinessLogic.Interfaces;
using CompanyWPF.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWPF.Views
{
    public class UserListViewModel
    {
        private IAdminManager _adminManager;
        //private ObservableCollection<UserDTO> _userList;
        private ObservableCollection<ShortUser> _userList;

        public UserListViewModel(IAdminManager adminManager)
        {
            _adminManager = adminManager;
            Update();
        }

        //public ObservableCollection<UserDTO> UserList
        //{
        //    get { return _userList; }
        //    set
        //    {
        //        _userList = value;
        //    }
        //}

        public ObservableCollection<ShortUser> UserList
        {
            get { return _userList; }
            set
            {
                _userList = value;
            }
        }

        public void Update()
        {
            UserList = new ObservableCollection<ShortUser>(GetShortUsers());
        }

        public List<ShortUser> GetShortUsers()
        {
            var fullListOfUsers = _adminManager.GetAllUsers();
            return ToShortUserList(fullListOfUsers);
        }

        public ShortUser ToShortUser(UserDTO u)
        {
            return new ShortUser
            {
                UserID = u.UserID,
                Login = u.Login,
                Email = u.Email,
                PersonID = u.PersonID,
                RoleID = u.RoleID,
                Status = u.Status
            };
        }

        public List<ShortUser> ToShortUserList(List<UserDTO> users)
        {
            var newList = new List<ShortUser>();
            foreach (UserDTO u in users)
            {
                newList.Add(new ShortUser
                {
                    UserID = u.UserID,
                    Login = u.Login,
                    Email = u.Email,
                    PersonID = u.PersonID,
                    RoleID = u.RoleID,
                    Status = u.Status
                });
            }
            return newList;
        }
    }
}
