using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue
{
    internal class Queue
    {
        private QueueElement Tail = null, Head = null;

        public void EnQueue(int Getal)
        {
            QueueElement NieuwElement = new QueueElement(Getal, Tail);
            if (Tail != null)
            {
                Tail.Next = NieuwElement;
            }
            Tail = NieuwElement;
            if (Head == null) { Head = Tail; }
        }

        public int DeQueue()
        {
            if (Head == null)
            {
                Console.WriteLine("Queue is leeg");
                return 0;
            }
            else
            {
                QueueElement LastElement = Head;
                Head = Head.Next;
                if (Head != null)
                {
                    Head.Prev = null;
                }
                return LastElement.Data;
            }
        }

        public void Print()
        {
            if (Head != null)
            {
                Head.Print();
            }
        }
    }
}

