


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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantApplicationOOP
{
    public partial class YemekForm : Form
    {
        public SiparisForm siparisForm;
        string malzemeDosyasi = YemekDosyalari.MalzemeDosyasi;
       


        public YemekForm()
        {

            InitializeComponent();
                        
        }

        
            

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string yemekCesidi = comboBox1.SelectedItem.ToString();
            string yemekAdi =txtYemekAdi.Text;
            string malzemeler = txtMalzemeler.Text;
            float fiyat = Convert.ToSingle(txtSatis.Text);

            Yiyecek yeniYemek = new Yiyecek
            {
                Adi = yemekAdi,
                Cins = yemekCesidi,
                Fiyat = fiyat
            };

            YemekDosyalari.YemekEkle(yeniYemek, malzemeler);

            MessageBox.Show("Yemek başarıyla eklendi!");

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            // Seçilen satırın yemek adını alın
            string secilenYemekAdi = listView1.SelectedItems[0].SubItems[0].Text;

            // Yemek adını kullanarak dosyadan yemeği silin
            YemekDosyalari.YemekSil(secilenYemekAdi);

            // ListView'den seçilen satırı silin
            listView1.Items.Remove(listView1.SelectedItems[0]);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = listView1.SelectedItems[0];
            string eskiYemekAdi = selectedItem.SubItems[0].Text;
            string yeniYemekAdi = txtYemekAdi.Text;
            string yeniCins = comboBox1.SelectedItem.ToString();
            float yeniFiyat = Convert.ToSingle(txtSatis.Text);
            string yeniMalzemeler = txtMalzemeler.Text;

            Yiyecek yeniYemek = new Yiyecek
            {
                Adi = yeniYemekAdi,
                Cins = yeniCins,
                Fiyat = yeniFiyat,
            };

            YemekDosyalari.YemekGuncelle(eskiYemekAdi, yeniYemek, yeniMalzemeler);
        }

        private void btnRaporAl_Click(object sender, EventArgs e)
        {
            RaporAl();
        }
      

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yemekCesiti = comboBox1.SelectedItem.ToString();
         
        }

        private void RaporAl()
        {
            // ListView'u temizle
            listView1.Items.Clear();

            // Dosyadan yemekleri oku
            string[] yemekler = YemekDosyalari.GetYemekler();

            // Yemekleri ListView içine ekle
            foreach (string yemek in yemekler)
            {
                ListViewItem item = new ListViewItem(yemek.Split(','));
                listView1.Items.Add(item);
            }
        }

        private void YemekForm_Load(object sender, EventArgs e)

        {
            listView1.Columns.Add("Ad", 250);
            listView1.Columns.Add("Çeşit", 150);
            listView1.Columns.Add("Fiyat", 150);

            listView1.View = View.Details;





            string[] yiyecekler = { "Salata", "Tatlı", "Ana Yemek", "İçecek", "Mevye" };

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            comboBox1.Items.AddRange(yiyecekler);


        }

        
        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
           
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                
                e.Handled = true;
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = listView1.SelectedItems[0];

            if (selectedItem != null)
            {
                txtYemekAdi.Text = selectedItem.SubItems[0].Text; // Yemek Adı
                comboBox1.SelectedItem = selectedItem.SubItems[1].Text; // Yemek Çeşidi
                txtSatis.Text = selectedItem.SubItems[2].Text; // Yemek Fiyatı

                string yemekAdi = selectedItem.SubItems[0].Text;
                string[] malzemeler = YemekDosyalari.MalzemeleriGetir(yemekAdi);
                txtMalzemeler.Text = string.Join(", ", malzemeler); // Malzemeleri virgülle ayırarak birleştir
            }
        }
    }
}
