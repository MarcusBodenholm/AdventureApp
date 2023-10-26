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
            buttonPlay = new Button();
            buttonLoad = new Button();
            openFileDialog = new OpenFileDialog();
            SuspendLayout();
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelWelcome.Location = new Point(12, 9);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new Size(328, 32);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome to the Adventure!";
            // 
            // buttonPlay
            // 
            buttonPlay.Location = new Point(12, 43);
            buttonPlay.Margin = new Padding(3, 2, 3, 2);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(151, 38);
            buttonPlay.TabIndex = 3;
            buttonPlay.Text = "Start new game";
            buttonPlay.UseVisualStyleBackColor = true;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(189, 43);
            buttonLoad.Margin = new Padding(3, 2, 3, 2);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(151, 38);
            buttonLoad.TabIndex = 4;
            buttonLoad.Text = "Load save";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 87);
            Controls.Add(buttonLoad);
            Controls.Add(buttonPlay);
            Controls.Add(labelWelcome);
            Margin = new Padding(3, 2, 3, 2);
            Name = "WelcomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WelcomeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelWelcome;
        private Button buttonPlay;
        private Button buttonLoad;
        private OpenFileDialog openFileDialog;
    }
}