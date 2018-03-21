using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Editor_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                openFileDialog1.FileName = "";
                openFileDialog1.Filter = "Text Files|*.txt";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                        {
                            richTextBox1.Clear();
                            while (!sr.EndOfStream)
                            {
                                String line = sr.ReadLine();
                                richTextBox1.AppendText(line + "\n");
                            }
                        }
                        filename = openFileDialog1.FileName;
                        file_opened = true;
                    }
                    catch
                    {
                        MessageBox.Show(openFileDialog1.FileName + " failed to open.");
                    }
                }

            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Text Files|*.txt";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(@"H:\test.txt")) ;
                    {
                        sw.Write(richTextBox1.Text);
                    }
                    filename = saveFileDialog1.FileName;
                    file_opened = true;
                }
                catch
                {
                    MessageBox.Show("test.txt Failed to save,");
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file_opened)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        sw.write(richTextBox1.Text);
                    }
                }
                catch
                {
                    MessageBox.Show(openFileDialog1.FileName + " failed to save.");
                }
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);

            }
        }
    }
}
