using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftProgram
{
    internal class LiftenBesturing
    {
        public const int AantalVerdiepingen = 4;
        private Lift Lift1, Lift2;
        private Lift HuidigeLift

        public LiftenBesturing()
        {
            Lift1 = new Lift(1);
            Lift2 = new Lift(2);
            HuidigeLift = Lift1;
        }

        public void Noodstop()
        {
            Lift1.NoodStop();

        }

        public void RegistreerVerzoek(int Verdieping, string Richting)
        {
            if (HuidigeLift == Lift1)
            {

            }
        }
    }
}
