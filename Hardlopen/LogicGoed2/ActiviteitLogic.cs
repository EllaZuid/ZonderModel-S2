using System;
using System.Collections.Generic;
using DAL;
using Model;

namespace Logic
{
    public class ActiviteitLogic
    {
        private readonly ActiviteitDal _activiteitDal;
        public List<double> LineOverzicht = new List<double>();
        public List<double> BarTijdOverzicht = new List<double>();
        public List<double> BarAfstandOverzicht = new List<double>();

        public ActiviteitLogic(ActiviteitDal activiteitDal)
        {
            _activiteitDal = activiteitDal;
        }

        public void GegevensInvullen(Activiteit activiteit, int gebruikerId)
        {
            int tijd = activiteit.Tijd * 60;
            int afstand = activiteit.Afstand * 1000;
            _activiteitDal.GegevensInvullen(tijd, activiteit.Datum, afstand, gebruikerId);
        }
        public virtual List<double> ToonOverzichtLine(int id)
        {
            List<Activiteit> listGemiddeldeSnelheidLine = _activiteitDal.GegevensOverzichtOphalenLine(id);
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
            List<double> listTijdBar = _activiteitDal.GegevensOverzichtOphalenTijdBar(id);
            foreach (var bar in listTijdBar)
            {
                double line = bar / 60;
                BarTijdOverzicht.Add(line);
            }

            return BarTijdOverzicht;
        }

        public List<double> ToonOverzichtAfstandBar(int id)
        {
            List<double> listAfstandBar = _activiteitDal.GegevensOverzichtOphalenAfstandBar(id);
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

        /*public void ToonVergelijking()
        {

        }

        public void GeefStatusUpdate()
        {

        }*/
    }
}
