using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    internal class HashTable
    {
        private string[] tabel;
        private int maxElementen;

        public HashTable(int Grootte)
        {
            maxElementen = Grootte;
            tabel = new string[maxElementen];
            for (int i = 0; i < tabel.Length; i++)
            {
                tabel[i] = null;
            }
        }

        private int Hash(string Woord)
        {
            int HashValue = 0;
            for (int i = 0; i < Woord.Length; i++)
            {
                HashValue += ((int)Woord[i]);
            }
            return HashValue % maxElementen;
        }

        public void Add(string Woord)
        {
            int hash = Hash(Woord);
            int position = hash;

            while (position != -1)
            {
                if (tabel[position] == null)
                {
                    tabel[position] = Woord;
                    return;
                }
                else
                {
                    position--;
                }
            }

            position = maxElementen - 1;
            while (position != hash)
            {
                if (tabel[position] == null)
                {
                    tabel[position] = Woord;
                    return;
                }
                else
                {
                    position--;
                }
            }
            Console.WriteLine("Hashtable overflow");
        }

        public void Zoek(string Woord) 
        {
            int hash = Hash(Woord);
            int position = hash;

            while (position != -1)
            {
                if (tabel[position] == Woord)
                {
                    Console.WriteLine("Gevonden");
                    return;
                }
                else if (tabel[position] == null)
                {
                    Console.WriteLine("Niet Gevonden");
                    return;
                }
                else
                {
                    position--;
                }
            }

            position = maxElementen - 1;
            while (position != hash)
            {
                if (tabel[position] == Woord)
                {
                    Console.WriteLine("Gevonden");
                    return;
                }
                else if (tabel[position] == null)
                {
                    Console.WriteLine("Niet Gevonden");
                    return;
                }
                else
                {
                    position--;
                }
            }
            Console.WriteLine("Niet Gevonden");
        }

        public void Print()
        {
            for (int i = 0; i < tabel.Length; i++)
            {
                Console.WriteLine(i+ ";" + tabel[i]);
            }
        }
    }
}
