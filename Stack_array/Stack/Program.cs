namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int maxAantalElementen = 10;
            int aantal = 0;
            int[] stack = new int[maxAantalElementen];
            Console.WriteLine("Hello, World!");
            
            void Push(int getal)
            {
                if (aantal < maxAantalElementen)
                {
                    stack[aantal] = getal;
                    aantal++;
                }
                else
                {
                    Console.WriteLine("Maximum aantal is bereikt");
                }
            }
            int Pop()
            {
                if (aantal > 0)
                {
                    aantal--;
                    return stack[aantal];
                }
                else
                {
                    Console.WriteLine("Stack is leeg");
                    return 0;
                }
            }
            void Print()
            {
                for (int i = 0; i < aantal; i++)
                {
                    Console.WriteLine(i+ ":" + stack[i]);
                }
            }
            String Commando = "";
            while (Commando != "Stop")
            {
                Console.Write("Geef commando:");
                Commando = Console.ReadLine();
                if (Commando == "Push")
                {
                    Console.Write("Geef Getal:");
                    Push(int.Parse(Console.ReadLine()));
                }
                else if (Commando == "Pop")
                {
                    Console.WriteLine(Pop());
                }
                else if (Commando == "Print")
                    Print();
            }
        }
    }
}
