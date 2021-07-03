using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Notepad
{
    public partial class Form1 : Form
    {
        String path = "";
        private object openFileDialog1;
        private object saveFileDialog1;

        public Form1() => InitializeComponent();


        private void exitPrompt() //Exit Prompt to pop up for user
        {
            DialogResult = MessageBox.Show("Do you want to save current file?",
            "iNote",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) //save
        {
            if (path != "")
            {
                File.WriteAllText(path, richTextBox1.Text);
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }



        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text != "") //Create New fle.Prompts user to proceed to create new file
            {
                exitPrompt();

                if (DialogResult == DialogResult.Yes) //if yes save file
                {
                    saveToolStripMenuItem_Click(sender, e);
                    richTextBox1.Text = "";
                    path = "";
                }

                else if (DialogResult == DialogResult.No) //dont save file but create new
                {
                    richTextBox1.Text = "";
                    path = "";
                }

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)//Save as Command
        {
          if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(path = saveFileDialog2.FileName, richTextBox1.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) //Open Command
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(path = openFileDialog2.FileName);    
            }
          
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked == true)
            {
                richTextBox1.WordWrap = false;
                richTextBox1.ScrollBars = ScrollBars.Both;
                wordWrapToolStripMenuItem.Checked = false;
            }
            else
            {

                richTextBox1.WordWrap = true;
                richTextBox1.ScrollBars = ScrollBars.Vertical;
                wordWrapToolStripMenuItem.Checked = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = richTextBox1.Font = new Font(fontDialog1.Font, fontDialog1.Font.Style);
                richTextBox1.ForeColor = fontDialog1.Color;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutForm = new Form2();
            aboutForm.ShowDialog();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
    }

