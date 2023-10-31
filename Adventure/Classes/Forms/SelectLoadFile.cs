using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adventure.Classes.Forms
{
    public partial class SelectLoadFile : Form
    {
        private string folderPath;
        public string SelectedSave { get; set; } = string.Empty;
        public SelectLoadFile()
        {
            InitializeComponent();
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            folderPath = $@"{documentsFolder}\TextAdventure\SaveFiles";
            if (!Directory.Exists(folderPath))
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                RefreshFiles();
            }
        }
        private void RefreshFiles()
        {
            listSaves.Items.Clear();
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                if (file.Contains(".savedata") == false) continue;
                SaveFile save = new(file);
                listSaves.Items.Add(save);
            }

        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            SaveFile? selectedSave = listSaves.SelectedItem as SaveFile;

            if (selectedSave == null)
            {
                return;
            }
            SelectedSave = selectedSave.FullPath;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SaveFile? selectedSave = listSaves.SelectedItem as SaveFile;
            if (selectedSave == null)
            {
                return;
            }
            DialogResult dr = MessageBox.Show($"Are you sure you want to delete: {selectedSave.Name}",
                                              "Delete",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);
            if (dr == DialogResult.No) return;
            string folderPath = selectedSave.FullPath.Substring(0, selectedSave.FullPath.Length - 9);
            File.Delete(selectedSave.FullPath);
            Directory.Delete(folderPath, true);
            RefreshFiles();
        }
    }
    public class SaveFile
    {
        public string FullPath { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public SaveFile(string path)
        {
            FullPath = path;
            Name = Path.GetFileName(path);
            CreatedAt = File.GetCreationTime(path);
        }
        public override string ToString()
        {
            return $"{Name} - {CreatedAt.Year}-{CreatedAt.Month}-{CreatedAt.Day} {CreatedAt.Hour}:{(CreatedAt.Minute < 10 ? $"0{CreatedAt.Minute}" : CreatedAt.Minute)}";
        }
    }
}
