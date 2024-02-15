using GelinkteStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GelinkteStack
{
    internal class Stack
    {
        StackElement Top = null;
        public void Push(int Getal)
        {
            StackElement NieuweTop = new StackElement();
            NieuweTop.Data = Getal;
            NieuweTop.Next = Top;
            Top = NieuweTop;
        }
        public int Pop()
        {
            if (Top != null)
            {
                int Getal = Top.Data;
                Top = Top.Next;
                return Getal;
            }
            else
            {
                Console.WriteLine("Stack is leeg");
                return 0;
            }
        }
        public void Print()
        {
                Top.Print();
        }
    }
}

