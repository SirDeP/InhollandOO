using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_search_tree
{
    internal class BinaireBoom
    {
        Knoop? root = null;

        private void Add(Knoop NieuweKnoop, Knoop BestaandeKnoop)
        {
            if (NieuweKnoop.Data < BestaandeKnoop.Data)
            {
                if (BestaandeKnoop.Links == null)
                {
                    BestaandeKnoop.Links = NieuweKnoop;
                }
                else
                {
                    Add(NieuweKnoop, BestaandeKnoop.Links);
                }
            }
            else
            {
                if (BestaandeKnoop.Rechts == null)
                {
                    BestaandeKnoop.Rechts = NieuweKnoop;
                }
                else
                {
                    Add(NieuweKnoop, BestaandeKnoop.Rechts);
                }
            }
        }
        public void Add(int Getal)
        {
            Knoop knoop = new Knoop(Getal);
            if (root == null)
            {
                root = knoop;
            }
            else
            {
                Add(knoop, root);
            }
        }

        public void Zoek(Knoop BestaandeKnoop, int Getal)
        {
            if (Getal == BestaandeKnoop.Data)
            {
                Console.WriteLine("Gevonden!");
            }
            else
            {
                if ( Getal < BestaandeKnoop .Data )
                {
                    if (BestaandeKnoop.Links == null)
                    {
                        Console.WriteLine("Niet Gevonden");
                    }
                    else
                    {
                        Zoek(BestaandeKnoop.Links, Getal);
                    }
                }
                else
                {
                    if (BestaandeKnoop.Rechts == null)
                    {
                        Console.WriteLine("Niet Gevonden");
                    }
                    else
                    {
                        Zoek(BestaandeKnoop.Rechts, Getal);
                    }
                }
            }
        }

        public void Zoek(int Getal)
        {
            if (root == null)
            {
                Console.WriteLine("Boom is leeg");
            }
            else
            {
                Zoek(root, Getal);
            }
        }

        public void Delete()
        {
            root = null;
        }

        public void Print()
        {
            if (root != null)
            {
                root.Print(0);
            }
            else
            {
                Console.WriteLine("Boom is Leeg");
            }
        }
    }
}
