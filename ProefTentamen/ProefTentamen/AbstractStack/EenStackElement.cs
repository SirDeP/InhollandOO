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
        public decimal PrintDagwaarde(decimal temp2)
        {
            temp2 += Printdagwaarde();
            if (Next != null)
            {
                temp2 = Next.PrintDagwaarde(temp2);
            }
            return temp2;

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
