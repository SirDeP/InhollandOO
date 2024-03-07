using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager
{
    public enum RekeningStaat { Geblokkeerd, Geldig }
    public class Rekening
    {
        int balans;
        public string NaamKlant { get; set; }
        public string RekeningNummer { get; set; }
        public RekeningStaat Staat { get; private set; } = RekeningStaat.Geldig;
        public int Balans
        {
            get { return balans; }
        }

        public int HaalGeldAf(int bedrag)
        {
            if (Staat == RekeningStaat.Geblokkeerd)
                Console.WriteLine("Deze rekening is geblokkeerd");
            if (balans >= bedrag)
            {
                balans -= bedrag;
                return bedrag;
            }
            else if (balans < bedrag)
            {
                int temp = Balans;
                balans = 0;
                Console.WriteLine("Rekening leeg nu");
                Staat = RekeningStaat.Geblokkeerd;
                return temp;
            }
            return 0;
        }

        public void StortGeld(int bedrag)
        {
            if (Staat == RekeningStaat.Geblokkeerd)
                Console.WriteLine("Deze rekening is geblokkeerd");
            else
            balans += bedrag;
        }

        public void VeranderStaat()
        {
            if (Staat == RekeningStaat.Geldig)
                Staat = RekeningStaat.Geblokkeerd;
            else
                Staat = RekeningStaat.Geldig;
        }

        public void ToonInfo()
        {
            Console.WriteLine($"Naam klant: {NaamKlant}");
            Console.WriteLine($"Rekeningnummer: {RekeningNummer}");
            Console.WriteLine($"Balans: {balans}");
            Console.WriteLine($"Staat: {Staat}");
        }
        public Rekening CreeerTienerRekening(string naamklant)
        {
            Rekening tienerrekening = new Rekening();
            Random rnd = new Random();
            for (int i = 0; i < 11; i++)
                tienerrekening.RekeningNummer += rnd.Next(1, 9).ToString();
            tienerrekening.NaamKlant = naamklant;
            tienerrekening.StortGeld(50);
            return tienerrekening;
        }
    }
}

