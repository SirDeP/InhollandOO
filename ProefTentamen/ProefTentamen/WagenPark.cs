using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractStack;

namespace ProefTentamen
{
    internal class WagenPark
    {
        public decimal TotaalbedragTemp { get; set; }
        Stack Autos = new Stack();
        public void PrintAutos()
        {
            Autos.Print();
        }

        public void AddAuto(Auto test)
        {
            Autos.Push(test);
        }

        public void TotaalBedrag()
        {
            Autos.PrintTotaalbedrag();
        }
    }
}
