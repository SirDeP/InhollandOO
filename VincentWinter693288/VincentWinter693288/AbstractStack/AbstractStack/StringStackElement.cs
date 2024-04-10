using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractStack
{
    internal class StringStackElement:EenStackElement
    {
        string data;
        public string Data { get { return data; } }
        public StringStackElement(string tekst, EenStackElement next) : base(next)
        {
            data = tekst;
        }

        public override void PrintWaarde()
        {
            Console.WriteLine(Data);
        }
    }
}
