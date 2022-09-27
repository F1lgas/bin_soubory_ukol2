using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace bin_soubory_ukol2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"..\..\cisla.dat", FileMode.Create, FileAccess.Write);

            BinaryWriter bw = new BinaryWriter(fs);
            
            for (int i = 0; i < textBox1.Lines.Count(); i++)
            {
                bw.Write(textBox1.Lines[i] + Environment.NewLine);
            }

            fs.Close();
            bw.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();

            FileStream fs = new FileStream(@"..\..\cisla.dat", FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs);

            br.BaseStream.Position = 0;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                textBox2.AppendText(br.ReadString());
            }

            fs.Close();
            br.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();

            FileStream fs = new FileStream(@"..\..\cisla.dat", FileMode.Create, FileAccess.Write);

            BinaryWriter bw = new BinaryWriter(fs);

            int max = int.MinValue;
            int pozice_max = 0;

            for (int i = 0; i < textBox2.Lines.Count(); i++)
            {
                if (textBox2.Lines[i] == "")
                {
                    MessageBox.Show("Prázdný řádek!");
                }
                else
                {
                    if (max < Convert.ToInt32(textBox2.Lines[i]))
                    {
                        max = Convert.ToInt32(textBox2.Lines[i]);
                        pozice_max = i;
                    }
                }
            }

            for (int i = 0; i < textBox2.Lines.Count(); i++)
            {
                if (i == pozice_max)
                {
                    bw.Write(textBox2.Lines[textBox2.Lines.Count() - 1] + Environment.NewLine);
                }
                else if (i == (textBox2.Lines.Count() - 1))
                {
                    bw.Write(max + Environment.NewLine);
                }
                else
                {
                    bw.Write(textBox2.Lines[i] + Environment.NewLine);
                }
            }

            fs.Close();
            bw.Close();

            FileStream fs2 = new FileStream(@"..\..\cisla.dat", FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs2);

            br.BaseStream.Position = 0;
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                textBox3.AppendText(br.ReadString());
            }

            fs2.Close();
            bw.Close();
        }
    }
}
