namespace AbstractStack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack MyStack = new Stack();

            string Commando = "";
            string Invoer = "";
            while (Commando != "Stop")
            {
                Console.WriteLine("Geef Commando");
                try
                {
                    Commando = Console.ReadLine();
                    if (Commando == "Push")
                    {
                        Console.Write("Geef Invoer:");
                        Invoer = Console.ReadLine();
                        MyStack.Push(int.Parse(Invoer));
                    }
                    else if (Commando == "Pop")
                    {
                        EenStackElement element = MyStack.Pop();
                        if (element != null)
                        {
                            element.PrintWaarde();
                        }
                        else
                        {
                            Console.WriteLine("Stack is leeg");
                        }
                    }
                    else if (Commando == "Print")
                    {
                        MyStack.Print();
                    }
                }
                catch
                {
                    MyStack.Push(Invoer);
                }
            }
        }
    }
}
