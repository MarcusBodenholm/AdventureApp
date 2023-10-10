using Adventure.Classes.Extensions;
using Adventure.Classes.Logic;
using Adventure.Classes.Models;

namespace Adventure
{
    public partial class GameForm : Form
    {
        public GameLogic GameLogic { get; set; }
        public GameForm()
        {
            InitializeComponent();
            GameLogic = new GameLogic();
            UpdateState();
            string[] gameStartText = GameLogic.GameStart();
            UpdateLog(gameStartText[0], Color.Purple);
            UpdateLog(gameStartText[1], Color.Purple);
            UpdateLog(gameStartText[2], Color.Green);
        }
        public void UpdateLog(string message, Color color)
        {
            if (message.Contains("Player"))
            {
                richGameLog.AppendText(message, color, true);
                return;
            }
            if (message.Contains("Rhys"))
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
        private void UpdateState()
        {
            GameState GameState = GameLogic.UpdateState();
            currentLocation.Text = GameState.GetCurrentLocationInfo();
            listPlayerItems.Items.Clear();
            foreach (var item in GameState.GetPlayerItems())
            {
                listPlayerItems.Items.Add(item);
            }
            if (GameState.IsWon)
            {
                GameState.TriggerEnd();
                this.Close();
            }
        }
        private void HandleInput(string text)
        {
            string message = GameLogic.DecisionTree(text);
            UpdateLog($"Player: {text}", Color.Red);
            UpdateLog(message, Color.Green);
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
    }

}
