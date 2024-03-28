using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProefTentamen;

namespace AbstractStack
{
    internal class AutoStackElement : EenStackElement
    {
        Auto data = new Auto();
        public Auto Data { get { return data; } }
        public AutoStackElement(Auto Getal, EenStackElement next) : base(next)
        {
            data = Getal;
        }

        public override void PrintWaarde()
        {
            Console.WriteLine(Data.Kenteken);
            Console.WriteLine(Data.Kilometerstand);
            Console.WriteLine();

        }

        public override decimal Printdagwaarde()
        {
            return Data.Dagwaarde;
        }
    }
}

