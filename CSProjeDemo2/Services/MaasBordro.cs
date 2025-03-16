using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using CSProjeDemo2.Models;

namespace CSProjeDemo2.Services
{
    public static class MaasBordro
    {
        public static void MaasHesaplaVeKaydet(List<Personel> personeller)
        {
            List<Personel> azCalisanlar = new List<Personel>();

            foreach (var personel in personeller)
            {
                if (personel.CalismaSaati == 0)
                {
                    Console.WriteLine($"UYARI: {personel.Ad} için çalışma saati atanmadı! JSON dosyanı kontrol et.");
                    continue; 
                }

                double maas = personel.MaasHesapla();
                var bordro = new
                {
                    PersonelIsmi = personel.Ad,
                    CalismaSaati = personel.CalismaSaati,
                    AnaOdeme = maas,
                    ToplamOdeme = maas
                };

                string klasor = $"Bordrolar/{personel.Ad}";
                Directory.CreateDirectory(klasor);
                string dosyaYolu = $"{klasor}/Bordro_{DateTime.Now:yyyy_MM}.json";
                File.WriteAllText(dosyaYolu, JsonConvert.SerializeObject(bordro, Formatting.Indented));

                Console.WriteLine($"{personel.Ad} maaşı kaydedildi: {maas} TL");

                if (personel.CalismaSaati < 150)
                {
                    azCalisanlar.Add(personel);
                }
            }

            Console.WriteLine("\n150 Saatten Az Çalışan Personeller:");
            if (azCalisanlar.Count > 0)
            {
                foreach (var p in azCalisanlar)
                {
                    Console.WriteLine($"{p.Ad} - {p.CalismaSaati} saat çalıştı.");
                }
            }
            else
            {
                Console.WriteLine("Tüm personeller en az 150 saat çalıştı.");
            }
        }
    }
}
