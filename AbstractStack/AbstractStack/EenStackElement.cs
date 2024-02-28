using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractStack
{
    internal abstract class EenStackElement
    {
        private EenStackElement next;
        public EenStackElement Next { get { return next; } }

        public EenStackElement(EenStackElement stackElement) 
        {
            this.next = stackElement;
        }

        public void PrintStack()
        {
            PrintWaarde();
            if (Next != null)
            {
                Next.PrintStack();
            }
        }

        public virtual void PrintWaarde()
        {
            Console.WriteLine("Ik heb geen data.");
        }
    }
}
