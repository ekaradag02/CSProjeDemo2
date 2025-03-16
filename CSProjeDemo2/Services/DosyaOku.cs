using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using CSProjeDemo2.Models;

namespace CSProjeDemo2.Services
{
    public static class DosyaOku
    {
        public static List<Personel> JsonDosyasindanOku(string dosyaYolu)
        {
            var json = File.ReadAllText(dosyaYolu);
            var personelListesi = JsonConvert.DeserializeObject<List<dynamic>>(json);

            List<Personel> personeller = new List<Personel>();

            foreach (var item in personelListesi)
            {
                int calismaSaati = item["CalismaSaati"] != null ? (int)item["CalismaSaati"] : 0;

                if (item["Unvan"] == "Yonetici")
                {
                    var yonetici = new Yonetici(item["Ad"]);
                    yonetici.CalismaSaati = calismaSaati;
                    personeller.Add(yonetici);
                }
                else if (item["Unvan"] == "Memur")
                {
                    var memur = new Memur(item["Ad"], 500);
                    memur.CalismaSaati = calismaSaati;
                    personeller.Add(memur);
                }
            }

            return personeller;
        }
    }
}
