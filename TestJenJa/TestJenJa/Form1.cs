using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestJenJa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("*"))
            {
                try
                {
                    int cislo = int.Parse(textBox1.Text);
                    if (JePrvocislo(cislo))
                        label1.Text = "Je prvočíslo.";
                    else
                        label1.Text = "Není prvočíslo.";
                }
                catch(FormatException)
                {
                    MessageBox.Show("Musíte zadat číslo.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Příliš velké nebo malé číslo.");
                }
                catch (Exception x)
                {
                    MessageBox.Show("Chyba. "+x.Message);
                }
                textBox1.Text = "";
                textBox1.Focus();
            } else
            {
                button1.Enabled = false;
                textBox1.Text = "";
                textBox1.Enabled = false;
                label1.Text = "Konec posloupnosti.";
            }
        }

        bool JePrvocislo(int x)
        {
            bool je = x > 1&&(x%2!=0||x==2);
            for(int i = 3;i<=Math.Sqrt(x)&&je;i++)
            {
                je = x%i!=0;
            }
            return je;
        }
    }
}
