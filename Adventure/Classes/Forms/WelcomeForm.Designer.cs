namespace Adventure
{
    partial class WelcomeForm
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
            labelWelcome = new Label();
            labelEnterName = new Label();
            textName = new TextBox();
            buttonPlay = new Button();
            buttonLoad = new Button();
            SuspendLayout();
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelWelcome.Location = new Point(21, 22);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(328, 32);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome to the Adventure!";
            // 
            // labelEnterName
            // 
            labelEnterName.AutoSize = true;
            labelEnterName.Location = new Point(10, 68);
            labelEnterName.Name = "labelEnterName";
            labelEnterName.Size = new Size(338, 15);
            labelEnterName.TabIndex = 1;
            labelEnterName.Text = "Please enter your name and then press play to begin the game.";
            // 
            // textName
            // 
            textName.Location = new Point(10, 85);
            textName.Margin = new Padding(3, 2, 3, 2);
            textName.Name = "textName";
            textName.Size = new Size(373, 23);
            textName.TabIndex = 2;
            // 
            // buttonPlay
            // 
            buttonPlay.Location = new Point(10, 110);
            buttonPlay.Margin = new Padding(3, 2, 3, 2);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(151, 38);
            buttonPlay.TabIndex = 3;
            buttonPlay.Text = "Play";
            buttonPlay.UseVisualStyleBackColor = true;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(223, 110);
            buttonLoad.Margin = new Padding(3, 2, 3, 2);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(151, 38);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(395, 159);
            Controls.Add(buttonLoad);
            Controls.Add(buttonPlay);
            Controls.Add(textName);
            Controls.Add(labelEnterName);
            Controls.Add(labelWelcome);
            Margin = new Padding(3, 2, 3, 2);
            Name = "WelcomeForm";
            Text = "WelcomeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelWelcome;
        private Label labelEnterName;
        private TextBox textName;
        private Button buttonPlay;
        private Button buttonLoad;
    }
}