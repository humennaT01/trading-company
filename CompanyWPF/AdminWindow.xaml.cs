using BusinessLogic.Interfaces;
using CompanyWPF.Models;
using CompanyWPF.Views;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CompanyWPF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private IAdminManager _adminManager;
        private UserListViewModel _userListView;
        CollectionViewSource _userCollection;
        private ShortUser _user;

        public AdminWindow(UserListViewModel vm, IAdminManager adminManager)
        {
            _adminManager = adminManager;
            _userCollection = (CollectionViewSource)(Resources["UserCollection"]);
            _userListView = vm;
            DataContext = vm;
            InitializeComponent();
        }

        private void Update()
        {
            _userListView.Update();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
            App.Current.Shutdown();
        }

        private void SortByLogin_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.Items.Refresh();
            var users = _userListView.ToShortUserList(_adminManager.SortedUsersByLogins());
            dataGrid.ItemsSource = users;
        }

        private void SortByEmail_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.Items.Refresh();
            var users = _userListView.ToShortUserList(_adminManager.SortedUsersByEmails());
            dataGrid.ItemsSource = users;
        }

        private void AllUsers_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.Items.Refresh();
            dataGrid.ItemsSource = _userListView.GetShortUsers();
        }

        private void BlockedUsers_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.Items.Refresh();
            var users = _userListView.ToShortUserList(_adminManager.GetAllUsers().Where(u => u.Status == true).ToList());
            dataGrid.ItemsSource = users;
        }

        private void ActiveUsers_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.Items.Refresh();
            var users = _userListView.ToShortUserList(_adminManager.GetAllUsers().Where(u => u.Status == false).ToList());
            dataGrid.ItemsSource = users;
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            if (findByEmail.Text != null && findByEmail.Text != "Email")
            {
                _user = _userListView.ToShortUser(_adminManager.FindUserByEmail(findByEmail.Text));
                if (_user != null)
                {
                    findByEmail.Text = "Email";
                    dataGrid.Items.Refresh();
                    dataGrid.ItemsSource = new List<ShortUser>() { _user };
                }
                else
                {
                    MessageBox.Show("There is no user with such login!");
                }
            }
            else if (findByLogin.Text != null && findByLogin.Text != "Login")
            {
                _user = _userListView.ToShortUser(_adminManager.FindUserByLogin(findByLogin.Text));
                if (_user != null)
                {
                    findByLogin.Text = "Login";
                    dataGrid.Items.Refresh();
                    dataGrid.ItemsSource = new List<ShortUser>() { _user };
                }
                else
                {
                    MessageBox.Show("There is no user with such email!");
                }
            }
            else
            {
                MessageBox.Show("You've don't input data!");
                findByEmail.Text = "Email";
                findByEmail.Text = "Login";
            }
        }

        private void UserInfoButton_Click(object sender, RoutedEventArgs e)
        {
            var Id = dataGrid.SelectedIndex;
            PersonInfoWindow piw = new PersonInfoWindow(_adminManager, Id);
            piw.ShowDialog();
        }

        private void BlockStaus_Click(object sender, RoutedEventArgs e)
        {
            var Id = dataGrid.SelectedIndex;
            _adminManager.BlockUser(Id + 1);
           
        }

        private void ActiveteStaus_Click(object sender, RoutedEventArgs e)
        {
            var Id = dataGrid.SelectedIndex;
            _adminManager.ActivateUser(Id + 1);
        }
    }
}
