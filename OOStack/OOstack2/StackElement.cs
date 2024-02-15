using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GelinkteStack
{
    internal class StackElement
    {
        public int Data = 0;
        public StackElement Next = null;
    
        public void Print()
        {
            //Druk jezelf af
            Console.WriteLine(Data);
            //Druk hierna volgende element af
            if (Next != null)
            {
                Next.Print();
            }
        }
    }
}
