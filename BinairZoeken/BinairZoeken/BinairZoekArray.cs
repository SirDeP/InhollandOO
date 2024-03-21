using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinairZoeken
{
    internal class BinairZoekArray
    {
        int[] rij;
            public int[] Rij { get { return rij; } }
        public BinairZoekArray(int[] Rij)
        {
            rij = Rij;
        }
        public int Zoek(int Getal)
        {
            int min = 0;
            int max = rij.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (Getal == rij[mid])
                    return ++mid;
                else if (Getal < rij[mid])
                    max = mid - 1;
                else 
                    min = mid + 1;
            }
            return -1;
        }
    }
}
