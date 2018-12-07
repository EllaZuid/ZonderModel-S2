using System;
using System.Collections.Generic;

namespace Interface_Logic_DAL
{
    public interface IGebruikerDAL
    {
        List<GebruikerInfo> IdRegistratie { get; set; }
        List<GebruikerInfo> GebruikerId { get; set; }
        List<GebruikerInfo> OphalenGebruikersInfo();
        void GebruikerRegistreren(string naam, string wachtwoord, string email, string geslacht, double gewicht, double lengte);
        List<GebruikerInfo> IdRegistratieOphalen(string naam);
    }
}
