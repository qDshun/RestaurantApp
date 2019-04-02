using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBoxPassword.Text = "Enter password";
            textBoxPassword.ForeColor = Color.FromName("InactiveCaption");
            textBoxLogin.Text = "Enter login";
            textBoxLogin.ForeColor = Color.FromName("InactiveCaption");
        }

        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            if ((textBoxLogin.Text != "") && (textBoxLogin.Text == "Enter login"))
            {
                textBoxLogin.Text = "";
                textBoxLogin.ForeColor = Color.FromName("WindowText");
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if ((textBoxPassword.Text != "") && (textBoxPassword.Text == "Enter password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.FromName("WindowText");
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "")
            {
                textBoxPassword.Text = "Enter password";
                textBoxPassword.ForeColor = Color.FromName("InactiveCaption");
            }
        }

        private void textBoxLogin_Leave(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                textBoxLogin.Text = "Enter login";
                textBoxLogin.ForeColor = Color.FromName("InactiveCaption");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            if (OauthController.CheckAutorization(login, password))
            {
                MessageBox.Show("Done!");
                MainForm f = new MainForm();
                f.Show();
            }
            else
                MessageBox.Show("Authorization failed");
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Register reg = new Register();
            reg.ShowDialog();
        }
    }
}
