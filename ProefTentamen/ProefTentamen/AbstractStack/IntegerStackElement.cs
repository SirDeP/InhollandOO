using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractStack
{
    internal class IntegerStackElement : EenStackElement
    {
        int data;
        public int Data { get { return data; } }
        public IntegerStackElement(int Getal, EenStackElement next) : base(next)
        {
            data = Getal;
        }

        public override void PrintWaarde()
        {
            Console.WriteLine(Data);
        }
    }
}
