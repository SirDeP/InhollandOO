using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GelinkteStack
{
    internal class StackElement
    {
        //public int Data = 0;
        //public StackElement Next = null;

        private int data;
        private StackElement next;
    
        public int Data { get { return data; } }
        public StackElement Next { get { return next; } }
        public StackElement(int data, StackElement stackElement)
        {
            this.data = data;
            this.next = stackElement;
        }

        private StackElement() { }

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
