using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentWinter693288
{
    internal class Klas
    {
        StudentenStack klassenLijst = new();
        string klasNaam;

        public Klas(string KlasNaam)
        {
            this.klasNaam = KlasNaam;
        }

        public string GetKlasNaam()
        {
            return klasNaam;
        }

        public void NieuweStudent(string StudentNaam, string TelefoonNummer) 
        {
            klassenLijst.Push(StudentNaam, TelefoonNummer);
        }

        public Student ZoekStudent(string StudentNaam, string TelefoonNummer)
        {
            //Student tempStudent;
            //return tempStudent;
            return klassenLijst.ZoekStudent(StudentNaam, TelefoonNummer);
        }

        public int HoogsteCijfer()
        {
            return klassenLijst.HoogsteCijfer();
        }

        public void Print()
        {
            Console.WriteLine($"Klasnaam: {klasNaam}");
            klassenLijst.Print();
        }
    }
}
