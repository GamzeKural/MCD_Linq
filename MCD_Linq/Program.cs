using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCD_Linq
{
    class Program
    {
        static bool funcDelegateKullanimi(Musteri m)
        {
            if (m.isim[0] == 'A')
                return true;
            else
                return false;

        }

        static bool predicateDelegateMetot(Musteri m)
        {
            if (m.dogumTarih.Year > 1990)
                return true;
            else
                return false;
        }

        static void musteriListele(Musteri m)
        {
            Console.WriteLine(m.isim+" "+m.soyisim);
        }

        static void Main(string[] args)
        {
            dataSource ds = new dataSource();
            List<Musteri> musteriListe = ds.musteriListesi();
            //Console.WriteLine("Müşteriler "+musteriListe.Count);

            //Liste içinde bulunan isim değeri a ile başlayan kayıt sayısı
            //int bulunanToplam = 0;
            //for (int i = 0; i < musteriListe.Count; i++)
            //{
            //    if (musteriListe[i].isim[0]=='A')
            //    {
            //        bulunanToplam++;
            //        Console.WriteLine("İsim "+musteriListe[i].isim);
            //    }
            //}
            //Console.WriteLine("Adı a ile başlayan müşteri sayısı: "+bulunanToplam);

            ////Linq ile yapılışı
            //bulunanToplam = 0;
            //bulunanToplam = musteriListe.Where(i => i.isim.StartsWith("A")).Count();
            //Console.WriteLine("Adı a ile başlayan müşteri sayısı: " + bulunanToplam);

            //Console.ReadLine();

            ////1.yol Linq method ile sorgulama

            //int toplamMusteriAdetI = musteriListe.Where(I => I.isim.StartsWith("A")).Count();

            ////2.yol Linq to query ile sorgulama

            //var toplamMusteriBulunan = from I in musteriListe
            //                           where I.isim.StartsWith("A")
            //                           select I;
            //int toplamMusteriAdetIII = toplamMusteriBulunan.Count();
            //Console.WriteLine(toplamMusteriAdetI);
            //Console.WriteLine(toplamMusteriAdetIII);
            //Console.ReadKey();

            //1-Müşteriler içerisinde ülke değeri A ile başlayan müşterileri Linq to metot kullanarak bulalım.

            //IEnumerable<Musteri> musteriAlistirma1 = musteriListe.Where(I => I.ulke.StartsWith("A"));
            //Console.WriteLine(musteriAlistirma1.Count());


            //2-Müşteriler listesi içerisindeki kayıtlardan isminin içerisinde b harfi geçen ve ülke değeri içinde A harfi geçen müşterilerin listesini getiriniz.
            //var musteriAlistirma3 = musteriListe.Where(i => i.isim.Contains("b") && i.ulke.Contains("a"));

            //3 - müşteriler listesi içerisindeki kayıtlardan doğum yılı 1990 dan büyük olan ve isminin içinde a harfi olan müşterileri linq to query
            //  var musteriAlistirma4 = from I in musteriListe
            //                          where I.dogumTarih.Year > 1990 && I.isim.Contains("a")
            //                          select I;
            //var toplamMusteri = musteriAlistirma4.Count();
            //Console.WriteLine(toplamMusteri);
            //foreach (var item in musteriAlistirma4)
            //{
            //    Console.WriteLine(item.dogumTarih.ToShortDateString());
            //}


            //4 MUSTERİLER LİSTESİ İÇERİSİNDEKİ KAYITLARDAN DOĞUM YILI 1990 DAN BÜYÜK OLAN VEYa isminin içerisinde a harfi geçen müşterileri linq to query ile
            //var musteriAlistirma4 = from I in musteriListe
            //                        where I.dogumTarih.Year > 1990 || I.isim.Contains("a")
            //                        select I;
            //var toplamMusteri = musteriAlistirma4.Count();
            //Console.WriteLine(toplamMusteri);
            //foreach (var item in musteriAlistirma4)
            //{
            //    Console.WriteLine(item.dogumTarih.ToShortDateString());
            //}


            //var DelegateKullanim1 = musteriListe.Where(I => I.isim.StartsWith("A"));
            //Func<Musteri, bool> func = new Func<Musteri, bool>(funcDelegateKullanimi);
            //bool deger = false;
            //foreach (var item in musteriListe)
            //{
            //    deger = func(item);
            //    Console.WriteLine(deger);

            //}

            //Console.ReadKey();

            //Predicate<Musteri> predicate = new Predicate<Musteri>(predicateDelegateMetot);
            //var delegateKullanimPredicate1 = musteriListe.FindAll(predicate);

            //var delegateKullanimPredicate2 = musteriListe.FindAll(new Predicate<Musteri>(predicateDelegateMetot
            //    ));

            //var delegateKullanimPredicate3 = musteriListe.FindAll(delegate (Musteri m) { return m.dogumTarih.Year > 1990; });

            //var delegateKullanimPredicate4 = musteriListe.FindAll((Musteri m) => { return m.dogumTarih.Year > 1990; });

            //var delegateKullanimPredicate5 = musteriListe.FindAll(m => m.dogumTarih.Year > 1990);


            #region action delegate kullanımı
            //1.yöntem
            Action<Musteri> actionMusteri = new Action<Musteri>(musteriListele);
            musteriListe.ForEach(actionMusteri);
            //2.yöntem
            musteriListe.ForEach(new Action<Musteri>(musteriListele));
            //3.yöntem
            musteriListe.ForEach(delegate (Musteri m) {Console.WriteLine(m.isim + " " + m.soyisim); });
            //4.yöntem
            musteriListe.ForEach((Musteri m) => { Console.WriteLine(m.isim + " " + m.soyisim); });
            //5.yöntem
            musteriListe.ForEach(m => { Console.WriteLine(m.isim + " " + m.soyisim); });

            #endregion
        }


    }
}
