using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class InsertionSortArray
    {
        int[] rij;
        public int[] Rij { get { return rij; } }

        public InsertionSortArray(int[] Rij)
        {
            rij = Rij;
        }

        public InsertionSortArray insertionSort()
        {
            int positie = 1;

            while (positie < rij.Length)
            { // Swap
                int nieuwePositie = positie;
                while (nieuwePositie > 0 && rij[nieuwePositie - 1] > rij[nieuwePositie])
                {
                    int temp = rij[nieuwePositie - 1];
                    rij[nieuwePositie - 1] = rij[nieuwePositie];
                    rij[nieuwePositie] = temp;
                    nieuwePositie--;
                }
                positie++;
            }
            return this;
        }

        public InsertionSortArray Print()
        {
            for (int i = 0; i < rij.Length; i++)
            {
                Console.Write(rij[i] + " ");
            }
            Console.WriteLine();
            return this;
        }

        public InsertionSortArray insertionSortMetPrint()
        {
            int positie = 1;

            while (positie < rij.Length)
            {
                int nieuwePositie = positie;
                while (nieuwePositie > 0 && rij[nieuwePositie - 1] > rij[nieuwePositie])
                { // Swap
                    int temp = rij[nieuwePositie - 1];
                    rij[nieuwePositie - 1] = rij[nieuwePositie];
                    rij[nieuwePositie] = temp;
                    nieuwePositie--;
                }
                positie++;
                Print();
            }
            return this;
        }
    }
}
