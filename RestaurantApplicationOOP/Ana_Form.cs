
/*****************************************************************************************************
**					                   SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				       NESNEYE DAYALI PROGRAMLAMA DERSİ 2022 YAZ DÖNEMİ
**					
**	
**				ÖDEV NUMARASI..........: Proje 1
**				ÖĞRENCİ ADI............: Yusuf Sedat Sağaltıcı
**				ÖĞRENCİ NUMARASI.......: B201210031
**              DERSİN ALINDIĞI GRUP...: 1-A
**
****************************************************************************************************/






using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApplicationOOP
{
    public partial class Ana_Form : Form
    {
        public Ana_Form()
        {
            InitializeComponent();
        }

        private void Siparis_Click(object sender, EventArgs e)
        {
            SiparisForm spr = new SiparisForm();

            spr.Show();
        }

        private void Depo_Click(object sender, EventArgs e)
        {
            DepoForm depo = new DepoForm();

            depo.Show();

        }

        private void Yemek_Click(object sender, EventArgs e)
        {
            YemekForm yemek = new YemekForm();

            yemek.Show();
        }

        private void Ana_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
