using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue_opdracht
{
    internal class QueueElement
    {
        //public int Data = 0;
        //public StackElement Next = null;

        private int data;
        private QueueElement next;
        private QueueElement prev;

        public int Data { get { return data; } }
        public QueueElement Next { get { return next; } set { next = value; } }
        public QueueElement Prev { get { return prev; } set { prev = value; } }
        public QueueElement(int data, QueueElement Volgende)
        {
            this.data = data;
            this.next = Volgende;
            this.prev = null;
        }

        private QueueElement() { }

        public void Print()
        {
            //Druk jezelf af
            if (data != null) { Console.WriteLine(Data); }
            else { Console.WriteLine("DATA NULL"); }
            
            //Druk hierna volgende element af
            if (Prev != null)
            {
                Prev.Print();
            }
        }
    }
}
