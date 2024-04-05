using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueOpdr
{
    public class Queue
    {
        private QueueElement? _head;
        private QueueElement? _tail;

        public QueueElement? Head { get => _head; }
        public QueueElement? Tail { get => _tail; }
        public int Count { get; private set; }

        public void Enqueue(int data)
        {
            var element = new QueueElement(data, _tail);

            if (_tail != null)
                _tail.Next = element;

            _tail = element;

            if (_head == null)
                _head = _tail;

            Count++;
        }

        public int Dequeue()
        {
            if (_head == null)
            {
                Console.WriteLine("Queue is empty");
                return 0;
            }
            else
            {
                var head = _head;
                _head = _head.Next;

                if (_head != null)
                    _head.Prev = null;

                Count--;
                return head.Data;
            }
        }

        public void Print()
        {
            if (_head != null)
            {
                _head.Print();
            }
        }
    }
}
