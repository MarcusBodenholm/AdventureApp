﻿namespace Adventure.Classes.Forms
{
    partial class SelectLoadFile
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
            listSaves = new ListBox();
            labelSaveFiles = new Label();
            buttonLoad = new Button();
            buttonDelete = new Button();
            SuspendLayout();
            // 
            // listSaves
            // 
            listSaves.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            listSaves.FormattingEnabled = true;
            listSaves.ItemHeight = 36;
            listSaves.Location = new Point(12, 53);
            listSaves.Name = "listSaves";
            listSaves.Size = new Size(540, 256);
            listSaves.TabIndex = 0;
            // 
            // labelSaveFiles
            // 
            labelSaveFiles.AutoSize = true;
            labelSaveFiles.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            labelSaveFiles.Location = new Point(12, 9);
            labelSaveFiles.Name = "labelSaveFiles";
            labelSaveFiles.Size = new Size(150, 41);
            labelSaveFiles.TabIndex = 1;
            labelSaveFiles.Text = "Save files";
            // 
            // buttonLoad
            // 
            buttonLoad.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            buttonLoad.Location = new Point(12, 319);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(540, 50);
            buttonLoad.TabIndex = 2;
            buttonLoad.Text = "Load save";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDelete.Location = new Point(417, 9);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(135, 38);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Delete save";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // SelectLoadFile
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 381);
            Controls.Add(buttonDelete);
            Controls.Add(buttonLoad);
            Controls.Add(labelSaveFiles);
            Controls.Add(listSaves);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(5);
            Name = "SelectLoadFile";
            Text = "SelectLoadFile";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listSaves;
        private Label labelSaveFiles;
        private Button buttonLoad;
        private Button buttonDelete;
    }
}