using CompanyWPF.Views;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginWindow(LoginViewModel vm)
        {
            _loginViewModel = vm;
            DataContext = _loginViewModel;
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (_loginViewModel.Login(LoginField.Text, PasswordField.Text))
            {
                GetId();
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials", "Error");
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            PasswordField.Text = "";
            LoginField.Text = "";
        }

        public void GetId()
        {
            App.Id = _loginViewModel.GetId(LoginField.Text);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
