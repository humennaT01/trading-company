using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyWF
{
    public partial class PersonInfoForm : Form
    {
        private readonly long _id;
        private readonly PersonDTO person;
        protected readonly IAdminManager _adminManager;

        public PersonInfoForm(IAdminManager adminManager,long id)
        {
            InitializeComponent();
            _adminManager = adminManager;
            person = _adminManager.GetInfoAboutPerson(id);
            showInfo();
        }

        private void PersonInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void showInfo()
        {
            id.Text = person.PersonID.ToString();
            fName.Text = person.FirstName;
            lName.Text = person.LastName;
            if (person.Gender == true) gender.Text = "Man";
            else gender.Text = "Woman";
            address.Text = person.Address;
            phone.Text = person.Phone;
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
