namespace HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashTable MyTable = new HashTable(10);

            String Commando = "";
            while (Commando != "s")
            {
                try
                {
                    Console.Write("Geef Commando:");
                    Commando = Console.ReadLine();
                    if (Commando == "a")
                    {
                        Console.Write("Geef Woord:");
                        MyTable.Add(Console.ReadLine());
                    }
                    else if (Commando == "z")
                    {
                        Console.Write("Geef ZoekTerm:");
                        MyTable.Zoek(Console.ReadLine());
                    }
                    else if (Commando == "p")
                        MyTable.Print();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
