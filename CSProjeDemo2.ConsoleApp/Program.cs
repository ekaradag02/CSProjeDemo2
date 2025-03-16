using System;
using System.Collections.Generic;
using System.IO;
using CSProjeDemo2.Models;
using CSProjeDemo2.Services;

class Program
{
    static void Main()
    {
        string dosyaYolu = "personel.json";
        List<Personel> personeller;

        if (File.Exists(dosyaYolu))
        {
            personeller = DosyaOku.JsonDosyasindanOku(dosyaYolu);
            Console.WriteLine("Personel bilgileri JSON dosyasından yüklendi.");

           
            foreach (var personel in personeller)
            {
                Console.Write($"{personel.Ad} için çalışma saatini giriniz: ");
                if (int.TryParse(Console.ReadLine(), out int calismaSaati))
                {
                    personel.CalismaSaati = calismaSaati;
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş! Varsayılan olarak 160 saat atanıyor.");
                    personel.CalismaSaati = 160;
                }
            }
        }
        else
        {
            Console.WriteLine("JSON dosyası bulunamadı, varsayılan personel listesi oluşturuluyor...");

            personeller = new List<Personel>
            {
                new Yonetici("Elif Karadağ"),
                new Memur("Kıvanç Tatlıtuğ", 500)
            };

            personeller[0].CalismaSaati = 160;
            personeller[1].CalismaSaati = 200;
        }

        MaasBordro.MaasHesaplaVeKaydet(personeller);

        Console.WriteLine("\nMaaş bordroları başarıyla kaydedildi.");
    }
}
