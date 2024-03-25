using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftProgram
{
    internal class Lift
    {
        public const int AantalVerdiepingen = 4;
        private int liftID;
        public int HuidigeVerdieping;
        public string Richting;
        public string DeurStatus;
        public bool[] VerzoekenLijstOmhoog;
        public bool[] VerzeokenLijstOmlaag;
    
        public Lift(int LiftID)
        {
            liftID = LiftID;
            VerzoekenLijstOmhoog = new bool[AantalVerdiepingen];
            VerzeokenLijstOmlaag = new bool[AantalVerdiepingen];
            for (int i = 0; i < AantalVerdiepingen; i++)
            {
                VerzoekenLijstOmhoog[i] = false;
                VerzeokenLijstOmlaag[i] = false;
            }
            HuidigeVerdieping = 0;
            Richting = "Omhoog";
            DeurStatus = "Open";

        }

        public void RegistreerVerzoek(int Verdieping, string richting)
        {
            if (richting == "Omhoog")
            {
                VerzoekenLijstOmhoog[Verdieping] = true;
            }
            else
            {
                VerzeokenLijstOmlaag[Verdieping] = true;
            }
        }

        public void GaNaarVerdieping(int Verdieping)
        {
            HuidigeVerdieping = Verdieping;
            Console.WriteLine(liftID + ": Aankomst op verdieping" + HuidigeVerdieping);
        }

        // aantalverzoeken

        public void ActiveerLift()
        {
            if (Richting == "Omhoog")
            {
                for (int i = 0; i < AantalVerdiepingen; i++) 
                {
                    if (VerzoekenLijstOmhoog[i])
                    {
                        VerzoekenLijstOmhoog[i] = false;
                        GaNaarVerdieping(i);
                        LaadPassagiers();
                    }
                }
                Richting = "Omlaag"
            }
            else
            {

            }
        }

        public void LaadPassagiers()
        {
            OpenDeur();
            Console.Write(liftID + ": Naar welke verdieping (0 - " + (AantalVerdiepingen - 1) + ")? Enter voor geen:");
            string Commando = Console.ReadLine();
            if (Commando != "")
            {
                int Verdieping = int.Parse(Commando);
                if (Verdieping > HuidigeVerdieping)
                {
                    RegistreerVerzoek(Verdieping, "Omhoog");
                } else if (Verdieping < HuidigeVerdieping) 
                {
                    RegistreerVerzoek(Verdieping, "Omlaag");
                }
            }
            SluitDeur();
        }

        private void OpenDeur()
        {
            DeurStatus = "Open";
            Console.WriteLine(liftID + ": Deur is open");
        }

        private void SluitDeur()
        {
            DeurStatus = "Sluit";
            Console.WriteLine(liftID + ": Deur is dicht");
        }

        public void NoodStop()
        {

        }
    }

}
