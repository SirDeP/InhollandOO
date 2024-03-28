using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractStack;

namespace ProefTentamen
{
    internal enum Status
    {
        Vrij,
        Onderhoud,
        Gereserveerd,
        Verhuurd
    }
    internal class Auto
    {
        Stack VerhuurContractenLijst = new Stack();
        public string? Kenteken { get; set; }
        public int Kilometerstand { get; set; }
        public decimal Dagwaarde {  get; set; }
        public decimal VerhuurPrijs {  get; set; }
        public Status Status { get; set; }
        public string? Merk {  get; set; }

        public void Reserveer()
        {
            Status = Status.Gereserveerd;
        }

        public bool IsBeschikbaar()
        {
            return true;
        }
    }
}
