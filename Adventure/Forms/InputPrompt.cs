using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure.Classes.Models
{
    public partial class InputPrompt : Form
    {
        public string ItemName { get; set; } = string.Empty;
        public InputPrompt()
        {
            InitializeComponent();
        }
        private void UserIsDone(object sender, EventArgs e)
        {
            ItemName = textItem.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            UserIsDone(sender, e);
        }

        private void textItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserIsDone(sender, e);
            }

        }
    }
}
