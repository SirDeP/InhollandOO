using AbstractStack;

namespace ProefTentamen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Klant S = new Klant();
            //S.Woonplaats = "A";
            //S.Naam = "B";
            //S.Adres = "C";
            //S.TelefoonNummer = "D";
            ////S.KlantNummer = "";
            //S.Rijbewijs = "F";
            //S.Postcode = "H";
            //bool test = S.IsBetrouwbaar();
            //Console.WriteLine(test);
            
            WagenPark wagenPark = new WagenPark();
            //wagenPark.printAutos(temp);

            string Commando = "";
            string Invoer = "";
            while (Commando != "S")
            {
                Console.WriteLine("Geef Commando");
                try
                {
                    Commando = Console.ReadLine();
                    if (Commando == "A")
                    {
                        Auto temp = new Auto();
                        //Console.Write("Geef het Kenteken:");
                        //temp.Kenteken = Console.ReadLine();
                        //Console.Write("Geef de Kilometerstand:");
                        //temp.Kilometerstand = int.Parse(Console.ReadLine());
                        Console.Write("Geef de Dagwaarde:");
                        temp.Dagwaarde = decimal.Parse(Console.ReadLine());
                        //Console.Write("Geef de Verhuurprijs:");
                        //temp.VerhuurPrijs = decimal.Parse(Console.ReadLine());
                        //Console.Write("Geef het Merk:");
                        //temp.Merk = Console.ReadLine();
                        wagenPark.AddAuto(temp);
                    }
                    else if (Commando == "K")
                    {
                        Klant temp = new Klant();
                        Console.Write("Geef het Klantnummer:");
                        temp.KlantNummer = Console.ReadLine();
                        Console.Write("Geef de Naam:");
                        temp.Naam = Console.ReadLine();
                        Console.Write("Geef de Adres:");
                        temp.Adres = Console.ReadLine();
                        Console.Write("Geef de Woonplaats:");
                        temp.Woonplaats = Console.ReadLine();
                        Console.Write("Geef de Postcode:");
                        temp.Postcode = Console.ReadLine();
                        Console.Write("Geef het telefoonnummer:");
                        temp.TelefoonNummer = Console.ReadLine();
                        ////EenStackElement element = MyStack.Pop();
                        //if (element != null)
                        //{
                        //    //element.PrintWaarde();
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Stack is leeg");
                        //}
                    }
                    else if (Commando == "P")
                    {
                        wagenPark.printAutos();
                    }
                    else if (Commando == "Pd")
                    {
                        wagenPark.TotaalBedrag();
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                    //MyStack.Push(Invoer);
                }
            }
        }
    }
}
