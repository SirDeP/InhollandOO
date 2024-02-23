using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapportModule
{
    public class Rapport
    {
        public int Percentage { get; set; }
        public void PrintGraad()
        {
            if (Percentage < 50)
                Console.WriteLine("Niet geslaagd");
            else if (Percentage >= 50 && Percentage <= 68)
                Console.WriteLine("Voldoende");
            else if (Percentage > 68 && Percentage <= 75)
                Console.WriteLine("Onderscheiding");
            else if (Percentage > 75 && Percentage <= 85)
                Console.WriteLine("Grote onderscheiding");
            else if (Percentage > 85)
                Console.WriteLine("Grootste onderscheiding");
        }
    }
}
