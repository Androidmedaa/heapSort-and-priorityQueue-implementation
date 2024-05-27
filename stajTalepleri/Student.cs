using System;

namespace stajTalepleri
{
    public class Student
    {
        public string OgrenciNumarasi { get; set; } //gerekli propertyleri tanımlıyorum
        public string Ad { get; set; }
        public double DiplomaNotu { get; set; }
        public bool ToplulukGorevleri { get; set; } // bool olarak değiştirildi
        public int DevamsizlikSayisi { get; set; }

        public Student(string ogrenciNumarasi, string ad, double diplomaNotu, int devamsizlikSayisi, bool toplulukGorevleri)
        { //yapıcı (constructor) methodu tanımladım
            OgrenciNumarasi = ogrenciNumarasi;
            Ad = ad;
            DiplomaNotu = diplomaNotu;
            DevamsizlikSayisi = devamsizlikSayisi;
            ToplulukGorevleri = toplulukGorevleri;
        }
        public override string ToString()
        {
            string toplulukDurumu = ToplulukGorevleri ? "Evet" : "Hayır";
            return $"{OgrenciNumarasi} - {Ad} - {DiplomaNotu} - {DevamsizlikSayisi} - {toplulukDurumu}";
        }
    }
}
