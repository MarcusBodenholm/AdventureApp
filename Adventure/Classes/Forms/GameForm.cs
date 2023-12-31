﻿using Adventure.Classes.Extensions;
using Adventure.Classes.Models;
using AppLogic.Logic;

namespace Adventure
{
    public partial class GameForm : Form
    {
        public GameLogic? GameLogic { get; set; }
        public GameForm(string saveFile = "")
        {
            InitializeComponent();
            GameLogic = new GameLogic(saveFile);
            StartUpGame();
        }
        public void StartUpGame()
        {
            UpdateState(GameLogic.StateAtGameStart());
            string[] gameStartText = GameLogic.GameStart();
            UpdateLog(gameStartText[0], Color.Purple, new Outcome());
            UpdateLog(gameStartText[1], Color.Purple, new Outcome());
            UpdateLog(gameStartText[2], Color.Purple, new Outcome());
            UpdateLog(gameStartText[3], Color.Green, new Outcome());

        }
        public void UpdateLog(string message, Color color, Outcome outcome)
        {
            if (message.Contains("Player"))
            {
                richGameLog.AppendText(message, color, true);
                return;
            }
            if (outcome.NPC != null && message.StartsWith(outcome.NPC.Name))
            {
                richGameLog.AppendText(message, Color.Purple, true);
                return;
            }
            if (richGameLog.Text.Length > 0)
            {
                richGameLog.AppendText(message, color, true);
            }
            else
            {
                richGameLog.AppendText(message, color, false);
            }
            richGameLog.SelectionStart = richGameLog.Text.Length;
            richGameLog.ScrollToCaret();
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
        private void UpdateState(Outcome outcome)
        {
            currentLocation.Text = outcome.CurrentLocation;
            listPlayerItems.Items.Clear();
            foreach (var item in outcome.InventoryNames)
            {
                listPlayerItems.Items.Add(item);
            }
            if (outcome.HasWon)
            {
                MessageBox.Show("You have successfully escaped the house! Congratulations!");
                this.Close();
            }
        }
        private void HandleInput(string text)
        {
            Outcome outcome = GameLogic.DecisionTree(text);
            UpdateLog($"Player: {text}", Color.Red, outcome);
            UpdateLog(outcome.Message, Color.Green, outcome);
            textInput.Text = "";
            UpdateState(outcome);
        }
        private void textInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleInput(textInput.Text);
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

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveGame("autosave", false);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            InputPrompt input = new InputPrompt("Name the save file", "Name save file");
            input.ShowDialog();
            if (input.DialogResult == DialogResult.OK)
            {
                SaveGame(input.Input, true);
            }
            input.Dispose();
        }
        private void SaveGame(string saveFileName, bool toLog)
        {
            string saveMessage = GameLogic.SaveGame(saveFileName);
            if (toLog)
            {
                UpdateLog(saveMessage, Color.White, new Outcome());
            }
        }
    }

}
