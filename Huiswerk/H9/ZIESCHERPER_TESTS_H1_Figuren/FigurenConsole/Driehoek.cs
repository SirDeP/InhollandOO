using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigurenConsole
{
    public class Driehoek
    {
        int basis;
        int hoogte;
        public int Basis
        {
            get => basis;
            set
            {
                if (value >= 1)
                    basis = value;
            }
        }
        
        public int Hoogte
        {
            get => hoogte;
            set
            {
                if (value >= 1)
                    hoogte = value;
            }
        }

        public void ToonOppervlakte()
        {
            double oppervlakte = basis * hoogte * 0.5;
            Console.WriteLine($"{oppervlakte}");
        }
    }
}
