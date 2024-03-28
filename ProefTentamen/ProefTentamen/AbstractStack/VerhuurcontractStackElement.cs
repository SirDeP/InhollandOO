using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProefTentamen;

namespace AbstractStack
{
    internal class VerhuurcontractStackElement : EenStackElement
    { 
            Verhuurcontract data = new Verhuurcontract();
            public Verhuurcontract Data { get { return data; } }
            public VerhuurcontractStackElement(Verhuurcontract Getal, EenStackElement next) : base(next)
            {
                data = Getal;
            }

            public override void PrintWaarde()
            {
                Console.WriteLine(Data);
            }
        }
    }

