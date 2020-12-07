using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyWPF.Views
{
    public class LoginViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            private get;
            set;
        }

        private readonly IAuthManager _authManager;

        public LoginViewModel(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        public bool Login(string username, string password)
        {
            return _authManager.Login(username, password);
        }

        public long GetId(string username)
        {
            return _authManager.GetId(username);
        }
    }
}
