using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VincentWinter693288
{
    internal class Student
    {
        string studentNaam;
        string telefoonNummer;
        private ResultaatStack cijferLijst = new();
        private Student volgendeStudent;

        public Student(string StudentNaam, string TelefoonNummer, Student student)
        {
            this.studentNaam = StudentNaam;
            this.telefoonNummer = TelefoonNummer;
            this.volgendeStudent = student;
        }

        public void NieuwCijfer(string Vak, int Cijfer)
        {
            cijferLijst.Push(Vak, Cijfer);
        }

        public Student ZoekStudent(string StudentNaam, string TelefoonNummer)
        {
            if (this.studentNaam == StudentNaam && this.telefoonNummer == TelefoonNummer)
            {
                Console.WriteLine("Student gevonden op School");
                return this;
            }
            else if (volgendeStudent != null)
            {
                volgendeStudent.ZoekStudent(StudentNaam, TelefoonNummer);
            }
            return null;
        }

        public int HoogsteCijfer()
        {
            cijferLijst.HoogsteCijfer();
            return 0;
        }

        public void Print()
        {
            Console.WriteLine("=======================");
            Console.WriteLine($"StudentenNaam: {studentNaam}");
            Console.WriteLine($"Telefoonnummer: {telefoonNummer}");
            cijferLijst.Print();

            if (volgendeStudent != null)
            {
                volgendeStudent.Print();
            }
        }

    }
}
