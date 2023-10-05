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
            groupBox1 = new GroupBox();
            buttonPickup = new Button();
            buttonLook = new Button();
            currentLocation = new Label();
            labelLocation = new Label();
            button4 = new Button();
            listPlayerItems = new ListBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            gameLog = new ListBox();
            textInput = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonPickup);
            groupBox1.Controls.Add(buttonLook);
            groupBox1.Controls.Add(currentLocation);
            groupBox1.Controls.Add(labelLocation);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(listPlayerItems);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(11, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(751, 240);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Player";
            // 
            // buttonPickup
            // 
            buttonPickup.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPickup.Location = new Point(374, 29);
            buttonPickup.Margin = new Padding(3, 4, 3, 4);
            buttonPickup.Name = "buttonPickup";
            buttonPickup.Size = new Size(99, 37);
            buttonPickup.TabIndex = 7;
            buttonPickup.Text = "Pick up item";
            buttonPickup.UseVisualStyleBackColor = true;
            buttonPickup.Click += buttonPickup_Click;
            // 
            // buttonLook
            // 
            buttonLook.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLook.Location = new Point(75, 153);
            buttonLook.Margin = new Padding(3, 4, 3, 4);
            buttonLook.Name = "buttonLook";
            buttonLook.Size = new Size(51, 29);
            buttonLook.TabIndex = 6;
            buttonLook.Text = "Look";
            buttonLook.UseVisualStyleBackColor = true;
            buttonLook.Click += buttonLook_Click;
            // 
            // currentLocation
            // 
            currentLocation.AutoSize = true;
            currentLocation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            currentLocation.Location = new Point(98, 39);
            currentLocation.Name = "currentLocation";
            currentLocation.Size = new Size(0, 28);
            currentLocation.TabIndex = 5;
            // 
            // labelLocation
            // 
            labelLocation.AutoSize = true;
            labelLocation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelLocation.Location = new Point(10, 39);
            labelLocation.Name = "labelLocation";
            labelLocation.Size = new Size(91, 28);
            labelLocation.TabIndex = 3;
            labelLocation.Text = "Location:";
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(88, 189);
            button4.Name = "button4";
            button4.Size = new Size(25, 29);
            button4.TabIndex = 4;
            button4.Text = "South";
            button4.UseVisualStyleBackColor = true;
            button4.Click += DirectionButton_Click;
            // 
            // listPlayerItems
            // 
            listPlayerItems.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listPlayerItems.FormattingEnabled = true;
            listPlayerItems.ItemHeight = 28;
            listPlayerItems.Location = new Point(480, 29);
            listPlayerItems.Name = "listPlayerItems";
            listPlayerItems.Size = new Size(265, 200);
            listPlayerItems.TabIndex = 0;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(88, 117);
            button3.Name = "button3";
            button3.Size = new Size(25, 29);
            button3.TabIndex = 3;
            button3.Text = "North";
            button3.UseVisualStyleBackColor = true;
            button3.Click += DirectionButton_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(134, 153);
            button2.Name = "button2";
            button2.Size = new Size(25, 29);
            button2.TabIndex = 2;
            button2.Text = "East";
            button2.UseVisualStyleBackColor = true;
            button2.Click += DirectionButton_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(43, 153);
            button1.Name = "button1";
            button1.Size = new Size(25, 29);
            button1.TabIndex = 1;
            button1.Text = "West";
            button1.UseVisualStyleBackColor = true;
            button1.Click += DirectionButton_Click;
            // 
            // gameLog
            // 
            gameLog.FormattingEnabled = true;
            gameLog.HorizontalExtent = 500;
            gameLog.HorizontalScrollbar = true;
            gameLog.ItemHeight = 20;
            gameLog.Location = new Point(11, 295);
            gameLog.Name = "gameLog";
            gameLog.SelectionMode = SelectionMode.None;
            gameLog.Size = new Size(751, 144);
            gameLog.TabIndex = 1;
            // 
            // textInput
            // 
            textInput.Location = new Point(11, 261);
            textInput.Name = "textInput";
            textInput.Size = new Size(751, 27);
            textInput.TabIndex = 0;
            textInput.KeyDown += textInput_KeyDown;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(775, 455);
            Controls.Add(textInput);
            Controls.Add(gameLog);
            Controls.Add(groupBox1);
            Name = "GameForm";
            Text = "GameForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ListBox listPlayerItems;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private ListBox gameLog;
        private TextBox textInput;
        private Label currentLocation;
        private Label labelLocation;
        private Button buttonLook;
        private Button buttonPickup;
    }
}