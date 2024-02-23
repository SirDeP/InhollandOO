using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentenklasse
{
    public enum Klassen { TI1, TI2, TI3 }


    public class Student
    {
        public string Naam { get; set; }
        public int Leeftijd { get; set; }
        public Klassen Klas { get; set; }
        public int PuntenCommunicatie { get; set; }
        public int PuntenProgrammingPrinciples { get; set; }
        public int PuntenWebTech { get; set; }
        public double BerekenGemiddelde()
        {
            int totalPunten = PuntenCommunicatie + PuntenProgrammingPrinciples + PuntenWebTech;
            int numberOfSubjects = 3; // Assuming there are 3 subjects, you can adjust accordingly

            double gemiddelde = (double)totalPunten / numberOfSubjects;
            return gemiddelde;
        }
        
        public void GeefOverzicht()
        {
            double gemiddelde = BerekenGemiddelde();
            Console.WriteLine($"{Naam}, {Leeftijd}");
            Console.WriteLine($"Klas: {Klas}");
            Console.WriteLine("");
            Console.WriteLine("Cijferrapport:");
            Console.WriteLine("**********");
            Console.WriteLine($"Communicatie:                    {PuntenCommunicatie}");
            Console.WriteLine($"Programming Principles:          {PuntenProgrammingPrinciples}");
            Console.WriteLine($"Web Tech:                        {PuntenWebTech}");
            Console.WriteLine($"Gemiddelde:                      {gemiddelde}");
        }
    }
}
