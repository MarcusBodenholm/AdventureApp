namespace Adventure
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBoxPlayer = new GroupBox();
            buttonSave = new Button();
            labelInventory = new Label();
            buttonUseItemOn = new Button();
            buttonExamineitem = new Button();
            buttonDropitem = new Button();
            buttonPickup = new Button();
            buttonLook = new Button();
            currentLocation = new Label();
            labelLocation = new Label();
            buttonSouth = new Button();
            listPlayerItems = new ListBox();
            buttonNorth = new Button();
            buttonEast = new Button();
            buttonWest = new Button();
            textInput = new TextBox();
            richGameLog = new RichTextBox();
            panelTextBox = new Panel();
            saveFile = new SaveFileDialog();
            groupBoxPlayer.SuspendLayout();
            panelTextBox.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxPlayer
            // 
            groupBoxPlayer.BackColor = SystemColors.ActiveCaptionText;
            groupBoxPlayer.Controls.Add(buttonSave);
            groupBoxPlayer.Controls.Add(labelInventory);
            groupBoxPlayer.Controls.Add(buttonUseItemOn);
            groupBoxPlayer.Controls.Add(buttonExamineitem);
            groupBoxPlayer.Controls.Add(buttonDropitem);
            groupBoxPlayer.Controls.Add(buttonPickup);
            groupBoxPlayer.Controls.Add(buttonLook);
            groupBoxPlayer.Controls.Add(currentLocation);
            groupBoxPlayer.Controls.Add(labelLocation);
            groupBoxPlayer.Controls.Add(buttonSouth);
            groupBoxPlayer.Controls.Add(listPlayerItems);
            groupBoxPlayer.Controls.Add(buttonNorth);
            groupBoxPlayer.Controls.Add(buttonEast);
            groupBoxPlayer.Controls.Add(buttonWest);
            groupBoxPlayer.Font = new Font("Courier New", 17.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBoxPlayer.ForeColor = Color.Green;
            groupBoxPlayer.Location = new Point(10, 9);
            groupBoxPlayer.Margin = new Padding(3, 2, 3, 2);
            groupBoxPlayer.Name = "groupBoxPlayer";
            groupBoxPlayer.Padding = new Padding(3, 2, 3, 2);
            groupBoxPlayer.Size = new Size(870, 195);
            groupBoxPlayer.TabIndex = 0;
            groupBoxPlayer.TabStop = false;
            groupBoxPlayer.Text = "Player";
            // 
            // buttonSave
            // 
            buttonSave.FlatAppearance.BorderColor = Color.Green;
            buttonSave.FlatAppearance.MouseDownBackColor = Color.White;
            buttonSave.FlatAppearance.MouseOverBackColor = Color.White;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSave.Location = new Point(539, 158);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(87, 28);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = false;
            buttonSave.Click += buttonSave_Click;
            // 
            // labelInventory
            // 
            labelInventory.AutoSize = true;
            labelInventory.Font = new Font("Courier New", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelInventory.Location = new Point(632, 16);
            labelInventory.Margin = new Padding(0, 0, 3, 0);
            labelInventory.Name = "labelInventory";
            labelInventory.Size = new Size(109, 22);
            labelInventory.TabIndex = 11;
            labelInventory.Text = "Inventory";
            // 
            // buttonUseItemOn
            // 
            buttonUseItemOn.FlatAppearance.BorderColor = Color.Green;
            buttonUseItemOn.FlatAppearance.MouseDownBackColor = Color.White;
            buttonUseItemOn.FlatAppearance.MouseOverBackColor = Color.White;
            buttonUseItemOn.FlatStyle = FlatStyle.Flat;
            buttonUseItemOn.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUseItemOn.Location = new Point(539, 124);
            buttonUseItemOn.Name = "buttonUseItemOn";
            buttonUseItemOn.Size = new Size(87, 28);
            buttonUseItemOn.TabIndex = 10;
            buttonUseItemOn.Text = "Use item on";
            buttonUseItemOn.UseVisualStyleBackColor = false;
            buttonUseItemOn.Click += buttonUseItemOn_Click;
            // 
            // buttonExamineitem
            // 
            buttonExamineitem.FlatAppearance.BorderColor = Color.Green;
            buttonExamineitem.FlatAppearance.MouseDownBackColor = Color.White;
            buttonExamineitem.FlatAppearance.MouseOverBackColor = Color.White;
            buttonExamineitem.FlatStyle = FlatStyle.Flat;
            buttonExamineitem.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonExamineitem.Location = new Point(539, 90);
            buttonExamineitem.Name = "buttonExamineitem";
            buttonExamineitem.Size = new Size(87, 28);
            buttonExamineitem.TabIndex = 9;
            buttonExamineitem.Text = "Examine item";
            buttonExamineitem.UseVisualStyleBackColor = false;
            buttonExamineitem.Click += buttonExamineitem_Click;
            // 
            // buttonDropitem
            // 
            buttonDropitem.FlatAppearance.BorderColor = Color.Green;
            buttonDropitem.FlatAppearance.MouseDownBackColor = Color.White;
            buttonDropitem.FlatAppearance.MouseOverBackColor = Color.White;
            buttonDropitem.FlatStyle = FlatStyle.Flat;
            buttonDropitem.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDropitem.Location = new Point(539, 56);
            buttonDropitem.Name = "buttonDropitem";
            buttonDropitem.Size = new Size(87, 28);
            buttonDropitem.TabIndex = 8;
            buttonDropitem.Text = "Drop item";
            buttonDropitem.UseVisualStyleBackColor = false;
            buttonDropitem.Click += buttonDropitem_Click;
            // 
            // buttonPickup
            // 
            buttonPickup.FlatAppearance.BorderColor = Color.Green;
            buttonPickup.FlatAppearance.MouseDownBackColor = Color.White;
            buttonPickup.FlatAppearance.MouseOverBackColor = Color.White;
            buttonPickup.FlatStyle = FlatStyle.Flat;
            buttonPickup.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPickup.Location = new Point(539, 22);
            buttonPickup.Name = "buttonPickup";
            buttonPickup.Size = new Size(87, 28);
            buttonPickup.TabIndex = 7;
            buttonPickup.Text = "Pick up item";
            buttonPickup.UseVisualStyleBackColor = false;
            buttonPickup.Click += buttonPickup_Click;
            // 
            // buttonLook
            // 
            buttonLook.FlatAppearance.BorderColor = Color.Green;
            buttonLook.FlatAppearance.MouseDownBackColor = Color.White;
            buttonLook.FlatAppearance.MouseOverBackColor = Color.White;
            buttonLook.FlatStyle = FlatStyle.Flat;
            buttonLook.Font = new Font("Courier New", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLook.Location = new Point(66, 115);
            buttonLook.Name = "buttonLook";
            buttonLook.Size = new Size(45, 22);
            buttonLook.TabIndex = 6;
            buttonLook.Text = "Look";
            buttonLook.UseVisualStyleBackColor = false;
            buttonLook.Click += buttonLook_Click;
            // 
            // currentLocation
            // 
            currentLocation.AutoSize = true;
            currentLocation.Font = new Font("Courier New", 12F, FontStyle.Italic, GraphicsUnit.Point);
            currentLocation.Location = new Point(106, 32);
            currentLocation.Name = "currentLocation";
            currentLocation.Size = new Size(0, 19);
            currentLocation.TabIndex = 5;
            // 
            // labelLocation
            // 
            labelLocation.AutoSize = true;
            labelLocation.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelLocation.Location = new Point(13, 32);
            labelLocation.Name = "labelLocation";
            labelLocation.Size = new Size(98, 18);
            labelLocation.TabIndex = 3;
            labelLocation.Text = "Location:";
            // 
            // buttonSouth
            // 
            buttonSouth.FlatAppearance.BorderColor = Color.Green;
            buttonSouth.FlatAppearance.MouseDownBackColor = Color.White;
            buttonSouth.FlatAppearance.MouseOverBackColor = Color.White;
            buttonSouth.FlatStyle = FlatStyle.Flat;
            buttonSouth.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonSouth.Location = new Point(77, 142);
            buttonSouth.Margin = new Padding(3, 2, 3, 2);
            buttonSouth.Name = "buttonSouth";
            buttonSouth.Size = new Size(22, 22);
            buttonSouth.TabIndex = 4;
            buttonSouth.Text = "South";
            buttonSouth.UseVisualStyleBackColor = false;
            buttonSouth.Click += DirectionButton_Click;
            // 
            // listPlayerItems
            // 
            listPlayerItems.BackColor = SystemColors.InactiveCaptionText;
            listPlayerItems.BorderStyle = BorderStyle.None;
            listPlayerItems.Font = new Font("Courier New", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            listPlayerItems.ForeColor = Color.Green;
            listPlayerItems.FormattingEnabled = true;
            listPlayerItems.ItemHeight = 17;
            listPlayerItems.Location = new Point(637, 43);
            listPlayerItems.Margin = new Padding(3, 2, 3, 2);
            listPlayerItems.Name = "listPlayerItems";
            listPlayerItems.Size = new Size(227, 136);
            listPlayerItems.TabIndex = 0;
            // 
            // buttonNorth
            // 
            buttonNorth.FlatAppearance.BorderColor = Color.Green;
            buttonNorth.FlatAppearance.MouseDownBackColor = Color.White;
            buttonNorth.FlatAppearance.MouseOverBackColor = Color.White;
            buttonNorth.FlatStyle = FlatStyle.Flat;
            buttonNorth.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonNorth.Location = new Point(77, 88);
            buttonNorth.Margin = new Padding(3, 2, 3, 2);
            buttonNorth.Name = "buttonNorth";
            buttonNorth.Size = new Size(22, 22);
            buttonNorth.TabIndex = 3;
            buttonNorth.Text = "North";
            buttonNorth.UseVisualStyleBackColor = false;
            buttonNorth.Click += DirectionButton_Click;
            // 
            // buttonEast
            // 
            buttonEast.FlatAppearance.BorderColor = Color.Green;
            buttonEast.FlatAppearance.MouseDownBackColor = Color.White;
            buttonEast.FlatAppearance.MouseOverBackColor = Color.White;
            buttonEast.FlatStyle = FlatStyle.Flat;
            buttonEast.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonEast.Location = new Point(117, 115);
            buttonEast.Margin = new Padding(3, 2, 3, 2);
            buttonEast.Name = "buttonEast";
            buttonEast.Size = new Size(22, 22);
            buttonEast.TabIndex = 2;
            buttonEast.Text = "East";
            buttonEast.UseVisualStyleBackColor = false;
            buttonEast.Click += DirectionButton_Click;
            // 
            // buttonWest
            // 
            buttonWest.FlatAppearance.BorderColor = Color.Green;
            buttonWest.FlatAppearance.MouseDownBackColor = Color.White;
            buttonWest.FlatAppearance.MouseOverBackColor = Color.White;
            buttonWest.FlatStyle = FlatStyle.Flat;
            buttonWest.Font = new Font("Courier New", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonWest.Location = new Point(38, 115);
            buttonWest.Margin = new Padding(3, 2, 3, 2);
            buttonWest.Name = "buttonWest";
            buttonWest.Size = new Size(22, 22);
            buttonWest.TabIndex = 1;
            buttonWest.Text = "West";
            buttonWest.UseVisualStyleBackColor = false;
            buttonWest.Click += DirectionButton_Click;
            // 
            // textInput
            // 
            textInput.BackColor = SystemColors.InactiveCaptionText;
            textInput.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textInput.ForeColor = Color.Red;
            textInput.Location = new Point(9, 381);
            textInput.Margin = new Padding(3, 2, 3, 2);
            textInput.Name = "textInput";
            textInput.Size = new Size(871, 22);
            textInput.TabIndex = 0;
            textInput.KeyDown += textInput_KeyDown;
            // 
            // richGameLog
            // 
            richGameLog.BackColor = SystemColors.ActiveCaptionText;
            richGameLog.BorderStyle = BorderStyle.None;
            richGameLog.DetectUrls = false;
            richGameLog.Dock = DockStyle.Fill;
            richGameLog.Font = new Font("Courier New", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            richGameLog.ForeColor = Color.Green;
            richGameLog.Location = new Point(0, 0);
            richGameLog.Name = "richGameLog";
            richGameLog.ReadOnly = true;
            richGameLog.Size = new Size(871, 167);
            richGameLog.TabIndex = 11;
            richGameLog.TabStop = false;
            richGameLog.Text = "";
            richGameLog.SelectionChanged += richGameLog_SelectionChanged;
            // 
            // panelTextBox
            // 
            panelTextBox.Controls.Add(richGameLog);
            panelTextBox.Location = new Point(9, 209);
            panelTextBox.Name = "panelTextBox";
            panelTextBox.Size = new Size(871, 167);
            panelTextBox.TabIndex = 1;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(892, 415);
            Controls.Add(panelTextBox);
            Controls.Add(textInput);
            Controls.Add(groupBoxPlayer);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Text Adventure Game";
            FormClosing += GameForm_FormClosing;
            groupBoxPlayer.ResumeLayout(false);
            groupBoxPlayer.PerformLayout();
            panelTextBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBoxPlayer;
        private ListBox listPlayerItems;
        private Button buttonWest;
        private Button buttonEast;
        private Button buttonNorth;
        private Button buttonSouth;
        private TextBox textInput;
        private Label currentLocation;
        private Label labelLocation;
        private Button buttonLook;
        private Button buttonPickup;
        private Button buttonDropitem;
        private Button buttonExamineitem;
        private Button buttonUseItemOn;
        private RichTextBox richGameLog;
        private Label labelInventory;
        private Panel panelTextBox;
        private Button buttonSave;
        private SaveFileDialog saveFile;
    }
}