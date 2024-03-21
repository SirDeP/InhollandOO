using Sorting;
namespace BinairZoeken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
            Console.Write("Aantal Elementen:");
            int Aantal = int.Parse(Console.ReadLine());
            int[] Rij = new int[Aantal];
            for (int i = 0; i < Rij.Length; i++)
            {
                Console.Write("Geef getal;");
                Rij[i] = int.Parse(Console.ReadLine());
            }
            BinairZoekArray zoekArray = new BinairZoekArray(new InsertionSortArray(Rij).Rij);

            int Getal = 0;
            Console.Write("Zoek getal:");
            Getal = int.Parse(Console.ReadLine());
                while (Getal > int.MinValue)
                {
                    int positie = zoekArray.Zoek(Getal);
                    if (positie > 0)
                    {
                        Console.WriteLine("Gevonden op positie " + positie);
                    }
                    else
                    {
                        Console.WriteLine("Niet gevonden");
                    }
                    Console.Write("Zoek getal:");
                    Getal = int.Parse(Console.ReadLine());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
