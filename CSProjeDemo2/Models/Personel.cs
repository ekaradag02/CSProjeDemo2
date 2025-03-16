using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Models
{
    public abstract class Personel
    {
        public string Ad { get; set; }
        public string Unvan { get; set; }
        public double SaatlikUcret { get; set; }
        public int CalismaSaati { get; set; }

        protected Personel(string ad, string unvan, double saatlikUcret)
        {
            Ad = ad;
            Unvan = unvan;
            SaatlikUcret = saatlikUcret;
            CalismaSaati = 0; 
        }

        public abstract double MaasHesapla();
    }
}
