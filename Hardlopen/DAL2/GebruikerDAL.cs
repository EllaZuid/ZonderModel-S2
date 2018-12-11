using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Interface_Logic_DAL;

namespace DAL
{
    public class GebruikerDal : IGebruikerDAL
    {
        const string Connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\ELLA\SOURCE\REPOS\MAATWERK-S2\ZONDERMODEL-S2\HARDLOPEN\HARDLOPEN\APP_DATA\DATABASEHARDLOPEN.MDF";
        readonly SqlConnection _conn = new SqlConnection(Connectionstring);

        public List<GebruikerInfo> IdRegistratie { get; set; } = new List<GebruikerInfo>();
        public List<GebruikerInfo> GebruikerId { get; set; } = new List<GebruikerInfo>();

        private void Open()
        {
            _conn.Open(); 
            Console.WriteLine("Verbonden met " + Connectionstring + ".");
        }

        public List<GebruikerInfo> OphalenGebruikersInfo()
        {
            Open();
            string query = "SELECT ID, Naam, Wachtwoord FROM Gebruiker";
            SqlCommand commandInloggen = new SqlCommand(query, _conn);
            
            using (SqlDataReader reader = commandInloggen.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string naam = reader.GetString(1);
                    string wachtwoord = reader.GetString(2);
                    GebruikerInfo persoon = new GebruikerInfo(id, naam, wachtwoord);
                    GebruikerId.Add(persoon);
                }
            }
            Close();
            return GebruikerId;
        }

        public void GebruikerRegistreren(string naam, string wachtwoord, string email, string geslacht, double gewicht, double lengte)
        {
            Open();
            string query = "INSERT INTO dbo.[Gebruiker] (naam, wachtwoord, email, geslacht, gewicht, lengte) VALUES (@Naam, @Wachtwoord, @Email, @Geslacht, @Gewicht, @Lengte)";
            SqlCommand commandRegistreren = new SqlCommand(query, _conn);
            commandRegistreren.Parameters.Add("@Naam", SqlDbType.NChar).Value = naam;
            commandRegistreren.Parameters.Add("@Wachtwoord", SqlDbType.VarChar).Value = wachtwoord;
            commandRegistreren.Parameters.Add("@Email", SqlDbType.NChar).Value = email;
            commandRegistreren.Parameters.Add("@geslacht", SqlDbType.NChar).Value = geslacht;
            commandRegistreren.Parameters.Add("@Lengte", SqlDbType.Float).Value = lengte;
            commandRegistreren.Parameters.Add("@Gewicht", SqlDbType.Float).Value = gewicht;
            commandRegistreren.ExecuteNonQuery();
            Close();
        }

        public List<GebruikerInfo> IdRegistratieOphalen(string naam)
        {
            Open();
            string query = "SELECT ID FROM Gebruiker WHERE Naam = @Naam";
            SqlCommand commandId = new SqlCommand(query, _conn);
            commandId.Parameters.Add("@Naam", SqlDbType.NChar).Value = naam;
            using (SqlDataReader reader = commandId.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    GebruikerInfo persoon = new GebruikerInfo(id, naam);
                    IdRegistratie.Add(persoon);
                }
            }
            Close();
            return IdRegistratie;
        }

        private void Close()
        {
            _conn.Close();
            Console.WriteLine("Verbinding verbroken.");
        }
    }
}
