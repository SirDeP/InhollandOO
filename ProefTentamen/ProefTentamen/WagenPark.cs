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
        Stack Autos = new Stack();
        public void printAutos()
        {
            Autos.Print();
        }

        public void AddAuto(Auto test)
        {
            Autos.Push(test);
        }

        public void TotaalBedrag()
        {
            Console.WriteLine((Autos.Totaalbedrag()).ToString("#.##"));
        }
    }
}
