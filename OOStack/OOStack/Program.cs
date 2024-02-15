namespace OOStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OOStack MyStack = new OOStack();

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
                else if (Commando == "Aantal")
                    Console.WriteLine(MyStack.Aantal + " element(en)");
            }
        }
    }
}
