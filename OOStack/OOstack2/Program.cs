namespace GelinkteStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack MyStack = new Stack();

            String Commando = "";
            while (Commando != "Stop")
            {
                Console.Write("Geef commando:");
                Commando = Console.ReadLine();
                if (Commando == "Push")
                {
                    Console.Write("Geef Getal:");
                    MyStack.Push(int.Parse(Console.ReadLine()));
                }
                else if (Commando == "Pop")
                {
                    Console.WriteLine(MyStack.Pop());
                }
                else if (Commando == "Print")
                    MyStack.Print();
            }
        }
    }
}
