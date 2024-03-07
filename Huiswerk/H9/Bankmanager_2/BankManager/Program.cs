using System;

namespace BankManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Rekening toby = new Rekening();
            Rekening sjaak = new Rekening();
            sjaak = sjaak.CreeerTienerRekening("Sjaak Bakker");
            toby = toby.CreeerTienerRekening("Toby Fox");
            toby.ToonInfo();
            sjaak.ToonInfo();
            SimuleerOverdracht(sjaak, toby);
            toby.ToonInfo();
            sjaak.ToonInfo();

        }

        static void SimuleerOverdracht(Rekening rekening1, Rekening rekening2)
        {
            Random rnd = new Random();
            rekening2.StortGeld(rekening1.HaalGeldAf(rnd.Next(1, 11)));
            rekening1.StortGeld(rekening2.HaalGeldAf(rnd.Next(1, 11)));
            rekening2.StortGeld(rekening1.HaalGeldAf(rnd.Next(1, 11)));
            rekening1.StortGeld(rekening2.HaalGeldAf(rnd.Next(1, 11)));
            rekening2.StortGeld(rekening1.HaalGeldAf(rnd.Next(1, 11)));
        }


    }
}
