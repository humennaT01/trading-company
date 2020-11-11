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
    public partial class AdminForm : Form
    {
        protected readonly IAdminManager _adminManager;
        protected List<UserDTO> users;
        protected UserDTO _user;
        public string srt;

        public AdminForm(IAdminManager adminManager)
        {
            InitializeComponent();
            _user = new UserDTO();
            _adminManager = adminManager;
            showAll();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
          
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            long id = Convert.ToInt64(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[4].Value);
            if (dataGridView2.CurrentCell == dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3])
            {
                bool status = Convert.ToBoolean(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString());
                _user.Status = status;
                _user.UserID = (int)id;
            }
            else if (dataGridView2.CurrentCell is DataGridViewButtonCell)
            {
                //this.Hide();
                PersonInfoForm personInfo = new PersonInfoForm(_adminManager, id);
                personInfo.Show();
            }

        }

        private void userBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void showAll()
        {
            dataGridView2.Rows.Clear();
            users = _adminManager.GetAllUsers();
            foreach (UserDTO u in users)
            {
                dataGridView2.Rows.Add(u.UserID,
                    u.Login, u.Email, u.Status, u.PersonID);
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void activeUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            users = _adminManager.GetAllUsers().Where(u => u.Status == false).ToList();
            foreach (UserDTO u in users)
            {
                dataGridView2.Rows.Add(u.UserID,
                    u.Login, u.Email, u.Status, u.PersonID);
            }
        }

        private void blockedUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            users = _adminManager.GetAllUsers().Where(u => u.Status == true).ToList();
            foreach (UserDTO u in users)
            {
                dataGridView2.Rows.Add(u.UserID,
                    u.Login, u.Email, u.Status, u.PersonID);
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAll();
        }

        private void byEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            users = _adminManager.SortedUsersByEmails();
            foreach (UserDTO u in users)
            {
                dataGridView2.Rows.Add(u.UserID,
                    u.Login, u.Email, u.Status, u.PersonID);
            }
        }

        private void byLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            users = _adminManager.SortedUsersByLogins();
            foreach (UserDTO u in users)
            {
                dataGridView2.Rows.Add(u.UserID,
                    u.Login, u.Email, u.Status, u.PersonID);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_user.Status == true)
            {
                _adminManager.ActivateUser(_user.UserID);
            }
            else
            {
                _adminManager.BlockUser(_user.UserID);
            }
            DialogResult = DialogResult.OK;
        }

        private void findByLogin_TextChanged(object sender, EventArgs e)
        {
        }

        private void findByEmail_TextChanged(object sender, EventArgs e)
        {
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if(findByEmail.Text != null && findByEmail.Text != "Email")
            {
                _user = _adminManager.FindUserByEmail(findByEmail.Text);
                if (_user != null)
                {
                    findByEmail.Text = "Email";
                    dataGridView2.Rows.Clear();
                    dataGridView2.Rows.Add(_user.UserID, _user.Login, _user.Email, _user.Status, _user.PersonID);
                }
                else
                {
                    MessageBox.Show("There is no user with such login!");
                }
            }
            else if (findByLogin.Text != null && findByLogin.Text != "Login")
            {
                _user = _adminManager.FindUserByLogin(findByLogin.Text);
                if (_user != null)
                {
                    findByLogin.Text = "Login";
                    dataGridView2.Rows.Clear();
                    dataGridView2.Rows.Add(_user.UserID, _user.Login, _user.Email, _user.Status, _user.PersonID);
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
    }
}
