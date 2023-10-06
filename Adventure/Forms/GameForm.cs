using Adventure.Classes.Logic;
using Adventure.Classes.Models;
using Adventure.Enums;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Adventure.Classes.Data;

namespace Adventure
{
    public partial class GameForm : Form
    {
        public GameLogic GameLogic { get; set; }
        public GameForm()
        {
            InitializeComponent();
            GameLogic = new GameLogic();
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                Button? button = control as Button;
                if (button != null)
                {
                    button.BackColor = Color.Black;
                }
            }
            UpdateState();
            string[] gameStartText = GameLogic.GameStart();
            foreach (var text in gameStartText)
            {
                UpdateLog(text);
            }
            //LocationBase location = XMLTEST2();
            //string message = $"{location.Name},{location.ID},{location.Description},{location.IsEndPoint},{location.Items[0].Name}";
            //MessageBox.Show(message);

        }
        public void UpdateLog(string message)
        {
            //gameLog.Items.Add(message);
            //gameLog.TopIndex = gameLog.Items.Count - 1;
            if (richGameLog.Text.Length > 0)
            {
                richGameLog.Text += $"\n{message}";
            }
            else
            {
                richGameLog.Text += message;
            }
            richGameLog.SelectionStart = richGameLog.Text.Length;
            richGameLog.ScrollToCaret();
            int lineCounter = 0;
            foreach (string line in richGameLog.Lines)
            {
                int idx = richGameLog.GetFirstCharIndexFromLine(lineCounter);
                if (line.Contains("Player"))
                {
                    richGameLog.Select(idx, line.Length);
                    richGameLog.SelectionColor = Color.Red;
                }
                else
                {
                    richGameLog.Select(idx, line.Length);
                    richGameLog.SelectionColor = Color.Green;
                }
                lineCounter++;
            }
        }
        public void ClearLog()
        {
            richGameLog.Text = "";
        }
        private void DirectionButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            HandleInput($"Go {button.Text}");
            textInput.Focus();
        }
        private void UpdateState()
        {
            GameState GameState = GameLogic.UpdateState();
            currentLocation.Text = GameState.GetCurrentLocationInfo();
            listPlayerItems.Items.Clear();
            foreach (var item in GameState.GetPlayerItems())
            {
                listPlayerItems.Items.Add(item);
            }
        }
        private void HandleInput(string text)
        {
            string message = GameLogic.DecisionTree(text);
            UpdateLog($"Player: {text}");
            UpdateLog(message);
            textInput.Text = "";
            UpdateState();
        }
        private void textInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleInput(textInput.Text);
                UpdateState();
                e.SuppressKeyPress = true;
            }
        }

        private void buttonLook_Click(object sender, EventArgs e)
        {
            HandleInput("look");
            textInput.Focus();
        }
        private string PromptUser(string question, string title)
        {
            InputPrompt prompt = new InputPrompt(question, title);
            prompt.ShowDialog();
            return prompt.Input;
        }
        private void buttonPickup_Click(object sender, EventArgs e)
        {
            HandleInput($"take {PromptUser("Which item do you want to take?", "Item")}");
            textInput.Focus();
        }

        private void buttonDropitem_Click(object sender, EventArgs e)
        {
            if (listPlayerItems.SelectedItem != null)
            {
                HandleInput($"drop {listPlayerItems.SelectedItem}");
            }
            textInput.Focus();
        }
        private void buttonExamineitem_Click(object sender, EventArgs e)
        {
            if (listPlayerItems.SelectedItem != null)
            {
                HandleInput($"examine {listPlayerItems.SelectedItem}");
            }
            textInput.Focus();

        }

        private void buttonUseItemOn_Click(object sender, EventArgs e)
        {
            if (listPlayerItems.SelectedItem != null)
            {
                HandleInput($"use {listPlayerItems.SelectedItem} on {PromptUser("What do you want to use it on?", "Use on")}");
            }
            textInput.Focus();
        }

        private void richGameLog_SelectionChanged(object sender, EventArgs e)
        {
            textInput.Focus();
        }

        private void richGameLog_Click(object sender, EventArgs e)
        {
            textInput.Focus();
        }

        //private ItemBase XMLTEST(string id)
        //{
        //    string filePath = @"C:\Users\marcu\source\Inlämningsuppgift 3\AdventureApp\Adventure\Classes\Items.xml";
        //    XDocument attempt = XDocument.Load(filePath);
        //    var items = attempt.Elements("Item");
        //    ItemBase output = new ItemBase();
        //    foreach (var item in items)
        //    {
        //        if (item.Attribute("id").Value == id)
        //        {
        //            output = new ItemBase();
        //            output.ID = int.Parse(item.Attribute("id").Value);
        //            output.Name = item.Element("Name").Value;
        //            output.Description = item.Element("Description").Value;
        //            output.UsableOn = item.Element("UsableOn").Value.Split(',').ToList();
        //        }
        //    }
        //    return output;
        //}
        //private LocationBase XMLTEST2()
        //{
        //    string filePath = @"C:\Users\marcu\source\Inlämningsuppgift 3\AdventureApp\Adventure\Classes\Locations.xml";
        //    XDocument attempt = XDocument.Load(filePath);
        //    var location = attempt.Elements("Location").Single(l => l.Attribute("id").Value == "0");
        //    LocationBase output = new LocationBase();
        //    output.Name = location.Element("Name").Value;
        //    output.Description = location.Element("Description").Value;
        //    output.Exits = new List<Exit>();
        //    output.IsEndPoint = bool.Parse(location.Element("IsEndPoint").Value);
        //    output.Items = new List<ItemBase>();
        //    List<string> itemIds = location.Element("Items").Value.Split(',').ToList();
        //    foreach (var itemid in itemIds)
        //    {
        //        ItemBase newItem = XMLTEST(itemid);
        //        output.Items.Add(newItem);
        //    }
        //    return output;

        //}
    }

}
