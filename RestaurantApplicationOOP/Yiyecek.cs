

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

    public class Yiyecek
    {
        public string Adi { get; set; }
        public string Cins { get; set; }
        public float Fiyat { get; set; }
      


    }


    public class Salata : Yiyecek
    {
        
    }

    public class Tatli : Yiyecek
    {
       
    }

    public class Icecek : Yiyecek
    {
        
    }

    public class Yemek : Yiyecek
    {
        
    }

    public class Meyve : Yiyecek
    {
        
    }


}

