﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp2
{
    public partial class WordPad : Form
    {
        string pt = "";
        bool save_flag = false;
        int countss = 0;

        public WordPad()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {   
            this.Text = "Wordpad - Untitled";
            this.richTextBox1.Clear();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.FileName = "*.txt";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                if (!File.Exists(path)) //if file does not exits  
                {
                    // Create a file to write to.   
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        for (int i = 0; i < richTextBox1.Lines.Length; i++)
                        {
                            sw.WriteLine(richTextBox1.Lines[i]);
                        }

                    }
                }
                else if (File.Exists(path)) //if file is exist  
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        for (int i = 0; i < richTextBox1.Lines.Length; i++)
                        {
                            sw.WriteLine(richTextBox1.Lines[i]);
                        }

                    }
                }

            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText != "")
                {
                    richTextBox1.Font = fontDialog1.Font;
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                pt = path;
                int pos = path.LastIndexOf("\\");
                string ss = path.Substring(pos + 1);
                this.Text = "WordPad - " + ss;
                // Open the file to read from.   

                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        this.richTextBox1.AppendText(s + Environment.NewLine);

                        countss = countss + s.Length + 1;
                    }
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = form_close();
            this.richTextBox1.Clear();
            this.Text = "Wordpad - Untitled";
        }
        private string form_close()
        {
            string rtn_string = "";
            if (richTextBox1.Modified == true)
            {
                if (this.Text == "Wordpad - Untitled")
                {
                    DialogResult dr = MessageBox.Show("Do you want to save changes to Untitled ?", "Wordpad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        saveFileDialog1.DefaultExt = ".txt";
                        saveFileDialog1.FileName = "*.txt";
                        saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            string path = rtn_string = saveFileDialog1.FileName;
                            if (!File.Exists(path)) //if file does not exits  
                            {
                                // Create a file to write to.   
                                using (StreamWriter sw = File.CreateText(path))
                                {
                                    for (int i = 0; i < richTextBox1.Lines.Length; i++)
                                    {
                                        sw.WriteLine(richTextBox1.Lines[i]);
                                    }

                                }
                            }
                            else if (File.Exists(path)) //if file is exist  
                            {
                                using (StreamWriter sw = File.CreateText(path))
                                {
                                    for (int i = 0; i < richTextBox1.Lines.Length; i++)
                                    {
                                        sw.WriteLine(richTextBox1.Lines[i]);
                                    }

                                }
                            }

                        }

                    }

                }
                else //if text file is existing  
                {
                    // MessageBox.Show(richTextBox1.Text.Length+" "+countss);  
                    if (richTextBox1.Text.Length != countss || save_flag == false)
                    {
                        MessageBox.Show("Do you want to save changes to " + pt + " ?", "Notpad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        using (StreamWriter sw = File.CreateText(pt))
                        {
                            for (int i = 0; i < richTextBox1.Lines.Length; i++)
                            {
                                sw.WriteLine(richTextBox1.Lines[i]);
                            }

                        }
                    }
                }
            }
            return rtn_string;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "";
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.FileName = "*.txt";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                pt = path;
                if (!File.Exists(path)) //if file does not exits  
                {
                    // Create a file to write to.   
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        for (int i = 0; i < richTextBox1.Lines.Length; i++)
                        {
                            sw.WriteLine(richTextBox1.Lines[i]);
                            countss = countss + richTextBox1.Lines[i].Length + 1;
                            save_flag = true;
                        }

                    }
                    countss = countss - 1;
                }
                else if (File.Exists(path)) //if file is exist  
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        for (int i = 0; i < richTextBox1.Lines.Length; i++)
                        {
                            sw.WriteLine(richTextBox1.Lines[i]);
                            countss = countss + richTextBox1.Lines[i].Length + 1;
                            save_flag = true;
                        }

                    }
                }
            }
            int pos = path.LastIndexOf("\\");
            string ss = path.Substring(pos + 1);
            this.Text = "WordPad - " + ss;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            change_action();
        }
        private void change_action()
        {
            cutToolStripMenuItem.Enabled = false;
            copyToolStripMenuItem.Enabled = false;

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
            change_action();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText != "")
                {
                    richTextBox1.ForeColor = colorDialog1.Color;
                }
            }
        }
    }
}
