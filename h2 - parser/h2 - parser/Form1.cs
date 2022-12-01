using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace h2___parser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string instructions = "CSV parser: choose a file and the program will parse every line deleting the separator"; 
            richTextBox1.AppendText(instructions + "\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            // we filter the files in order to open only csv files
            ofd.Title = "Open a CSV file";
            ofd.Filter = "CSV file|*.csv";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] csvText = System.IO.File.ReadAllLines(ofd.FileName);
                richTextBox1.Text = "SELECTED FILE: " + ofd.FileName + "\n-------------------------------------------------\n"; 

                for (int i=0; i < csvText.Length; i++)
                {
                    string[] data = csvText[i].Split('\n');

                    for(int j=0; j<data.Length; j++)
                    {
                        string[] token = data[j].Split(','); 

                        for(int k=0; k<token.Length; k++)
                        {
                            richTextBox1.AppendText(token[k] + "\n");
                        }
                    }
                }
            }
        }
    }
}
