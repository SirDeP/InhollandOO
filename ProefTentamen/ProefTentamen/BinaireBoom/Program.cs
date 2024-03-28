namespace Binary_search_tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaireBoom MijnBoom = new BinaireBoom();
            String Commando = "";
            while (Commando != "s")
            {
                try
                {
                    Console.Write("Geef Commando:");
                    Commando = Console.ReadLine();
                    if (Commando == "a")
                    {
                        Console.Write("Geef Getal:");
                        MijnBoom.Add(int.Parse(Console.ReadLine()));
                    }
                    else if (Commando == "z")
                    {
                        Console.Write("Geef Getal:");
                        MijnBoom.Zoek(int.Parse(Console.ReadLine()));
                    }
                    else if (Commando == "p")
                    {
                        MijnBoom.Print();
                    }
                    else if (Commando == "d")
                    {
                        MijnBoom.Delete();   
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
