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
            buttonUseItemOn = new Button();
            buttonExamineitem = new Button();
            buttonDropitem = new Button();
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
            richGameLog = new RichTextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaptionText;
            groupBox1.Controls.Add(buttonUseItemOn);
            groupBox1.Controls.Add(buttonExamineitem);
            groupBox1.Controls.Add(buttonDropitem);
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
            groupBox1.ForeColor = Color.Green;
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(870, 195);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Player";
            // 
            // buttonUseItemOn
            // 
            buttonUseItemOn.FlatAppearance.BorderColor = Color.Green;
            buttonUseItemOn.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonUseItemOn.Location = new Point(539, 124);
            buttonUseItemOn.Name = "buttonUseItemOn";
            buttonUseItemOn.Size = new Size(87, 28);
            buttonUseItemOn.TabIndex = 10;
            buttonUseItemOn.Text = "Use item on";
            buttonUseItemOn.UseVisualStyleBackColor = true;
            buttonUseItemOn.Click += buttonUseItemOn_Click;
            // 
            // buttonExamineitem
            // 
            buttonExamineitem.FlatAppearance.BorderColor = Color.Green;
            buttonExamineitem.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonExamineitem.Location = new Point(539, 90);
            buttonExamineitem.Name = "buttonExamineitem";
            buttonExamineitem.Size = new Size(87, 28);
            buttonExamineitem.TabIndex = 9;
            buttonExamineitem.Text = "Examine item";
            buttonExamineitem.UseVisualStyleBackColor = true;
            buttonExamineitem.Click += buttonExamineitem_Click;
            // 
            // buttonDropitem
            // 
            buttonDropitem.FlatAppearance.BorderColor = Color.Green;
            buttonDropitem.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonDropitem.Location = new Point(539, 56);
            buttonDropitem.Name = "buttonDropitem";
            buttonDropitem.Size = new Size(87, 28);
            buttonDropitem.TabIndex = 8;
            buttonDropitem.Text = "Drop item";
            buttonDropitem.UseVisualStyleBackColor = true;
            buttonDropitem.Click += buttonDropitem_Click;
            // 
            // buttonPickup
            // 
            buttonPickup.FlatAppearance.BorderColor = Color.Green;
            buttonPickup.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonPickup.Location = new Point(539, 22);
            buttonPickup.Name = "buttonPickup";
            buttonPickup.Size = new Size(87, 28);
            buttonPickup.TabIndex = 7;
            buttonPickup.Text = "Pick up item";
            buttonPickup.UseVisualStyleBackColor = true;
            buttonPickup.Click += buttonPickup_Click;
            // 
            // buttonLook
            // 
            buttonLook.FlatAppearance.BorderColor = Color.Green;
            buttonLook.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLook.Location = new Point(66, 115);
            buttonLook.Name = "buttonLook";
            buttonLook.Size = new Size(45, 22);
            buttonLook.TabIndex = 6;
            buttonLook.Text = "Look";
            buttonLook.UseVisualStyleBackColor = true;
            buttonLook.Click += buttonLook_Click;
            // 
            // currentLocation
            // 
            currentLocation.AutoSize = true;
            currentLocation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            currentLocation.Location = new Point(86, 29);
            currentLocation.Name = "currentLocation";
            currentLocation.Size = new Size(0, 21);
            currentLocation.TabIndex = 5;
            // 
            // labelLocation
            // 
            labelLocation.AutoSize = true;
            labelLocation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelLocation.Location = new Point(9, 29);
            labelLocation.Name = "labelLocation";
            labelLocation.Size = new Size(72, 21);
            labelLocation.TabIndex = 3;
            labelLocation.Text = "Location:";
            // 
            // button4
            // 
            button4.FlatAppearance.BorderColor = Color.Green;
            button4.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(77, 142);
            button4.Margin = new Padding(3, 2, 3, 2);
            button4.Name = "button4";
            button4.Size = new Size(22, 22);
            button4.TabIndex = 4;
            button4.Text = "South";
            button4.UseVisualStyleBackColor = true;
            button4.Click += DirectionButton_Click;
            // 
            // listPlayerItems
            // 
            listPlayerItems.BackColor = SystemColors.InactiveCaptionText;
            listPlayerItems.BorderStyle = BorderStyle.None;
            listPlayerItems.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            listPlayerItems.ForeColor = Color.Green;
            listPlayerItems.FormattingEnabled = true;
            listPlayerItems.ItemHeight = 21;
            listPlayerItems.Location = new Point(632, 19);
            listPlayerItems.Margin = new Padding(3, 2, 3, 2);
            listPlayerItems.Name = "listPlayerItems";
            listPlayerItems.Size = new Size(232, 168);
            listPlayerItems.TabIndex = 0;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderColor = Color.Green;
            button3.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(77, 88);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(22, 22);
            button3.TabIndex = 3;
            button3.Text = "North";
            button3.UseVisualStyleBackColor = true;
            button3.Click += DirectionButton_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.Green;
            button2.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(117, 115);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(22, 22);
            button2.TabIndex = 2;
            button2.Text = "East";
            button2.UseVisualStyleBackColor = true;
            button2.Click += DirectionButton_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderColor = Color.Green;
            button1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(38, 115);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(22, 22);
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
            gameLog.ItemHeight = 15;
            gameLog.Location = new Point(10, 208);
            gameLog.Margin = new Padding(3, 2, 3, 2);
            gameLog.Name = "gameLog";
            gameLog.SelectionMode = SelectionMode.None;
            gameLog.Size = new Size(870, 169);
            gameLog.TabIndex = 1;
            // 
            // textInput
            // 
            textInput.BackColor = SystemColors.InactiveCaptionText;
            textInput.BorderStyle = BorderStyle.FixedSingle;
            textInput.ForeColor = Color.Red;
            textInput.Location = new Point(10, 381);
            textInput.Margin = new Padding(3, 2, 3, 2);
            textInput.Name = "textInput";
            textInput.Size = new Size(870, 23);
            textInput.TabIndex = 0;
            textInput.KeyDown += textInput_KeyDown;
            // 
            // richGameLog
            // 
            richGameLog.BackColor = SystemColors.ActiveCaptionText;
            richGameLog.BorderStyle = BorderStyle.None;
            richGameLog.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point);
            richGameLog.Location = new Point(9, 208);
            richGameLog.Name = "richGameLog";
            richGameLog.ReadOnly = true;
            richGameLog.Size = new Size(871, 169);
            richGameLog.TabIndex = 11;
            richGameLog.Text = "";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(892, 415);
            Controls.Add(richGameLog);
            Controls.Add(textInput);
            Controls.Add(gameLog);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Text Adventure Game";
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
        private Button buttonDropitem;
        private Button buttonExamineitem;
        private Button buttonUseItemOn;
        private RichTextBox richGameLog;
    }
}