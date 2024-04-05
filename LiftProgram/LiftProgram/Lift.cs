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
        public bool[] VerzoekenLijstOmlaag;
    
        public Lift(int LiftID)
        {
            liftID = LiftID;
            VerzoekenLijstOmhoog = new bool[AantalVerdiepingen];
            VerzoekenLijstOmlaag = new bool[AantalVerdiepingen];
            for (int i = 0; i < AantalVerdiepingen; i++)
            {
                VerzoekenLijstOmhoog[i] = false;
                VerzoekenLijstOmlaag[i] = false;
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
                VerzoekenLijstOmlaag[Verdieping] = true;
            }
        }

        public void GaNaarVerdieping(int Verdieping)
        {
            HuidigeVerdieping = Verdieping;
            Console.WriteLine(liftID + ": Aankomst op verdieping" + HuidigeVerdieping);
        }

        public int AantalVerzoeken()
        {
            int Aantal = 0;
            for (int i = 0; i < AantalVerdiepingen; i++)
            {
                if (VerzoekenLijstOmhoog[i])
                {
                    Aantal++;
                }
                if (VerzoekenLijstOmlaag[i])
                {
                    Aantal++;
                }
            }
            return Aantal;
        }

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
                Richting = "Omlaag";
            }
            else
            {
                for(int i = AantalVerdiepingen - 1; i >= 0; i--)
                {
                    if (VerzoekenLijstOmlaag[i])
                    {
                        VerzoekenLijstOmlaag[i] = false;
                        GaNaarVerdieping(i);
                        LaadPassagiers();
                    }
                }
                Richting = "Omhoog";
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
            DeurStatus = "Dicht";
            Console.WriteLine(liftID + ": Deur is dicht");
        }

        public void MaakVerzoekenLijstenLeeg()
        {
            for (int i = AantalVerdiepingen; i >= 0; i--)
            {
                VerzoekenLijstOmlaag[i] = false;
                VerzoekenLijstOmhoog[i] = false;
            }
        }
        public void NoodStop()
        {
            SluitDeur();
            GaNaarVerdieping(0);
            OpenDeur();
            MaakVerzoekenLijstenLeeg();
        }
    }

}
