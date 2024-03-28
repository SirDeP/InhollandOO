using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProefTentamen;

namespace AbstractStack
{
    internal class Stack
    {
        EenStackElement Top = null!;

        public void Push(int Getal)
        {
            EenStackElement NieuweTop = new IntegerStackElement(Getal, Top);
            Top = NieuweTop;
        }
        public void Push(Auto Getal)
        {
            EenStackElement NieuweTop = new AutoStackElement(Getal, Top);
            Top = NieuweTop;
        }
        public void Push(Verhuurcontract Getal)
        {
            EenStackElement NieuweTop = new VerhuurcontractStackElement(Getal, Top);
            Top = NieuweTop;
        }

        public void Push(string tekst)
        {
            EenStackElement NieuweTop = new StringStackElement(tekst, Top);
            Top = NieuweTop;
        }

        public EenStackElement? Pop()
        {
            if (Top != null)
            {
                EenStackElement OudeTop = Top;
                Top = Top.Next;
                return OudeTop;
            }
            else
                return null;
        }
        public void Print()
        {
            Top.PrintStack();
        }

        public void PrintTotaalbedrag()
        {
            decimal temp = 0;
            Console.WriteLine(Top.PrintDagwaarde(temp).ToString("#.##"));
        }
    }
}
