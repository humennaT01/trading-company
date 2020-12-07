using BusinessLogic.Interfaces;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;

namespace CompanyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected readonly IAdminManager _adminManager;
        public long Id;

        public MainWindow(IAdminManager adminManager)
        {
            _adminManager = adminManager;
            Id = App.Id;
            InitializeComponent();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lw = App.Container.Resolve<LoginWindow>();
            lw.ShowDialog();

            this.Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void GoToAdminPage_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow aw = App.Container.Resolve<AdminWindow>();
            aw.ShowDialog();
        }

        private void AccountInfo_Click(object sender, RoutedEventArgs e)
        {
            PersonInfoWindow piw = new PersonInfoWindow(_adminManager, Id);
            piw.ShowDialog();
        }

        private void LogOutFromMenu_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
