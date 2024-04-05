using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue
{
    internal class QueueElement
    {
        int data;
        public int Data { get { return data; } }
        public QueueElement Next { get; set; }
        public QueueElement Prev {  get; set; }
        public QueueElement(int Getal, QueueElement TailElement)
        {
            data = Getal;
            Prev = TailElement;
            Next = null;
        }
        public void Print()
        {
            Console.WriteLine(Data);
            if (Next != null)
            {
                Next.Print();
            }
        }
    }
}
