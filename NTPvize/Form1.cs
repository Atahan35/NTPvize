using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace NTPvize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string xml_veri_linki = "https://www.mgm.gov.tr/FTPDATA/analiz/sonSOA.xml";

        string secilenBolge;
        string secilenIl;
        XmlNodeList nodes;

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument Belge1 = new XmlDocument();
            Belge1.Load(xml_veri_linki);
            XmlElement root = Belge1.DocumentElement;
            nodes = root.SelectNodes("sehirler");
            foreach (XmlNode item in nodes)
            {
                if (!comboBox1.Items.Contains(item.SelectSingleNode("Bolge").InnerText))
                {
                    comboBox1.Items.Add(item.SelectSingleNode("Bolge").InnerText);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilenBolge = comboBox1.SelectedItem.ToString();
            comboBox2.Items.Clear();
            foreach (XmlNode item in nodes)
            {
                if (item.SelectSingleNode("Bolge").InnerText==secilenBolge)
                {
                    comboBox2.Items.Add(item.SelectSingleNode("ili").InnerText);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            secilenIl = comboBox2.Text;
            foreach (XmlNode item in nodes)
            {
                if (item.SelectSingleNode("ili").InnerText==secilenIl)
                {
                    textBox1.Text = item.SelectSingleNode("Durum").InnerText;
                    textBox2.Text = item.SelectSingleNode("Mak").InnerText;
                    if (textBox1.Text.Contains("Parçalı"))
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "/clouds.png");
                    }
                    else if (textBox1.Text.Contains("Az"))
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "/cloudy.png");
                    }
                    else if (textBox1.Text.Contains("Açık"))
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "/sun.png");
                    }
                    else if (textBox1.Text.Contains("Yağmur"))
                    {
                        pictureBox1.Image = Image.FromFile(Application.StartupPath + "/rain.png");
                    }
                }
            }
        }
    }
}
