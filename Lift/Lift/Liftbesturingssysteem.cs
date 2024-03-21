using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    internal class Liftbesturingssysteem
    {
        public Lift Lift1 { get; private set; }
        public Lift Lift2 { get; private set; }
        public Queue<int> VerzoekenQueue { get; private set; }
        public bool NoodprocedureGeactiveerd { get; private set; }

        public Liftbesturingssysteem()
        {
            Lift1 = new Lift(1);
            Lift2 = new Lift(2);
            VerzoekenQueue = new Queue<int>();
            NoodprocedureGeactiveerd = false;
        }

        public void RegistreerVerzoek(int verdieping)
        {
            if (!NoodprocedureGeactiveerd)
                VerzoekenQueue.Enqueue(verdieping);
            else
                Console.WriteLine("Noodprocedure geactiveerd. Liftverzoeken worden niet verwerkt.");
        }

        public void PrioriteitGevenAanLift()
        {
            while (VerzoekenQueue.Count > 0)
            {
                int verdieping = VerzoekenQueue.Dequeue();
                if (Lift1.BestemmingsVerdiepingen.Count <= Lift2.BestemmingsVerdiepingen.Count)
                    Lift1.VoegTussenstopToe(verdieping);
                else
                    Lift2.VoegTussenstopToe(verdieping);
            }
        }

        public void ActiveerNoodprocedure()
        {
            Console.WriteLine("Noodprocedure geactiveerd. Alle liften gaan naar begane grond.");
            Lift1.VoegTussenstopToe(0);
            Lift2.VoegTussenstopToe(0);
            NoodprocedureGeactiveerd = true;
        }
    }
}
