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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            textBoxPassword.Text = "Enter password";
            textBoxPassword.ForeColor = Color.FromName("InactiveCaption");
            textBoxLogin.Text = "Enter login";
            textBoxLogin.ForeColor = Color.FromName("InactiveCaption");
            textBoxEmail.Text = "Enter your e-mail";
            textBoxEmail.ForeColor = Color.FromName("InactiveCaption");
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

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if ((textBoxEmail.Text != "") && (textBoxEmail.Text == "Enter your e-mail"))
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.FromName("WindowText");
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

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                textBoxEmail.Text = "Enter your e-mail";
                textBoxEmail.ForeColor = Color.FromName("InactiveCaption");
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string email = textBoxEmail.Text;
            DialogResult dialogResult = MessageBox.Show("Are you sure?", "Confirmation page", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (OauthController.ConfirmRegistration(login, password, email))
                {
                    MessageBox.Show("Registration completed succefully");
                    Close();
                }
                else
                    MessageBox.Show("Registration failed");
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }

        private void textBoxLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!((c >= 'A' && c <= 'z') || ((c>='0' && c <='9')) || (c == (char)Keys.Back)))
                e.Handled = true;
            return;
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!((c >= 'A' && c <= 'z') || ((c >= '0' && c <= '9')) || (c == (char)Keys.Back)))
                e.Handled = true;
            return;
        }

        private void textBoxEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!((c >= 'A' && c <= 'z') || ((c >= '0' && c <= '9')) || (c == (char)Keys.Back) || (c=='@') || (c=='.')))
                e.Handled = true;
            return;
        }
    }
}
