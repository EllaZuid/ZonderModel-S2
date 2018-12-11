using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DAL
{
    public class ActiviteitDal
    {
        const string Connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ella\source\repos\Maatwerk-S2\Hardlopen\Hardlopen\App_Data\DatabaseHardlopen.mdf;Integrated Security=True";
        readonly SqlConnection _conn = new SqlConnection(Connectionstring);

        public List<double> LoopmomentOverzichtAfstandBar = new List<double>();
        public List<Activiteit> LoopmomentOverzichtLine = new List<Activiteit>();

        private void Open()
        {
            _conn.Open();
            Console.WriteLine("Verbonden met " + Connectionstring + ".");
        }

        public void GegevensInvullen(int tijd, DateTime datum, int afstand, int gebruikerId)
        {
            Open();
            string query = "INSERT INTO dbo.[Loopmoment] (gebruiker, tijd, datum, afstand) VALUES (@Gebruiker, @Tijd, @Datum, @Afstand)";
            SqlCommand commandInvullen = new SqlCommand(query, _conn);
            commandInvullen.Parameters.Add("@Gebruiker", SqlDbType.Int).Value = gebruikerId;
            commandInvullen.Parameters.Add("@Tijd", SqlDbType.Int).Value = tijd;
            commandInvullen.Parameters.Add("@Datum", SqlDbType.DateTime).Value = datum;
            commandInvullen.Parameters.Add("@Afstand", SqlDbType.Int).Value = afstand;
            commandInvullen.ExecuteNonQuery();
            Close();
        }

        public List<double> GegevensOverzichtOphalenTijdBar(int id)
        {
            List<double> LoopmomentOverzichtTijdBar = new List<double>();
            Open();
            string query = "SELECT Tijd FROM Loopmoment WHERE Afstand > 1000 AND Gebruiker = @Id";
            SqlCommand commandOverzicht = new SqlCommand(query, _conn);
            commandOverzicht.Parameters.Add("@Id", SqlDbType.NChar).Value = id;
            using (SqlDataReader reader = commandOverzicht.ExecuteReader())
            {
                while (reader.Read())
                {
                    int tijd = reader.GetInt32(0);
                    double tijddouble = Convert.ToDouble(tijd);
                    LoopmomentOverzichtTijdBar.Add(tijddouble);
                }
            }
            Close();
            return LoopmomentOverzichtTijdBar;
        }
        public List<double> GegevensOverzichtOphalenAfstandBar(int id)
        {
            Open();
            string query = "SELECT Afstand FROM Loopmoment WHERE Afstand > 1000 AND Gebruiker = @Id";
            SqlCommand commandOverzicht = new SqlCommand(query, _conn);
            commandOverzicht.Parameters.Add("@Id", SqlDbType.NChar).Value = id;
            using (SqlDataReader reader = commandOverzicht.ExecuteReader())
            {
                LoopmomentOverzichtAfstandBar.Clear();
                while (reader.Read())
                {
                    int afstand = reader.GetInt32(0);
                    double afstanddouble = Convert.ToDouble(afstand);
                    LoopmomentOverzichtAfstandBar.Add(afstanddouble);
                }
            }
            Close();
            return LoopmomentOverzichtAfstandBar;
        }

        public List<Activiteit> GegevensOverzichtOphalenLine(int id)
        {
            Open();
            string query = "SELECT Tijd, Afstand FROM Loopmoment WHERE Afstand > 1000 AND Gebruiker = @Id";
            SqlCommand commandOverzicht = new SqlCommand(query, _conn);
            commandOverzicht.Parameters.Add("@Id", SqlDbType.NChar).Value = id;
            using (SqlDataReader reader = commandOverzicht.ExecuteReader())
            {
                LoopmomentOverzichtLine.Clear();
                while (reader.Read())
                {
                    int afstand = reader.GetInt32(0);
                    int tijd = reader.GetInt32(1);
                    Activiteit activiteit = new Activiteit(afstand, tijd);
                    LoopmomentOverzichtLine.Add(activiteit);
                }
            }
            Close();
            return LoopmomentOverzichtLine;
        }

        private void Close()
        {
            _conn.Close();
            Console.WriteLine("Verbinding verbroken.");
        }
    }
}
