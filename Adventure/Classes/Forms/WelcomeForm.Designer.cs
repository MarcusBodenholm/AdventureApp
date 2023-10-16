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
            SuspendLayout();
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelWelcome.Location = new Point(24, 30);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(405, 41);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome to the Adventure!";
            // 
            // labelEnterName
            // 
            labelEnterName.AutoSize = true;
            labelEnterName.Location = new Point(12, 90);
            labelEnterName.Name = "labelEnterName";
            labelEnterName.Size = new Size(425, 20);
            labelEnterName.TabIndex = 1;
            labelEnterName.Text = "Please enter your name and then press play to begin the game.";
            // 
            // textName
            // 
            textName.Location = new Point(12, 113);
            textName.Name = "textName";
            textName.Size = new Size(426, 27);
            textName.TabIndex = 2;
            // 
            // buttonPlay
            // 
            buttonPlay.Location = new Point(12, 146);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(426, 51);
            buttonPlay.TabIndex = 3;
            buttonPlay.Text = "Play";
            buttonPlay.UseVisualStyleBackColor = true;
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 212);
            Controls.Add(buttonPlay);
            Controls.Add(textName);
            Controls.Add(labelEnterName);
            Controls.Add(labelWelcome);
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
    }
}