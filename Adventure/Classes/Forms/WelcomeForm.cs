using Adventure.Classes.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                SelectLoadFile selection = new();
                selection.ShowDialog();
                if (selection.DialogResult == DialogResult.OK)
                {
                    string saveFilePath = selection.SelectedSave;
                    GameForm gameForm = new GameForm(saveFilePath);
                    this.Hide();
                    gameForm.ShowDialog();
                    gameForm.Close();
                    gameForm.Dispose();
                    this.Show();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("You have no save files.");
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            this.Hide();
            gameForm.ShowDialog();
            gameForm.Close();
            gameForm.Dispose();
            this.Show();
        }
    }
}
