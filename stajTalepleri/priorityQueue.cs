using stajTalepleri;
using System;
using System.Collections.Generic;

namespace StajTalepleri
{
    public class PriorityQueue
    {
        private List<Student> heap;//ogencileri saklamak için heap listesi tanımlıyorum

        public PriorityQueue()
        {
            heap = new List<Student>(); // daha once tanımladıgım yapıcı methodu heap e atıyorum
        }

        public void Insert(Student student)
        {
            heap.Add(student); //ogrenciyi heap listeme ekledim
            HeapifyUp(heap.Count - 1); //eklene ogrenciyi uygun yere HeapifyUp ile koyuyorum
        }

        public Student Remove() //en oncelikli ogrenciyi silme methodum
        {
            if (IsEmpty())
                throw new InvalidOperationException("Kuyruk boş!");

            Student topStudent = heap[0]; //ilk eleman en oncelikli ogrenci olur
            heap[0] = heap[heap.Count - 1];//en son ogrenciyi heap mantıgıyla en uste getiriyorum
            heap.RemoveAt(heap.Count - 1);//en basta olup sona giden yeni son elemanı siliyorum
            HeapifyDown(0); //en uste tasınan ogrenciye Heapify işlemi uyguluyorum

            return topStudent; //heap ten cıkardıgımız elemanı ogrenciyi dondur
        }

        public bool IsEmpty()
        {
            return heap.Count == 0;
        }

        public List<Student> GetHeap()
        {
            return new List<Student>(heap);
            //heap listesinin kopyasını donduruyorum
        }


        //yukaruı dogru heapify uyguluyorum
        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2; //verilen index için ebeveyn indexini bulma formulu
            if (index > 0 && CompareStudent(heap[index], heap[parentIndex]) < 0)
            {//ve ebeveynin indexi minHeap için her zaman cocuktan buyuk olamlıdır bu yuzden karsılastırıyoruz
                Swap(index, parentIndex); //takas işlemi
                HeapifyUp(parentIndex); //recursive olarak devam ediyo
            }
        }


        private void HeapifyDown(int index)
        {
            int smallest = index; //en kucuk eleman index olur
            int leftChild = 2 * index + 1; //sol cocugun indexi
            int rightChild = 2 * index + 2; //sağ cocugun indexi

            //sol cocuk varsa ve en kucukse, en kucuk index sol cocuga atanır
            if (leftChild < heap.Count && CompareStudent(heap[leftChild], heap[smallest]) < 0)
                smallest = leftChild;

            //sağ coccuk varsa ve sag cocuk en kucukse, en kucuk index sag cocuga atanır
            if (rightChild < heap.Count && CompareStudent(heap[rightChild], heap[smallest]) < 0)
                smallest = rightChild;


            // En küçük eleman değişmişse ve index farklıysa swap işlemi yapılır ve aşağı doğru heapify işlemi devam eder

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        private int CompareStudent(Student x, Student y)//iki ogrenci karsılastırılıyor
        {
            if (x.DiplomaNotu != y.DiplomaNotu) //dn farklıysa dn ye gore karsılastırılır
                return y.DiplomaNotu.CompareTo(x.DiplomaNotu);

            if (x.ToplulukGorevleri != y.ToplulukGorevleri) //dn aynı olup toplulukta gorev alıp almamalarına gore karsılasrtırma
                return y.ToplulukGorevleri.CompareTo(x.ToplulukGorevleri); //aktif olan oncelikli

            return x.DevamsizlikSayisi.CompareTo(y.DevamsizlikSayisi);
            //en son devamsızlık durumlarına bakılır
        }
        private void Swap(int index1, int index2)//takas
        {
            Student temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }
}
