using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurenConsole
{
    public class Rechthoek
    {
        int lengte;
        int breedte;
        public int Lengte
        {
            get => lengte;
            set
            {
                if (value >= 1)
                    lengte = value;
            }
        }

        public int Breedte
        {
            get => breedte;
            set
            {
                if (value >= 1)
                    breedte = value;
            }
        }

        public void ToonOppervlakte()
        {
            double oppervlakte = lengte * breedte;
            Console.WriteLine($"{oppervlakte}");
        }
    }
}
