namespace Adventure.Classes.Models
{
    partial class InputPrompt
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
            label1 = new Label();
            textItem = new TextBox();
            buttonDone = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "Which item?";
            // 
            // textItem
            // 
            textItem.Location = new Point(12, 27);
            textItem.Name = "textItem";
            textItem.Size = new Size(146, 23);
            textItem.TabIndex = 1;
            // 
            // buttonDone
            // 
            buttonDone.Location = new Point(164, 26);
            buttonDone.Name = "buttonDone";
            buttonDone.Size = new Size(57, 23);
            buttonDone.TabIndex = 2;
            buttonDone.Text = "Done";
            buttonDone.UseVisualStyleBackColor = true;
            buttonDone.Click += buttonDone_Click;
            // 
            // InputPrompt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(233, 59);
            Controls.Add(buttonDone);
            Controls.Add(textItem);
            Controls.Add(label1);
            Name = "InputPrompt";
            Text = "InputPrompt";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textItem;
        private Button buttonDone;
    }
}