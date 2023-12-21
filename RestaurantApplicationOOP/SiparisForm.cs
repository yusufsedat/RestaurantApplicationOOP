
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
    public partial class SiparisForm : Form

    {
        Siparis siparis = new Siparis();

        Restoran restoran;

        public SiparisForm()
        {
            InitializeComponent();
            
           
        }

        private void Ekle_Click(object sender, EventArgs e)
        {
            string yemekAdi = comboBoxYemekler.SelectedItem.ToString();
            int adet = (int)numericUpDown1.Value;
            
            siparis.YemekEkle(yemekAdi, adet);

            // Sipariş ekledikten sonra listeyi güncelle
            listView1.Items.Clear();
            foreach (var yemek in siparis.SiparisleriGetir())
            {
                listView1.Items.Add($"{yemek.YemekAdi} TL - {yemek.Adet} Adet");

                listView1.Items.Add($"");
            }



        }
       

        private void SiparisForm_Load(object sender, EventArgs e)
        {
          

            comboBoxYemekler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            string[] yemekDizi = YemekDosyalari.GetYemekler();
            comboBoxYemekler.Items.AddRange(yemekDizi); //yemekleri comboboxa ekliyoruz

            listView1.Columns.Add("YEMEK BİLGİLERİ , Fiyat - Adet", 450);
        
            listView1.View = View.Details;

        }

        private void comboBoxYemekler_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

       

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void Sil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string secilenSiparis = listView1.SelectedItems[0].Text;
                string yemekAdi = secilenSiparis.Split('-')[0].Trim();

                siparis.YemekSil(yemekAdi);

                // Sipariş sildikten sonra listeyi güncelle
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }

        }
    }
}
    