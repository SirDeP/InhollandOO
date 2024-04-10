using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentWinter693288
{
    internal class School
    {
        
        int AantalKlassen = 4;
        Klas[] Klassen = new Klas[4];
        public School()
        {
            for (int i = 0;  i < AantalKlassen; i++)
            {
                Klassen[i] = new($"TI{i+1}");
            }
        }

        public void NieuweStudent(string StudentNaam, string TelefoonNummer, string KlasNaam) 
        {
            for(int i = 0; i < Klassen.Length; i++)
            {
                if (Klassen[i].GetKlasNaam() == KlasNaam)
                {
                    Klassen[i].NieuweStudent(StudentNaam, TelefoonNummer);
                }
            }
        }
        public Student ZoekStudent(string StudentNaam, string TelefoonNummer)
        {
            for (int i = 0; i < AantalKlassen; i++)
            {
                //if (Klassen[i].GetKlasNaam() == KlasNaam)
                //{
                //    Klassen[i].NieuweStudent(StudentNaam, TelefoonNummer);
                //}
                Student temp = Klassen[i].ZoekStudent(StudentNaam, TelefoonNummer);
                return temp;
            }
            return null;
        }

        public void Print()
        {
            for (int i = 0; i < Klassen.Length; i++)
            {
                Klassen[i].Print();
            }
        }

    }
}
