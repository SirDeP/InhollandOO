using System;

namespace Persoon
{
    class Program
    {
        static void Main(string[] args)
        {
            Persoon persoon1 = new Persoon();
            persoon1.Voornaam = "Andre";
            persoon1.Achternaam = "Boek";
            persoon1.GeboorteDatum = new DateTime(2003, 2, 28);
            Console.WriteLine($"{persoon1.BerekenLeeftijd()}");
        }
    }
}
