namespace Queue_opdracht
{
    internal class Program
    {
            static void Main(string[] args)
            {
                Queue MyQueue = new Queue();

                String Commando = "";
                while (Commando != "Stop")
                {
                    Console.Write("Geef commando:");
                    Commando = Console.ReadLine();
                    try
                    {

                        if (Commando == "Push")
                        {
                            Console.Write("Geef Getal:");
                            MyQueue.EnQueue(int.Parse(Console.ReadLine()));
                        }
                        else if (Commando == "Pop")
                        {
                        Console.WriteLine(MyQueue.DeQueue());

                    }
                        else if (Commando == "Print")
                            MyQueue.Print();
                        else throw new Exception("Onbekend Commando");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Op naar het volgende commando");
                    }
                }
            }
        }
    }
