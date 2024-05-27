using StajTalepleri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace stajTalepleri
{
    public partial class Form1 : Form
    {
        private PriorityQueue priorityQueue; //PriorityQueue sınıfımızdan nesnemi olusturuyorum

        public Form1()
        {
            InitializeComponent();
            priorityQueue = new PriorityQueue(); //nesnemi olusturdum
        }
        private void ListeyiGuncelle()
        {
            listBox1.Items.Clear(); // ListBox'ı temizle

            foreach (Student ogrenci in priorityQueue.GetHeap()) //ogrenciler donguye eklenir
            {
                listBox1.Items.Add(ogrenci.ToString()); //ogrenci bilgileri listbox a eklenir
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ogrenciNumarasi = ogrenciNo.Text;
            string ad = adSoyad.Text;
            int diplomaNotu = int.Parse(ortalama.Text);
            int devamsizlikSayisi = int.Parse(devamsizlik.Text);
            bool toplulukGorevleri = topluluk.Checked;  
            // CheckBox kontrolü, bool olarak atanır

            Student yeniOgrenci = new Student(ogrenciNumarasi, ad, diplomaNotu, devamsizlikSayisi,  toplulukGorevleri);
            priorityQueue.Insert(yeniOgrenci);

            ListeyiGuncelle(); // Sadece yeni öğrenciyi ekleme
        }


        //çıkar butonuna tıklanınca calisan metot
        private void button2_Click(object sender, EventArgs e)
        {
            if (priorityQueue.IsEmpty())
            {
                MessageBox.Show("Kuyruk boş!");
                return;
            }

            //en oncelikli ogrenci
            Student enUsttekiOgrenci = (Student)priorityQueue.Remove();

            cikarilanOgrenciNo.Text = enUsttekiOgrenci.OgrenciNumarasi;
            cikarilanOgrenciAdSoyad.Text = enUsttekiOgrenci.Ad;
            cikarilanOgrenciOrtalama.Text = enUsttekiOgrenci.DiplomaNotu.ToString();
            cikarilanOgrenciDevamsizlik.Text = enUsttekiOgrenci.DevamsizlikSayisi.ToString();
            cikarilanOgrenciTopluluk.Checked = enUsttekiOgrenci.ToplulukGorevleri;
            ListeyiGuncelle();
        }

        private void temizle_Click(object sender, EventArgs e)
        {   //temizle butonuyla her seferinde onceki degerleri silmekle ugrasmiyorum
            ogrenciNo.Text = ""; 
            adSoyad.Text = ""; 
            ortalama.Text = "";
            devamsizlik.Text = ""; 
            topluluk.Checked = false;
        }
    }
}
