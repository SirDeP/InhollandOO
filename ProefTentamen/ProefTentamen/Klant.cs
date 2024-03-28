using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProefTentamen
{
    internal class Klant
    {
        public string KlantNummer { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Woonplaats { get; set; }
        public string Postcode { get; set; }
        public string TelefoonNummer { get; set; }
        public string Rijbewijs { get; set; }

        public bool IsBetrouwbaar()
        {
            if (KlantNummer != null && Naam != null && Adres != null && Woonplaats != null && Postcode != null && TelefoonNummer != null && Rijbewijs != null)
            {
                Console.WriteLine("Klant is Betrouwbaar");
                return true; 
            }
            else
            {
                Console.WriteLine("Gegevens zijn niet volledig ingevuld");
                return false;
            }
        }
    }
}
