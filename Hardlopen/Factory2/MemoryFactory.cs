using System;
using System.Collections.Generic;
using DAL;
using Interface_Logic_DAL;

namespace Factory2
{
    public class MemoryFactory
    {
        //Gebruiker
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


        //Activiteit
        public void GegevensInvullen(int tijd, DateTime datum, int afstand, int id)
        {
            ActiviteitDal activiteitDal = new ActiviteitDal();
            activiteitDal.GegevensInvullen(tijd, datum, afstand, id);
        }

        public virtual List<ActiviteitInfo> GegevensOverzichtOphalenLine(int id)
        {
            ActiviteitDal activiteitDal = new ActiviteitDal();
            return activiteitDal.GegevensOverzichtOphalenLine(id);
        }

        public virtual List<double> GegevensOverzichtOphalenTijdBar(int id)
        {
            ActiviteitDal activiteitDal = new ActiviteitDal();
            return activiteitDal.GegevensOverzichtOphalenTijdBar(id);
        }

        public virtual List<double> GegevensOverzichtOphalenAfstandBar(int id)
        {
            ActiviteitDal activiteitDal = new ActiviteitDal();
            return activiteitDal.GegevensOverzichtOphalenAfstandBar(id);
        }
    }
}
