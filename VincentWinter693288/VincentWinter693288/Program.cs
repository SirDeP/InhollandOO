using System.Numerics;

namespace VincentWinter693288
{
    internal class Program
    {
        static void Main(string[] args)
        {
            School TempSchool = new School();
            
            //wagenPark.printAutos(temp);

            string Commando = "";
            while (Commando != "S")
            {
                Console.WriteLine("Geef Commando");
                try
                {
                    Commando = Console.ReadLine()!;
                    if (Commando == "NS")
                    {
                        
                        Console.Write("Geef de naam van de Student:");
                        string tempStudentNaam = Console.ReadLine();
                        Console.Write("Geef het telefoonnummer van de Student:");
                        string tempTelefoonNummer = Console.ReadLine();
                        Console.Write("Geef de Klas van de Student:");
                        string tempKlas = Console.ReadLine();
                        TempSchool.NieuweStudent(tempStudentNaam, tempTelefoonNummer, tempKlas);
                    }
                    else if (Commando == "ZS")
                    {
                        Console.Write("Geef de naam van de Student:");
                        string tempStudentNaam = Console.ReadLine();
                        Console.Write("Geef het telefoonnummer van de Student:");
                        string tempTelefoonNummer = Console.ReadLine();
                        Console.Write("Geef de Klas van de Student:");
                        string tempKlas = Console.ReadLine();
                        Student temp = TempSchool.ZoekStudent(tempStudentNaam, tempTelefoonNummer);
                        //temp.Print();
                    }
                    else if (Commando == "NC")
                    {
                        Console.Write("Geef de naam van de Student:");
                        string tempStudentNaam = Console.ReadLine();
                        Console.Write("Geef het telefoonnummer van de Student:");
                        string tempTelefoonNummer = Console.ReadLine();
                        Console.Write("Geef het Vak van de Student:");
                        string tempVak = Console.ReadLine();
                        Console.Write("Geef het Cijfer van de Student:");
                        int tempCijfer = int.Parse(Console.ReadLine());
                        TempSchool.ZoekStudent(tempStudentNaam, tempTelefoonNummer).NieuwCijfer(tempVak, tempCijfer);
                    }
                    else if (Commando == "P")
                    {
                        //TempSchool.PrintCijferLijst();
                        TempSchool.Print();
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
