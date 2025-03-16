using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Models
{
    public class Yonetici : Personel
    {
        public double Bonus { get; set; }

        public Yonetici(string ad)
            : base(ad, "Yonetici", 500)
        {
            Bonus = 3000;
        }

        public override double MaasHesapla()
        {
            return (CalismaSaati * SaatlikUcret) + Bonus;
        }
    }
}
