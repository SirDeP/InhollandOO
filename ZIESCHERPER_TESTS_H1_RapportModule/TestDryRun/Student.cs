using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RapportModule
{
    internal class Student
    {
        public String Naam { get; set; }
        public int Leeftijd { get; set; }

        //Klas?

        public int PuntenCommunicatie { get; set; }
        public int PuntenProgrammingPrinciples { get; set; }
        public int PuntenWebTech { get; set; }
    }
}
