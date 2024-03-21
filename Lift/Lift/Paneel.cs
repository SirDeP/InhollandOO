using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    internal class Paneel
    {
            public void Verzoek(int verdieping, Liftbesturingssysteem liftbesturingssysteem)
            {
                liftbesturingssysteem.RegistreerVerzoek(verdieping);
            }
    }
}
