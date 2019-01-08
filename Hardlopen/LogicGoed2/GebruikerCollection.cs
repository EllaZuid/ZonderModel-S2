using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Interface_UI_Logic;
using Interface_Logic_DAL;
using Factory2;

namespace Logic
{
    public class GebruikerCollection : IGebruiker
    {
        private readonly MemoryFactory _memoryFactory = new MemoryFactory();

        public string HashedWachtwoord;

        public int Id { get; set; }
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
        public string Email { get; set; }
        public double Gewicht { get; set; }
        public double Lengte { get; set; }
        public string Geslacht { get; set; }

        public GebruikerCollection() { }

        public GebruikerCollection(int id, string naam)
        {
            Id = id;
            Naam = naam;
        }

        public GebruikerCollection(string naam, string wachtwoord)
        {
            Naam = naam;
            Wachtwoord = wachtwoord;
        }
        public GebruikerCollection(int id, string naam, string wachtwoord)
        {
            Id = id;
            Naam = naam;
            Wachtwoord = wachtwoord;
        }

        public GebruikerCollection(string naam, string wachtwoord, string email, string geslacht, double gewicht, double lengte)
        {
            Naam = naam;
            Wachtwoord = wachtwoord;
            Email = email;
            Geslacht = geslacht;
            Gewicht = gewicht;
            Lengte = lengte;
        }

        public int? Inloggen(Gebruiker gebruiker)
        {
            List<GebruikerInfo> gebruikersInfo =_memoryFactory.OphalenGebruikersInfo();
            for (int i = 0; i < gebruikersInfo.Count; i++)
            {
                string naam = gebruikersInfo[i].Naam.Replace(" ", "");
                if (naam == gebruiker.Naam)
                {
                    string wachtwoord = gebruikersInfo[i].Wachtwoord.Replace(" ", "");
                    if (VergelijkWachtwoorden(gebruiker.Wachtwoord, wachtwoord))
                    { 
                        return gebruikersInfo[i].Id;

                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return null;
        }

        public int? Registreren(Gebruiker gebruiker, string wachtwoord2Invoer)
        {
            if (gebruiker.Wachtwoord == wachtwoord2Invoer)
            {
                HashWachtwoord(gebruiker.Wachtwoord);
                _memoryFactory.GebruikerRegistreren(gebruiker.Naam, HashedWachtwoord, gebruiker.Email, gebruiker.Geslacht, gebruiker.Gewicht, gebruiker.Lengte);
                var var = _memoryFactory.IdRegistratieOphalen(gebruiker.Naam);
                for (int i = 0; i < var.Count; i++)
                {
                    if (gebruiker.Naam == var[i].Naam)
                    {
                        return var[i].Id;
                    }
                }
            }
            else
            {
                return null;
            }
            return null;
        }

        private void HashWachtwoord(string wachtwoordInvoer)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(wachtwoordInvoer, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            HashedWachtwoord = Convert.ToBase64String(hashBytes);
        }

        private bool VergelijkWachtwoorden(string wachtwoordInvoer, string wachtwoordhash)
        {
            byte[] hashBytes = Convert.FromBase64String(wachtwoordhash);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(wachtwoordInvoer, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
