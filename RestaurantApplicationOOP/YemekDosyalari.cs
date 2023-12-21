



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
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RestaurantApplicationOOP
{
   

    public static class YemekDosyalari
    {
        public const string YemekCesitDosyasi = @"C:\Users\yusuf\source\repos\RestaurantApplicationOOP\RestaurantApplicationOOP\txt_dosyalari\yemekcesit.txt";

        public const string MalzemeDosyasi = @"C:\Users\yusuf\source\repos\RestaurantApplicationOOP\RestaurantApplicationOOP\txt_dosyalari\malzeme.txt";



        public static void YemekEkle(Yiyecek yemek, string malzemeler)
        {
            string yemekSatiri = $"{yemek.Adi},{yemek.Cins},{yemek.Fiyat}";
            File.AppendAllText(YemekCesitDosyasi, yemekSatiri + Environment.NewLine);
            File.AppendAllText(MalzemeDosyasi, $"{yemek.Adi}:{malzemeler}" + Environment.NewLine);
        }

        public static void YemekSil(string yemekAdi)
        {
            var yemekler = File.ReadAllLines(YemekCesitDosyasi).Where(y => !y.StartsWith(yemekAdi + ",")).ToArray();
            File.WriteAllLines(YemekCesitDosyasi, yemekler);

            var malzemeler = File.ReadAllLines(MalzemeDosyasi).Where(m => !m.StartsWith(yemekAdi + ":")).ToArray();
            File.WriteAllLines(MalzemeDosyasi, malzemeler);
        }

        public static void YemekGuncelle(string eskiYemekAdi, Yiyecek yeniYemek, string malzemeler)
        {
            YemekSil(eskiYemekAdi);
            YemekEkle(yeniYemek, malzemeler);
        }



        public static Yiyecek[] YemekleriGetir()
        {
            var yemekler = File.ReadAllLines(YemekCesitDosyasi)
                .Select(line =>
                {
                    var parts = line.Split(',');
                    return new Yiyecek
                    {
                        Adi = parts[0],
                        Cins = parts[1],
                        Fiyat = Convert.ToSingle( parts[2])
                    };
                })
                .ToArray();
            return yemekler;
        }

        public static string[] MalzemeleriGetir(string yemekAdi)
        {
            var malzemeler = File.ReadAllLines(MalzemeDosyasi)
                .Where(line => line.StartsWith(yemekAdi + ":"))
                .Select(line => line.Substring(yemekAdi.Length + 1))
                .ToArray();
            return malzemeler;
        }

        public static string[] GetYemekler()
        {
            return File.ReadAllLines(YemekCesitDosyasi);
        }

        public static string[] GetMalzemeler()
        {
            return File.ReadAllLines(MalzemeDosyasi);
        }








    }

}
