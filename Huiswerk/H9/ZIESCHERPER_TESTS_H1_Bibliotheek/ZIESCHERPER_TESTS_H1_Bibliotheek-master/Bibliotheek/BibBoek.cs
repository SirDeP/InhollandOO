using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheek
{
    public class BibBoek
    {
        private const int AANTALUITLEENDAGEN = 14;
        public string Ontlener { get; set; } = "onbekend";

        private DateTime uitgeleend = DateTime.Now;

        public DateTime Uitgeleend
        {
            private get { return uitgeleend; }
            set { uitgeleend = value; }
        }

        //public DateTime Uitgeleend { private get; set; } = DateTime.Now;
        private DateTime inleverdatum;

        public DateTime InleverDatum
        {
            get 
            { 
                inleverdatum = Uitgeleend.AddDays(AANTALUITLEENDAGEN);
                return inleverdatum; 
            }
        }


        public void VerlengTermijn(int Dagen)
        {
            Uitgeleend = Uitgeleend.AddDays(Dagen);
        }
    }
}
