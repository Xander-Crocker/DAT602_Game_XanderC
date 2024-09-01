﻿using DAT602_TileWars_XanderC_2023;
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
    public partial class RegistrationForm : Form
    {
        private RegistrationForm _register;
        private LoginForm _login;
        private MainScreenForm _home;
        
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            /*DatabaseAccessObject aDB = new DatabaseAccessObject();
            string aMessage = aDB.registerPlayer(this.FirstNameTextbox.Text, this.LastNameTextbox.Text, this.EmailTextbox.Text, this.UsernameTextbox.Text, this.PasswordTextbox.Text);
            MessageBox.Show(aMessage);

            DialogResult = DialogResult.OK;

            this.Hide();
            LoginForm _login = new LoginForm();
            _login.ShowDialog();*/

            /*DatabaseAccessObject dbRegister = new DatabaseAccessObject();

            switch (dbRegister.registerPlayer(this.EmailTextbox.Text, this.UsernameTextbox.Text, this.PasswordTextbox.Text))
            {
                case RegisterState.Success:

                    LoginForm loginPage = new LoginForm();
                    _login = new LoginForm();
                    this.Hide();
                    if (_login.ShowDialog(this, _playerClass))
                    {
                        this.Show();
                    };
                    break;
                default:
                    MessageBox.Show("Registration not successful try again");
                    break;
            }*/
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm _login = new LoginForm();
            _login.ShowDialog();
        }
    }
}