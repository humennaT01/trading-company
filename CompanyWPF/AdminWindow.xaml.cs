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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {

        private UserListViewModel _userListView;
        CollectionViewSource _userCollection;

        public AdminWindow(UserListViewModel vm)
        {
            _userCollection = (CollectionViewSource)(Resources["UserCollection"]);
            _userListView = vm;
            DataContext = vm;
            InitializeComponent();
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void FindByLoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
