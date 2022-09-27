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

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox5.Clear();

            FileStream fs = new FileStream(@"..\..\cisla.dat", FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs);

            FileStream fs2 = new FileStream(@"..\..\prvocisla.dat", FileMode.Create, FileAccess.ReadWrite);

            BinaryWriter bw = new BinaryWriter(fs2);
            BinaryReader br2 = new BinaryReader(fs2);

            StreamWriter sw = new StreamWriter(@"..\..\prvocisla.txt", false);

            br.BaseStream.Position = 0;

            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                if (prvocislo(Convert.ToInt32(br.ReadString())))
                {
                    bw.Write(Convert.ToInt32(br.ReadString()) + Environment.NewLine);
                    sw.WriteLine(br.ReadString());
                }
                //sw.Write(cislo + Environment.NewLine);
            }
            sw.Close();

            StreamReader sr = new StreamReader(@"..\..\prvocisla.txt");

            br2.BaseStream.Position = 0;
            while (br2.BaseStream.Position < br2.BaseStream.Length)
            {
                textBox4.AppendText(br2.ReadString());
                textBox5.AppendText(sr.ReadLine());
            }

            fs.Close();
            br.Close();
            fs2.Close();
            bw.Close();
            br2.Close();
            sr.Close();
        }

        private bool prvocislo(int cislo)
        {
            /*if (cislo <= 1)
            {
                return false;
            }
            if (cislo == 2)
            {
                return true;
            }
            if (cislo % 2 == 0)
            {
                return false;
            }

            var cislo2 = (int)Math.Floor(Math.Sqrt(cislo));

            for (int i = 3; i <= cislo2; i += 2)
            {
                if (cislo % i == 0)
                {
                    return false;
                }
            }
            return true;*/

            if (cislo == 1 || cislo == 2)
            {
                return true;
            }

            for (int i = 2; i < (cislo / 2); i++)
            {
                if (cislo % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
