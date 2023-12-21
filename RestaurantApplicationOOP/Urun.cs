
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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace RestaurantApplicationOOP
{
    public class Urun
    {
        public string UrunAdi { get; set; }
        public DateTime UretimTarihi { get; set; }
        public DateTime SonKullanmaTarihi { get; set; }
        public float KaloriGram { get; set; }
        public float StokAdet { get; set; }
        public float Fiyat { get; set; }

        public override string ToString()
        {
            return $"{UrunAdi}, {UretimTarihi.ToShortDateString()}, {SonKullanmaTarihi.ToShortDateString()}, {KaloriGram}g, {StokAdet}, {Fiyat}TL";
        }
    }
    public class Depo
    {
        private const string DosyaYolu = @"C:\Users\yusuf\source\repos\RestaurantApplicationOOP\RestaurantApplicationOOP\txt_dosyalari\depo.txt";

        public void UrunEkle(Urun urun)
        {
            using (StreamWriter writer = new StreamWriter(DosyaYolu, true))
            {
                writer.WriteLine(urun.ToString());
            }
        }

        public void UrunSil(string urunAdi)
        {
            List<Urun> urunler = UrunleriOku();
            urunler.RemoveAll(u => u.UrunAdi == urunAdi);

            File.WriteAllText(DosyaYolu, string.Empty); // Dosyayı temizle
            urunler.ForEach(u => UrunEkle(u)); // Güncel listeyi yaz
        }

        public void UrunGuncelle(Urun urun)
        {
            UrunSil(urun.UrunAdi);
            UrunEkle(urun);
        }

        public List<Urun> UrunleriOku()
        {
            List<Urun> urunler = new List<Urun>();
            using (StreamReader reader = new StreamReader(DosyaYolu))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    Urun urun = new Urun
                    {
                        UrunAdi = parts[0],
                        UretimTarihi = DateTime.Parse(parts[1]),
                        SonKullanmaTarihi = DateTime.Parse(parts[2]),
                        KaloriGram = float.Parse(parts[3].TrimEnd('g'), CultureInfo.InvariantCulture),
                        StokAdet = float.Parse(parts[4], CultureInfo.InvariantCulture),
                        Fiyat = float.Parse(parts[5].TrimEnd(new char[] { 'T', 'L' }), CultureInfo.InvariantCulture)
                    };


                    urunler.Add(urun);
                }
            }

            return urunler;
        }

        
        
    }



}
