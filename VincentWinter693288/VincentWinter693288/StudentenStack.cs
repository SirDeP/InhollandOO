using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VincentWinter693288
{
    internal class StudentenStack
    {
        Student top = null;

        public StudentenStack()
        {
        }

        public void Push(string StudentNaam, string TelefoonNummer)
        {
            Student NieuweTop = new Student(StudentNaam, TelefoonNummer, top);
            top = NieuweTop;
        }

        public Student ZoekStudent(string StudentNaam, string TelefoonNummer)
        {
            Student temp = top.ZoekStudent(StudentNaam, TelefoonNummer);
            return temp;
        }

        public int HoogsteCijfer()
        {
            if (top != null) { return top.HoogsteCijfer(); }
            else { return 0; }
        }
        public void Print()
        {
            if (top != null) { top.Print(); }
            
        }
    }
}
