using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProjeDemo2.Models
{
    public class Memur : Personel
    {
        public Memur(string ad, double saatlikUcret)
            : base(ad, "Memur", saatlikUcret) { }

        public override double MaasHesapla()
        {
            if (CalismaSaati <= 180)
            {
                return CalismaSaati * SaatlikUcret;
            }
            else
            {
                int normalSaat = 180;
                int mesaiSaat = CalismaSaati - 180;
                double mesaiUcreti = mesaiSaat * (SaatlikUcret * 1.5);
                return (normalSaat * SaatlikUcret) + mesaiUcreti;
            }
        }
    }
}
