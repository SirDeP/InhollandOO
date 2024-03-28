using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractStack
{
    internal abstract class EenStackElement
    {
        decimal temp = 0;
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
        public decimal PrintDagwaarde()
        {
            temp = Printdagwaarde();
            
            if (Next != null)
            {
                Next.PrintDagwaarde();
            }
            return temp;
        }

        public virtual void PrintWaarde()
        {
            Console.WriteLine("Ik heb geen data.");
        }

        public virtual decimal Printdagwaarde()
        {
            Console.WriteLine("Ik heb geen data.");
            return 0;
        }
    }
}
