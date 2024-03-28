using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProefTentamen
{
    internal class Verhuurcontract
    {
        public string? ContractNummer { get; set; }
        public string? Kenteken { get; set; }
        public string? BeginDatum { get; set; }
        public string? EindDatum { get; set; }
        public string? KlantNummer { get; set; }
        public bool Betaald {  get; set; }
        public string? KilometerStand { get; set; }

        public string MaakContract(string Kenteken, string BeginDatum, string EindDatum, string Klantnummer)
        {
            return "";
        }

        public void Betaal(string ContractNummer)
        {
            Betaald = true;
        }

    }
}
