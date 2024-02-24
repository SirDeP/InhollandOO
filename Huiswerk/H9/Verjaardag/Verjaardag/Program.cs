using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Verjaardag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine("Wanneer is je verjaardag (d/m, bv 18/3)");
            DateTime verjaardag = DateTime.Parse(Console.ReadLine());
            Console.WriteLine($"{verjaardag}");

            if (verjaardag < DateTime.Today)
                verjaardag = verjaardag.AddYears(1);

            string dagLokaleTaal = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetDayName(verjaardag.DayOfWeek);
            TimeSpan verschil = verjaardag - DateTime.Today;

            Console.WriteLine($"Je bent over {verschil.Days} dagen jarig op een {dagLokaleTaal}");
        }
    }
}
