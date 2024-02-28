using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_opdracht
{
    internal class Queue
    {
        QueueElement Head = null;
        QueueElement Tail = null;
        public void EnQueue(int Getal)
        {
            QueueElement NieuwTail = new QueueElement(Getal, Tail);
            //NieuweTop.Data = Getal;
            //NieuweTop.Next = Top;
            if (Tail != null) { Tail.Prev = NieuwTail; }
            
            Tail = NieuwTail;
            if (Head == null) { Head = Tail; }
        }
        public int DeQueue()
        {
            if (Head != null)
            {
                int getal = Head.Data;
                Head = Head.Prev;
                Head.Next = null;
                Console.WriteLine("DeQueued");
                return getal;
            }
            else
            {
                Console.WriteLine("Queue is leeg");
                return 0;
            }
        }
        public void Print()
        {
            Head.Print();
        }
    }

}
