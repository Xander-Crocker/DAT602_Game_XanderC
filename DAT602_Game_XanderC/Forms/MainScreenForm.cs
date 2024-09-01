using DAT602_TileWars_XanderC_2023;
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
    public partial class MainScreenForm : Form
    {
        private RegistrationForm _register;
        private LoginForm _login;
        private PlayerClass _playerClass;
        private AdminConsoleForm _adminForm;

        public MainScreenForm()
        {
            InitializeComponent();
        }

        public bool ShowDialog(LoginForm login, PlayerClass playerClass)
        {
            //_register = register;
            _login = login;
            _playerClass = playerClass;
            return ShowDialog() == DialogResult.OK; 
        }

        private void AdminConsoleButton_Click(object sender, EventArgs e)
        {
            _adminForm = new AdminConsoleForm();
            _playerClass = new PlayerClass();

            // Temp Fix
            this.Hide();
            _adminForm.ShowDialog();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            _login.Show();
            DialogResult = DialogResult.Cancel;
        }

        private void JoinGameButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            GameBoardForm _gameBoardForm = new GameBoardForm();
            _gameBoardForm.ShowDialog();
        }
    }
}
