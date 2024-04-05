using System.Numerics;

namespace LiftProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LiftenBesturing LiftBesturing = new LiftenBesturing();

            String Commando = "";
            while (Commando != "s")
            {
                try
                {
                    Console.Write("Geef Commando:");
                    Commando = Console.ReadLine()!;
                    if (Commando == "v")
                    {
                        Console.Write("Geef huidige verdieping (0-3)");
                        int verdieping = int.Parse(Console.ReadLine()!);
                        Console.Write("Wil je omhoog (h) of omlaag (l)?:");
                        string richting = Console.ReadLine();
                        if (richting == "h") richting = "Omhoog";
                        else if (richting == "l") richting = "Omlaag";
                        LiftBesturing.RegistreerVerzoek(verdieping, richting);
                    }
                    else if (Commando == "a")
                    {
                        LiftBesturing.AktiveerLiften();
                    }
                    else if (Commando == "n")
                        LiftBesturing.Noodstop();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
