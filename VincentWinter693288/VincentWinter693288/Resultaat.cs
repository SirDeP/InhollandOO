using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentWinter693288
{
    internal class Resultaat
    {
        string vak;
        int cijfer;
        Resultaat volgendresultaat;


        public Resultaat(string vak, int cijfer, Resultaat resultaat)
        {
            this.vak = vak;
            this.cijfer = cijfer;
            this.volgendresultaat = resultaat;
        }

        public string getVak()
        {
            return vak;
        }
        public int getCijfer() 
        {
            return cijfer;
        }

        public int HoogsteCijfer()
        {
            return cijfer;
        }

        public void Print()
        {
            Console.WriteLine($"Vak: {vak}");
            Console.WriteLine($"Cijfer: {cijfer}");
            if (volgendresultaat != null)
            {
                volgendresultaat.Print();
            }
        }
    }
}
