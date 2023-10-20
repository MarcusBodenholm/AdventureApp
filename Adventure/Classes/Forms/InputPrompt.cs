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
        public string Input { get; set; } = string.Empty;
        public InputPrompt(string question, string title)
        {
            InitializeComponent();
            this.Text = title;
            labelQuestion.Text = question;
        }
        private void UserIsDone(object sender, EventArgs e)
        {
            Input = textItem.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void textItem_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserIsDone(sender, e);
            }

        }
    }
}
