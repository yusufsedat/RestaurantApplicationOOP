


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
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantApplicationOOP
{
   

        public class Siparis
        {
        public class Yemek
        {
            public string YemekAdi { get; set; }
            public int Adet { get; set; }
          
        }

        private List<Yemek> yemekler;

        public Siparis()
        {
            yemekler = new List<Yemek>();
        }

        public void YemekEkle(string yemekAdi, int adet )
        {
            Yemek yemek = new Yemek
            {
                YemekAdi = yemekAdi,
                Adet = adet
                
            };

            yemekler.Add(yemek);
        }

        public void YemekSil(string yemekAdi)
        {
            yemekler.RemoveAll(y => y.YemekAdi == yemekAdi);
        }

        public List<Yemek> SiparisleriGetir()
        {
            return yemekler;
        }
    }



}



