using AbstractStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentWinter693288
{
    internal class ResultaatStack
    {
        Resultaat top = null;

        public ResultaatStack()
        {

        }

        public void Push(string Vak, int Cijfer)
        {
            Resultaat NieuweTop = new Resultaat(Vak, Cijfer, top);
            top = NieuweTop;
        }
        public int HoogsteCijfer()
        {
            if (top != null)
            {
                return top.HoogsteCijfer();
            }
            else
                return 0;
        }
        public void Print()
        {
            if (top != null)
            {
                top.Print();
            } else
            {
                Console.WriteLine("Geen Cijferlijst");
            }
            
        }
    }
}
