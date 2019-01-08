using System;
using System.Collections.Generic;
using Factory2;
using Interface_Logic_DAL;
using Interface_UI_Logic;
using DAL;

namespace Logic
{
    public class Activiteit : IActiviteit
    {
        private readonly MemoryFactory _memoryFactory = new MemoryFactory();
        public List<double> LineOverzicht = new List<double>();
        public List<double> BarTijdOverzicht = new List<double>();
        public List<double> BarAfstandOverzicht = new List<double>();

        public DateTime Datum { get; set; }
        public int Tijd { get; set; }
        public decimal GemiddeldeSnelheid { get; set; }
        public int Afstand { get; set; }
        public string[] Status { get; set; }

        public Activiteit() { }

        public Activiteit(int tijd, int afstand, DateTime datum)
        {
            Tijd = tijd;
            Afstand = afstand;
            Datum = datum;
        }

        public Activiteit(int afstand, int tijd)
        {
            Afstand = afstand;
            Tijd = tijd;
        }

        public Activiteit(decimal gemiddeldeSnelheid)
        {
            GemiddeldeSnelheid = gemiddeldeSnelheid;
        }

        public void SetTijd(int tijd)
        {
            this.Tijd = tijd;
        }

        public void SetAfstand(int afstand)
        {
            this.Afstand = afstand;
        }

        public Activiteit(MemoryFactory memoryFactory)
        {
            _memoryFactory = memoryFactory;
        }

        public void GegevensInvullen(Activiteit activiteit, DateTime datum, int gebruikerId)
        {
            activiteit.SetTijd(activiteit.Tijd * 60);
            activiteit.SetAfstand(activiteit.Afstand * 1000);
            _memoryFactory.GegevensInvullen(activiteit.Tijd, datum, activiteit.Afstand, gebruikerId);
        }

        public virtual List<double> ToonOverzichtLine(int id)
        {
            List<ActiviteitInfo> listGemiddeldeSnelheidLine = _memoryFactory.GegevensOverzichtOphalenLine(id);
            foreach (var line in listGemiddeldeSnelheidLine)
            {
                double tijd = Convert.ToDouble(line.Tijd);
                double afstand = Convert.ToDouble(line.Afstand);
                double gemiddeldeSnelheid = BerekenGemiddeldeSnelheid(tijd, afstand);
                LineOverzicht.Add(gemiddeldeSnelheid);
            }

            return LineOverzicht;
        }

        public List<double> ToonOverzichtTijdBar(int id)
        {
            List<double> listTijdBar = _memoryFactory.GegevensOverzichtOphalenTijdBar(id);
            foreach (var bar in listTijdBar)
            {
                double line = bar / 60;
                BarTijdOverzicht.Add(line);
            }

            return BarTijdOverzicht;
        }

        public List<double> ToonOverzichtAfstandBar(int id)
        {
            List<double> listAfstandBar = _memoryFactory.GegevensOverzichtOphalenAfstandBar(id);
            foreach (var bar in listAfstandBar)
            {
                double line = bar / 1000;
                BarAfstandOverzicht.Add(line);
            }

            return BarAfstandOverzicht;
        }

        private double BerekenGemiddeldeSnelheid(double tijd, double afstand)
        {
            double gemiddeldeSnelheid = tijd / afstand;
            return gemiddeldeSnelheid;
        }
    }
}
