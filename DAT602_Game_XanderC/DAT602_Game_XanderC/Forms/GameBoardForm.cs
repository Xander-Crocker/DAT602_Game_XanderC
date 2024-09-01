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
    public partial class GameBoardForm : Form
    {
        public GameBoardForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreenForm _homeForm = new MainScreenForm();
            _homeForm.ShowDialog();
        }
    }
}
