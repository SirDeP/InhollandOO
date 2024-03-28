using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Binary_search_tree
{
    internal class Knoop
    {
        public Knoop? Links { get; set; }
        public Knoop? Rechts { get; set; }
        public int Data { get; }
        public Knoop(int data)
        {
            Links = null;
            Rechts = null;
            Data = data;
        }

        public void Print(int diepte)
        {
            diepte++;
            if (Links != null)
            {
                Links.Print(diepte);
            }
            for (int i = 0; i<diepte; i++)
            {
                Console.Write("- ");
            }
            Console.WriteLine(Data);
            if (Rechts != null)
            {
                Rechts.Print(diepte);
            }
        }
    }
}
