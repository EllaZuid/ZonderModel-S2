using System;
using Interface_UI_Logic;
using Logic;

namespace Factory
{
    public class StartupFactory
    {
        //Gebruiker
        public int? Inloggen(IGebruiker Gebruiker)
        {
            GebruikerCollection gebruikerCollection = new GebruikerCollection();
            Gebruiker gebruiker = new Gebruiker(Gebruiker.Naam, Gebruiker.Wachtwoord);
            return gebruikerCollection.Inloggen(gebruiker);
        }

        public int? Registreren(IGebruiker Gebruiker, string wachtwoordHerhaling)
        {
            GebruikerCollection gebruikerCollection = new GebruikerCollection();
            Gebruiker gebruiker = new Gebruiker(Gebruiker.Naam, Gebruiker.Wachtwoord, Gebruiker.Email, Gebruiker.Geslacht, Gebruiker.Gewicht, Gebruiker.Lengte);
            return gebruikerCollection.Registreren(gebruiker, wachtwoordHerhaling);
        }


        //Activiteit
        public void GegevensInvullen(IActiviteit activiteit, int id, DateTime datum)
        {
            Activiteit activiteitlogic = new Activiteit(activiteit.Tijd, activiteit.Afstand, activiteit.Datum);
            activiteitlogic.GegevensInvullen(activiteitlogic, datum, id);
        }
    }
}
