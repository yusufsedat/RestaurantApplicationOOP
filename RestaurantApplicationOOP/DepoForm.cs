
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
using System.Globalization;
using System.IO;


namespace RestaurantApplicationOOP
{
    public partial class DepoForm : Form
    {

        Depo depo = new Depo();

        private const string dosyaYolu = @"C:\Users\yusuf\source\repos\RestaurantApplicationOOP\RestaurantApplicationOOP\txt_dosyalari\depo.txt";

        public DepoForm()
        {
            InitializeComponent();



        }



        private void DepoForm_Load(object sender, EventArgs e)
        {

            listView1.Columns.Add("Ürün Adı", 150);
            listView1.Columns.Add("Üretim Tarihi", 150);
            listView1.Columns.Add("Son Kullanma Tarihi", 150);
            listView1.Columns.Add("Kalori/Gram", 100);
            listView1.Columns.Add("Stok Adeti", 100);
            listView1.Columns.Add("Fiyat", 100);

            listView1.View = View.Details;

           
        }

        private void ekleButton_Click(object sender, EventArgs e)
        {

            string urunAdi = adTxt.Text;
            DateTime uretimTarihi = dateTimePicker1.Value;
            DateTime sonKullanmaTarihi = dateTimePicker2.Value;
            float kaloriGram = Convert.ToSingle(kalori.Text, CultureInfo.InvariantCulture); 
            float stokAdet = Convert.ToSingle(stokTxt.Text, CultureInfo.InvariantCulture);
            float fiyat = Convert.ToSingle(fiyatTxt.Text, CultureInfo.InvariantCulture); 

            Urun yeniUrun = new Urun
            {
                UrunAdi = urunAdi,
                UretimTarihi = uretimTarihi,
                SonKullanmaTarihi = sonKullanmaTarihi,
                KaloriGram = kaloriGram,
                StokAdet = stokAdet,
                Fiyat = fiyat
            };

            Depo depo = new Depo();
            depo.UrunEkle(yeniUrun);

          


            MessageBox.Show("Ürün başarıyla eklendi!"); 

        }

        private void rapButton_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            using (StreamReader reader = new StreamReader(dosyaYolu))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 6)
                    {
                        ListViewItem item = new ListViewItem(parts[0]);
                        item.SubItems.Add(parts[1]); // Üretim Tarihi
                        item.SubItems.Add(parts[2]); // Son Kullanma Tarihi
                        item.SubItems.Add(parts[3]); // Kalori/Gram
                        item.SubItems.Add(parts[4]); // Stok Adeti
                        item.SubItems.Add(parts[5]); // Fiyat

                        listView1.Items.Add(item);

                        listView1.View = View.Details;


                    }
                }
            }
        }

        private void silButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string urunAdi = listView1.SelectedItems[0].SubItems[0].Text;

                depo.UrunSil(urunAdi);

                listView1.SelectedItems[0].Remove();
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.");
            }

        }

        private void gunButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0]; 
                string urunAdi = selectedItem.SubItems[0].Text;

                string yeniUrunAdi = adTxt.Text;
                DateTime yeniUretimTarihi = dateTimePicker1.Value;
                DateTime yeniSonKullanmaTarihi = dateTimePicker2.Value;
                float yeniKaloriGram = Convert.ToSingle(kalori.Text, CultureInfo.InvariantCulture);
                float yeniStokAdet = Convert.ToSingle(stokTxt.Text, CultureInfo.InvariantCulture);
                float yeniFiyat = Convert.ToSingle(fiyatTxt.Text, CultureInfo.InvariantCulture);

                selectedItem.SubItems[0].Text = yeniUrunAdi;
                selectedItem.SubItems[1].Text = yeniUretimTarihi.ToString();
                selectedItem.SubItems[2].Text = yeniSonKullanmaTarihi.ToString();
                selectedItem.SubItems[3].Text = yeniKaloriGram.ToString(CultureInfo.InvariantCulture) + "g";
                selectedItem.SubItems[4].Text = yeniStokAdet.ToString(CultureInfo.InvariantCulture);
                selectedItem.SubItems[5].Text = yeniFiyat.ToString(CultureInfo.InvariantCulture) + "TL";

                Urun urun = new Urun
                {
                    UrunAdi = yeniUrunAdi,
                    UretimTarihi = yeniUretimTarihi,
                    SonKullanmaTarihi = yeniSonKullanmaTarihi,
                    KaloriGram = yeniKaloriGram,
                    StokAdet = yeniStokAdet,
                    Fiyat = yeniFiyat
                };

                depo.UrunGuncelle( urun); 
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = listView1.SelectedItems[0];

            if (selectedItem != null)
            {

                adTxt.Text = selectedItem.SubItems[0].Text; // Ürün Adı

               
                dateTimePicker1.Value = DateTime.Parse(selectedItem.SubItems[1].Text); // Üretim Tarihi
                dateTimePicker2.Value = DateTime.Parse(selectedItem.SubItems[2].Text); // Son Kullanma Tarihi

               
                kalori.Text = selectedItem.SubItems[3].Text; // Kalori Gram
                                                             
                stokTxt.Text = selectedItem.SubItems[4].Text; // Stok Adet
                fiyatTxt.Text = selectedItem.SubItems[5].Text; // Fiyat
            }

        }

       
    }



}







