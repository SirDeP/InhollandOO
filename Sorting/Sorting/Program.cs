using System.Reflection.Metadata.Ecma335;

namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
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
                    new InsertionSortArray(Rij).insertionSortMetPrint().Print();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
