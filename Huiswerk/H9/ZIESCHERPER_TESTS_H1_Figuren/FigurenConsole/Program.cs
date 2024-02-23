using System;

namespace FigurenConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Driehoek driehoek1 = new Driehoek();
            Driehoek driehoek2 = new Driehoek();
            Driehoek driehoek3 = new Driehoek();
            Driehoek driehoek4 = new Driehoek();

            Rechthoek rechthoek1 = new Rechthoek();
            Rechthoek rechthoek2 = new Rechthoek();
            Rechthoek rechthoek3 = new Rechthoek();
            Rechthoek rechthoek4 = new Rechthoek();

            rechthoek1.Lengte = 3; rechthoek1.Breedte = 7;
            rechthoek2.Lengte = 32; rechthoek2.Breedte = 12;
            rechthoek3.Lengte = 11; rechthoek3.Breedte = 33;
            rechthoek4.Lengte = 28; rechthoek4.Breedte = 10;

            driehoek1.Basis = 21; driehoek1.Hoogte = 34;
            driehoek2.Basis = 3; driehoek2.Hoogte = 55;
            driehoek3.Basis = 66; driehoek3.Hoogte = 23;
            driehoek4.Basis = 43; driehoek4.Hoogte = 66;

            driehoek1.ToonOppervlakte();
            driehoek2.ToonOppervlakte();
            driehoek3.ToonOppervlakte();
            driehoek4.ToonOppervlakte();

            rechthoek1.ToonOppervlakte();
            rechthoek2.ToonOppervlakte();
            rechthoek3.ToonOppervlakte();
            rechthoek4.ToonOppervlakte();

            Console.WriteLine("Hello World!");
             
        }
    }
}
