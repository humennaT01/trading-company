using BusinessLogic.Interfaces;
using DALEF.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace CompanyWF
{
    public partial class MainForm : Form
    {
        protected readonly IAdminManager _adminManager;
        private readonly long _id = Program.Id;
        private readonly long _roleId = Program.RoleId;
        private readonly long _personId = Program.PersonId;


        public MainForm(IAdminManager adminManager)
        {
            InitializeComponent();
            _adminManager = adminManager;
        }

        private void goToAdminPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_roleId == 1L)
            {
                this.Hide();
                AdminForm adminForm = new AdminForm(_adminManager);
                adminForm.Show();
            }
            else
            {
                MessageBox.Show("You do not have access to this page!");
            }
        }

        private void accountInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            PersonInfoForm personInfo = new PersonInfoForm(_adminManager,_personId);
            personInfo.Show();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
