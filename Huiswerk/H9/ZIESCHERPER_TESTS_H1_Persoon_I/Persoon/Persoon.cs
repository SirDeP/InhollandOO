using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persoon
{
    public class Persoon
    {
        public string Achternaam { get; set; }
        public string Voornaam { get; set; }

        private DateTime geboortedatum;
        DateTime minimum = new DateTime(1990, 1, 1);
        public DateTime GeboorteDatum
        {
            get { return geboortedatum; }
            set 
            { 
                if (value < minimum)
                    geboortedatum = DateTime.Now;
                else
                    geboortedatum = value;
            }
        }
        public int BerekenLeeftijd()
        {
            DateTime today = DateTime.Today;
            int leeftijd = today.Year - GeboorteDatum.Year;
            if (today.Month < GeboorteDatum.Month || (today.Month == GeboorteDatum.Month && today.Day < GeboorteDatum.Day))
                leeftijd--;
            return leeftijd;
        }

    }
}
