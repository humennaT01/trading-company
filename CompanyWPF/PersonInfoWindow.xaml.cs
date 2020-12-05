using BusinessLogic.Interfaces;
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
    /// Interaction logic for PersonInfoWindow.xaml
    /// </summary>
    public partial class PersonInfoWindow : Window
    {
        public long Id;
        private PersonDTO person;
        protected readonly IAdminManager _adminManager;

        public PersonInfoWindow(IAdminManager adminManager, long id)
        {
            Id = id;
            _adminManager = adminManager;
            person = _adminManager.GetInfoAboutPerson(Id);
            InitializeComponent();
            Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        public void Show()
        {
            FirstName.Text = person.FirstName;
            LastName.Text = person.LastName;
            if (person.Gender == true) Gender.Text = "Man";
            else Gender.Text = "Woman";
            Address.Text = person.Address;
            Phone.Text = person.Phone;
        }

        
    }
}
