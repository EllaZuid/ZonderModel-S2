using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Logic_DAL
{
    public struct GebruikerInfo
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
        public string Email { get; set; }
        public double Gewicht { get; set; }
        public double Lengte { get; set; }
        public string Geslacht { get; set; }

        public GebruikerInfo(int id, string naam)
        {
            Id = id;
            Naam = naam;
            Wachtwoord = null;
            Email = null;
            Gewicht = 0;
            Lengte = 0;
            Geslacht = null;
        }

        public GebruikerInfo(int id, string naam, string wachtwoord)
        {
            Id = id;
            Naam = naam;
            Wachtwoord = wachtwoord;
            Email = null;
            Gewicht = 0;
            Lengte = 0;
            Geslacht = null;
        }
    }
}
