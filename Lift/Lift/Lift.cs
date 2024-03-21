using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    internal class Lift
    {
        public int LiftID { get; private set; }
        public int HuidigeVerdieping { get; private set; }
        public Richting Richting { get; private set; }
        public List<int> BestemmingsVerdiepingen { get; private set; }

        public Lift(int liftID)
        {
            LiftID = liftID;
            HuidigeVerdieping = 0; // Start op begane grond
            Richting = Richting.Stilstaand;
            BestemmingsVerdiepingen = new List<int>();
        }

        public void GaNaarVerdieping(int verdieping)
        {
            if (verdieping == HuidigeVerdieping)
            {
                OpenDeur();
                return;
            }

            if (verdieping > HuidigeVerdieping)
                Richting = Richting.Omhoog;
            else
                Richting = Richting.Omlaag;

            BestemmingsVerdiepingen.Add(verdieping);
            PrioriteitGevenAanVerdiepingen();
        }

        public void VoegTussenstopToe(int verdieping)
        {
            BestemmingsVerdiepingen.Add(verdieping);
            PrioriteitGevenAanVerdiepingen();
        }

        public void VerwijderTussenstop(int verdieping)
        {
            BestemmingsVerdiepingen.Remove(verdieping);
        }

        public void OpenDeur()
        {
            Console.WriteLine($"Lift {LiftID}: Deur geopend op verdieping {HuidigeVerdieping}.");
            // Implementatie om de deur te openen
        }

        public void SluitDeur()
        {
            Console.WriteLine($"Lift {LiftID}: Deur gesloten.");
            // Implementatie om de deur te sluiten
        }

        private void PrioriteitGevenAanVerdiepingen()
        {
            BestemmingsVerdiepingen.Sort();

            if (Richting == Richting.Omhoog)
                BestemmingsVerdiepingen.Reverse();
        }

        public void Beweeg()
        {
            while (BestemmingsVerdiepingen.Count > 0)
            {
                int volgendeVerdieping = BestemmingsVerdiepingen[0];
                if (volgendeVerdieping > HuidigeVerdieping)
                    Richting = Richting.Omhoog;
                else if (volgendeVerdieping < HuidigeVerdieping)
                    Richting = Richting.Omlaag;
                else
                {
                    OpenDeur();
                    BestemmingsVerdiepingen.RemoveAt(0);
                    continue;
                }

                Console.WriteLine($"Lift {LiftID}: Beweegt {Richting} naar verdieping {volgendeVerdieping}.");
                HuidigeVerdieping = volgendeVerdieping;
                BestemmingsVerdiepingen.RemoveAt(0);
            }
            Richting = Richting.Stilstaand;
        }
    }
}
