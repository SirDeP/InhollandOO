using System;

namespace RapportModule
{
    class Program
    {
        static void Main(string[] args)
        {
            //Gebruik de bestaande Rapport.cs file om daarin je Rapport volgens de opgave te maken:
            // (https://apwt.gitbook.io/ziescherp-oefeningen/zie-scherper-oefeningen-semester-2/h1-object-oriented-programming/a_practica#rapportmodule)

            //Test je code zoals altijd via de main
            //Tevreden over het resultaat? Laat mij nu eens testen: klik bovenaan op "Test" en dan "Run all tests".
           
            //Rapport mijnpunten = new Rapport();
            //mijnpunten.Percentage = int.Parse(Console.ReadLine());
            //mijnpunten.PrintGraad();

            NummerBerekenaar paar1 = new NummerBerekenaar();
            //paar1.Getal1 = 12;
            //paar1.Getal2 = 34;

            Console.WriteLine($"Input Getal1");
            paar1.Getal1 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Input Getal2");
            paar1.Getal2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"Paar: {paar1.Getal1}, {paar1.Getal2}");

            int berekendeSom = paar1.Som();
            Console.WriteLine($"Som = {berekendeSom}");

            Console.WriteLine($"Verschil = {paar1.Verschil()}");
            Console.WriteLine($"Verschil = {paar1.Product()}");
            Console.WriteLine($"Verschil = {paar1.Quotient()}");
        }
    }
}
