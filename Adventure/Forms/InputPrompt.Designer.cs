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
            labelQuestion = new Label();
            textItem = new TextBox();
            SuspendLayout();
            // 
            // labelQuestion
            // 
            labelQuestion.AutoSize = true;
            labelQuestion.Location = new Point(14, 12);
            labelQuestion.Name = "labelQuestion";
            labelQuestion.Size = new Size(91, 20);
            labelQuestion.TabIndex = 0;
            labelQuestion.Text = "Which item?";
            // 
            // textItem
            // 
            textItem.Location = new Point(14, 36);
            textItem.Margin = new Padding(3, 4, 3, 4);
            textItem.Name = "textItem";
            textItem.Size = new Size(227, 27);
            textItem.TabIndex = 0;
            textItem.KeyDown += textItem_KeyDown_1;
            // 
            // InputPrompt
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(253, 79);
            Controls.Add(textItem);
            Controls.Add(labelQuestion);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "InputPrompt";
            StartPosition = FormStartPosition.CenterParent;
            Text = "InputPrompt";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelQuestion;
        private TextBox textItem;
    }
}