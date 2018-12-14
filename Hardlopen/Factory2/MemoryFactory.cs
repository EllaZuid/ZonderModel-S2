using System.Collections.Generic;
using DAL;
using Interface_Logic_DAL;

namespace Factory2
{
    public class MemoryFactory
    {
        public List<GebruikerInfo> OphalenGebruikersInfo()
        {
            GebruikerDal gebruikerDal = new GebruikerDal();
            return gebruikerDal.OphalenGebruikersInfo();
        }

        public void GebruikerRegistreren(string naam, string wachtwoord, string email, string geslacht, double gewicht, double lengte)
        {
            GebruikerDal gebruikerDal = new GebruikerDal();
            gebruikerDal.GebruikerRegistreren(naam, wachtwoord, email, geslacht, gewicht, lengte);
        }

        public List<GebruikerInfo> IdRegistratieOphalen(string naam)
        {
            GebruikerDal gebruikerDal = new GebruikerDal();
            return gebruikerDal.IdRegistratieOphalen(naam);
        }
    }
}
