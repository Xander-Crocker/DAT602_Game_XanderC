using DAT602_TileWars_XanderC_2023;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAT602_TileWars_XanderC_2023
{
    public partial class LoginForm : Form
    {
        private LoginForm _login;
        private MainScreenForm _home;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm _Register = new RegistrationForm();
            _Register.ShowDialog();
        }

        private void LoginLoginButton_Click(object sender, EventArgs e)
        {
            DatabaseAccessObject dbLogin = new DatabaseAccessObject();

            switch (dbLogin.Login(LoginUsernameTextbox.Text, LoginPasswordTextbox.Text))
            {
                case LoginState.Success:

                    MainScreenForm homePage = new MainScreenForm(); 
                    _home = new MainScreenForm();
                    this.Hide();
                    if (_home.ShowDialog(this, _playerClass))
                    {
                        this.Show();
                    };
                    break;
                case LoginState.Locked_out:
                    MessageBox.Show("Login not successful too many tries, sorry account locked out.");
                    break;
                default:
                    MessageBox.Show("Login not successful try again");
                    break;
            }
        }
    }
}