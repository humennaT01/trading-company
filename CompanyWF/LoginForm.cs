using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
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
    public partial class LoginForm : Form
    {
        protected readonly IAuthManager _authManager;
       

        public LoginForm(IAuthManager authManager)
        {
            InitializeComponent();
            this.passwordField.AutoSize = false;
            this.passwordField.Size = new Size(this.passwordField.Width,32);
            _authManager = authManager;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if(_authManager.Login(loginField.Text, passwordField.Text))
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("You've inputed wrong data!");
            }
        }

        private void Enter(object sender, KeyPressEventArgs e)
        {
            Login();
        }

        public long GetId()
        {
            return _authManager.GetId(loginField.Text);
        }

        public long GetRoleId()
        {
            return _authManager.GetRoleId(loginField.Text);
        }

        public long GetPersonId()
        {
            return _authManager.GetPersonId(loginField.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loginField.Text = "";
            passwordField.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                Login();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void passwordField_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
