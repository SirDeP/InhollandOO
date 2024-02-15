using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOStack
{
    internal class OOStack
    {
        const int maxAantalElementen = 10;
        int aantal = 0;
        int[] stack = new int[maxAantalElementen];
        
        public int Aantal
        {
            get { return aantal; }
        }
            
        public void Push(int getal)
        {
            if (aantal < maxAantalElementen)
            {
                stack[aantal] = getal;
                aantal++;
            }
            else
            {
                Console.WriteLine("Maximum aantal is bereikt");
            }
        }
        public int Pop()
        {
            if (aantal > 0)
            {
                aantal--;
                return stack[aantal];
            }
            else
            {
                Console.WriteLine("Stack is leeg");
                return 0;
            }
        }
        public void Print()
        {
            for (int i = 0; i < aantal; i++)
            {
                Console.WriteLine(i + ":" + stack[i]);
            }
        }
        
    }
}
