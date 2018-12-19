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

        private void Open()
        {
            _conn.Open();
            Console.WriteLine("Verbonden met " + Connectionstring + ".");
        }

        public void GegevensInvullen(Activiteit activiteit, int gebruikerId)
        {
            Open();
            string query = "INSERT INTO dbo.[Loopmoment] (gebruiker, tijd, datum, afstand) VALUES (@Gebruiker, @Tijd, @Datum, @Afstand)";
            SqlCommand commandInvullen = new SqlCommand(query, _conn);
            commandInvullen.Parameters.Add("@Gebruiker", SqlDbType.Int).Value = gebruikerId;
            commandInvullen.Parameters.Add("@Tijd", SqlDbType.Int).Value = activiteit.Tijd;
            commandInvullen.Parameters.Add("@Datum", SqlDbType.DateTime).Value = activiteit.Datum;
            commandInvullen.Parameters.Add("@Afstand", SqlDbType.Int).Value = activiteit.Afstand;
            commandInvullen.ExecuteNonQuery();
            Close();
        }

        public virtual List<double> GegevensOverzichtOphalenTijdBar(int id)
        {
            List<double> loopmomentOverzichtTijdBar = new List<double>();
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
                    loopmomentOverzichtTijdBar.Add(tijddouble);
                }
            }
            Close();
            return loopmomentOverzichtTijdBar;
        }
        public virtual List<double> GegevensOverzichtOphalenAfstandBar(int id)
        {
            List<double> loopmomentOverzichtAfstandBar = new List<double>();
            Open();
            string query = "SELECT Afstand FROM Loopmoment WHERE Afstand > 1000 AND Gebruiker = @Id";
            SqlCommand commandOverzicht = new SqlCommand(query, _conn);
            commandOverzicht.Parameters.Add("@Id", SqlDbType.NChar).Value = id;
            using (SqlDataReader reader = commandOverzicht.ExecuteReader())
            {
                loopmomentOverzichtAfstandBar.Clear();
                while (reader.Read())
                {
                    int afstand = reader.GetInt32(0);
                    double afstanddouble = Convert.ToDouble(afstand);
                    loopmomentOverzichtAfstandBar.Add(afstanddouble);
                }
            }
            Close();
            return loopmomentOverzichtAfstandBar;
        }

        public virtual List<Activiteit> GegevensOverzichtOphalenLine(int id)
        {
            List<Activiteit> LoopmomentOverzichtLine = new List<Activiteit>();
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
