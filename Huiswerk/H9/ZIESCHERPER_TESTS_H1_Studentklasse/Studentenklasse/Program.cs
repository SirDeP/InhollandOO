using System;

namespace Studentenklasse
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kies eerst voor Build-> Rebuild solution, en wacht tot alle nodige packages werden gedownload.

            //Gebruik de bestaande Student.cs file om daarin je Studentklasse volgens de opgave te maken:
            //https://apwt.gitbook.io/ziescherp-oefeningen/zie-scherper-oefeningen-semester-2/h1-object-oriented-programming/a_practica#studentklasse

            //Test je code zoals altijd via de main
            //Tevreden over het resultaat? Laat mij nu eens testen: klik bovenaan op "Test" en dan "Run all tests".

            Console.WriteLine("Hello World!");

            Student student1 = new Student();
            student1.Klas = Klassen.TI1;
            student1.Leeftijd = 21;
            student1.Naam = "Joske Vermeulen";
            student1.PuntenCommunicatie = 12;
            student1.PuntenProgrammingPrinciples = 15;
            student1.PuntenWebTech = 13;

            student1.GeefOverzicht();

        }
    }
}
