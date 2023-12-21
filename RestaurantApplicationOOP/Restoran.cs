



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

namespace RestaurantApplicationOOP
{
    public class Restoran
    {
        private const string DepoDosyasi = @"C:\Users\yusuf\source\repos\RestaurantApplicationOOP\RestaurantApplicationOOP\txt_dosyalari\depo.txt";

        public static string[] GunlukUretim(Dictionary<string, int> yemekVeKisiSayisi)
        {
            string[] siparisListesi = new string[yemekVeKisiSayisi.Count];
            int index = 0;

            foreach (var item in yemekVeKisiSayisi)
            {
                string yemekAdi = item.Key;
                int kisiSayisi = item.Value;

                float malzemeMaliyeti = MalzemeCikar(yemekAdi, kisiSayisi);

                float genelTutar = malzemeMaliyeti * (1 + 0.18f);
                float kisiBasiMaliyet = genelTutar / kisiSayisi;

                string siparis = $"{yemekAdi}: {kisiSayisi} kişi - Genel Tutar: {genelTutar:C2} - Kişi Başı Maliyet: {kisiBasiMaliyet:C2}";
                siparisListesi[index++] = siparis;
            }

            return siparisListesi;
        }

        private static float MalzemeCikar(string yemekAdi, int kisiSayisi)
        {
            float malzemeMaliyeti = 0;

            
            string[] malzemeler = YemekDosyalari.GetMalzemeler();

            foreach (string malzemeBilgisi in malzemeler)
            {
                string[] parts = malzemeBilgisi.Split(',');
                string malzemeAdi = parts[0].Trim();
                float gerekenMiktar = float.Parse(parts[1].Replace("g", "").Trim()) * kisiSayisi;

                string[] depoMalzemeleri = File.ReadAllLines(DepoDosyasi);

                for (int i = 0; i < depoMalzemeleri.Length; i++)
                {
                    string[] depoMalzemeBilgileri = depoMalzemeleri[i].Split(',');

                    if (depoMalzemeBilgileri[0].Trim() == malzemeAdi)
                    {
                        float stokMiktar = float.Parse(depoMalzemeBilgileri[3].Replace("g", "").Trim());
                        float stokAdet = float.Parse(depoMalzemeBilgileri[4]);
                        float fiyat = float.Parse(depoMalzemeBilgileri[5].Replace("TL", "").Trim());

                        if (stokMiktar >= gerekenMiktar)
                        {
                            malzemeMaliyeti += fiyat * gerekenMiktar;
                            depoMalzemeBilgileri[3] = (stokMiktar - gerekenMiktar).ToString() + "g";
                            StringBuilder sb = new StringBuilder();
                            for (int j = 0; j < depoMalzemeBilgileri.Length; j++)
                            {
                                sb.Append(depoMalzemeBilgileri[j]);
                                if (j < depoMalzemeBilgileri.Length - 1) sb.Append(',');
                            }
                            depoMalzemeleri[i] = sb.ToString();

                        }
                        else
                        {                            
                            DepoForm depo = new DepoForm();
                            depo.Show();
                        }

                        break;
                    }
                }

                File.WriteAllLines(DepoDosyasi, depoMalzemeleri);
            }

            return malzemeMaliyeti;
        }
    }

}
