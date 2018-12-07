

using Interface_UI_Logic;

namespace Logic
{
    public class Gebruiker : IGebruiker
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
        public string Email { get; set; }
        public double Gewicht { get; set; }
        public double Lengte { get; set; }
        public string Geslacht { get; set; }

        public Gebruiker() {}

        public Gebruiker(string naam, string wachtwoord)
        {
            Naam = naam;
            Wachtwoord = wachtwoord;
        }

        public Gebruiker(int id, string naam, string wachtwoord)
        {
            Id = id;
            Naam = naam;
            Wachtwoord = wachtwoord;
        }

        public Gebruiker(string naam, string wachtwoord, string email, string geslacht, double gewicht, double lengte)
        {
            Naam = naam;
            Wachtwoord = wachtwoord;
            Email = email;
            Geslacht = geslacht;
            Gewicht = gewicht;
            Lengte = lengte;
        }
    }
}
