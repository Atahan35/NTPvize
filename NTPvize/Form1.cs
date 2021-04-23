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
    }
}
