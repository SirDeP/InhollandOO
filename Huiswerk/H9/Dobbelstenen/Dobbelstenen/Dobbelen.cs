using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobbelstenen
{
    internal class Dobbelen
    {
        Random rnd = new Random();
        public int Aantal6 { get; private set ; }
        public void WerpEnTel6()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (rnd.Next(1, 7) == 6 && rnd.Next(1, 7) == 6)
                    Aantal6++;
            }
            Console.WriteLine($"{Aantal6} keren 6 gegooid. Dat is {Aantal6 / 10.0}%");

        }
    }
}
