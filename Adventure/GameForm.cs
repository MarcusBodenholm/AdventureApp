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

namespace Adventure
{
    public partial class GameForm : Form
    {
        public GameLogic GameLogic { get; set; }
        public GameForm()
        {
            InitializeComponent();
            GameLogic = new GameLogic();
            GameLogic.HardCodeGameStart();
            UpdateStatus();
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
            gameLog.Items.Add(message);
            gameLog.TopIndex = gameLog.Items.Count - 1;
        }
        public void ClearLog()
        {
            gameLog.Items.Clear();
        }
        private void DirectionButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Directions direction;
            if (button.Text == "North") direction = Directions.North;
            if (button.Text == "East") direction = Directions.East;
            if (button.Text == "South") direction = Directions.South;
            if (button.Text == "West") direction = Directions.West;

            //Then do something with the direction
        }
        private void UpdateStatus()
        {
            Character PC = GameLogic.UpdateStatus();
            currentLocation.Text = PC.CurrentLocation.Name;
            listPlayerItems.Items.Clear();
            foreach (var item in PC.Items)
            {
                listPlayerItems.Items.Add(item.Name);
            }
        }
        private void textInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string message = GameLogic.Parser(textInput.Text);
                UpdateLog($"Player: {textInput.Text}");
                UpdateLog(message);
                textInput.Text = "";
            }
            UpdateStatus();
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
