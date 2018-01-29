using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static System.Environment;

namespace ClearnRepeatFiles
{
    public partial class frmGetFloderFiles : Form
    {
        public frmGetFloderFiles()
        {
            InitializeComponent();
        }

        string folderPath = string.Empty;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            folderDialog.RootFolder = SpecialFolder.Desktop;
            folderDialog.SelectedPath = @"F:\Hyram\Downloads";

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderDialog.SelectedPath;
                var files = Directory.GetFiles(folderPath, "*.exe");


                List<FileVersionInfo> lstFileInfo = new List<FileVersionInfo>();
                foreach (var fileName in files)
                {
                    FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(fileName);

                    richTextBox1.AppendText(string.Format("Path：    {0}\n", fileName));
                    richTextBox1.AppendText(string.Format("Name：    {0}\n", fileInfo.ProductName));
                    richTextBox1.AppendText(string.Format("ProV：    {0}\n", fileInfo.ProductVersion));
                    richTextBox1.AppendText(string.Format("FilV：    {0}\n", fileInfo.FileVersion));
                    richTextBox1.AppendText(string.Format("IntV：    {0}\n", fileInfo.InternalName));
                    richTextBox1.AppendText(string.Format("CTO.：    {0}\n", fileInfo.CompanyName));

                    lstFileInfo.Add(fileInfo);

                    richTextBox1.AppendText("\n");
                }

                dataGridView1.DataSource = lstFileInfo;
            }
        }
    }
}
