using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Book ktb=null;
            var liste = new List<Book>();
            void Giris()
            {
                Console.WriteLine("\n1. Kitab elave et.");
                Console.WriteLine("2. Kitablari goster.");
                Console.WriteLine("3. Kitab sil.");
                Console.WriteLine("4. Kitab melumatlarini deyisdir.");
                Console.WriteLine("5. Kitablari tarix siralamasina gore goster.");
                Console.WriteLine("6. Kitablari qiymet siralamasina gore goster.");
                Console.WriteLine("\n--------------------------------------------");
                Console.Write("Istediyiniz emrin nomresini daxil edin: ");
                var reqem = Console.ReadLine();
                switch (reqem)
                {
                    case "1":
                        Elave_et();
                        break;
                    case "2":
                        Goster();
                        break;
                    case "3":
                        Sil();
                        break;
                    case "4":
                        Deyisdir();
                        break;
                    case "5":
                        Tarix();
                        break;
                    case "6":
                        Qiymet();
                        break;
                    default:
                        Console.WriteLine("----------------------------------------------------");
                        Console.WriteLine("Girdiyiniz deyer yanlisdir / Girise yonlendirildi...");
                        Giris();
                        break;
                }
            }
            Giris();
            void Elave_et()
            {
                Console.Write("Kitabin adini daxil edin: ");
                var ad = Console.ReadLine();
                string ilk_herf = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ad);
                Console.Write("Kitabin yazarini daxil edin: ");
                var yazar = Console.ReadLine();
                string ilk_herf_yazar = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(yazar);
                Console.Write("Kitabin ISBN-sini daxil edin: ");
                var isbn = Console.ReadLine();
                Console.Write("Kitabin nesr olunma tarixini daxil edin: ");
                DateTime date;
                date = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Kitabin qiymetini daxil edin: ");
                var qiymet = Convert.ToInt32(Console.ReadLine());              
                ktb = new Book(ilk_herf, ilk_herf_yazar, isbn, date, qiymet);
                liste.Add(ktb);
                Giris();
            }
            void Goster()
            {
                ktb.Show(liste);
                Giris();
            }
            void Sil()
            {
                ktb.Show(liste);
                Console.Write("Silmek istediyiniz kitabin sira nomresini daxil edin: ");
                var sil = Convert.ToInt32(Console.ReadLine());
                liste.Remove(liste[sil-1]);
                Giris();
            }
            void Deyisdir()
            {
                ktb.Show(liste);
                Console.Write("Deyismek istediyiniz kitabin sira nomresini daxil edin: ");
                var deyis = Convert.ToInt32(Console.ReadLine());            
                Console.Write("Kitabin adini daxil edin: ");
                var ad = Console.ReadLine();
                string ilk_herf = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ad);
                Console.Write("Kitabin yazarini daxil edin: ");
                var yazar = Console.ReadLine();
                string ilk_herf_yazar = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(yazar);
                Console.Write("Kitabin ISBN-sini daxil edin: ");
                var isbn = Console.ReadLine();
                Console.Write("Kitabin nesr olunma tarixini daxil edin: ");
                DateTime date;
                date = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Kitabin qiymetini daxil edin: ");
                var qiymet = Convert.ToInt32(Console.ReadLine());
                ktb = new Book(ilk_herf, ilk_herf_yazar, isbn, date, qiymet);
                liste[deyis - 1] = ktb;
                Giris();         
            }
             void Tarix()
            {
                List<Book> newBooks = new List<Book>();
                newBooks = liste.OrderBy(c => c.PublishDate).ToList();
                newBooks.Reverse();              
                var say = 0;
                foreach (var goster in newBooks)
                {
                    say++;
                    Console.WriteLine("\n"+say + "-" + goster.Name + " / " + goster.PublishDate.Year);
                }
                Giris();
            }
            void Qiymet()
            {
                List<Book> yenikitab = new List<Book>();
                yenikitab = liste.OrderBy(b => b.Price).ToList();
                var say = 0;
                foreach (var goster in yenikitab)
                {
                    say++;
                    Console.WriteLine("\n"+say + "-" + goster.Name + " / " + goster.Price);
                }
                Giris();
            }
            Console.Read();
        }
    }
    class Book
    {
        public string Name;
        public string Author;
        public string ISBN;
        public DateTime PublishDate;
        public int Price;
        public Book(string nm,string ath,string brkd,DateTime Date,int qymt)
        {
            Name = nm;
            Author = ath;
            ISBN = brkd;
            PublishDate = Date;
            Price = qymt;
        }
        public void Show(List<Book> kitablar)
        {
            var say = 0;
            foreach (var goster in kitablar)
            {
                say++;
                Console.WriteLine(say + "-" + "Kitabin adi: " + goster.Name + " / " + "Yazari: " + goster.Author + " / " + "ISBN-si: " + goster.ISBN + " / " + "Nesr olunma tarixi: " + goster.PublishDate.Year + " / " + "Qiymeti: " + goster.Price);
            }
        }
    }
}