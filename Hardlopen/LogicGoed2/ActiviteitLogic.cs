using System;
using System.Collections.Generic;
using DAL;
using Model;

namespace Logic
{
    public class ActiviteitLogic
    {
        private readonly ActiviteitDal _activiteitDal = new ActiviteitDal();
        public List<double> LineOverzicht = new List<double>();
        public List<double> BarTijdOverzicht = new List<double>();
        public List<double> BarAfstandOverzicht = new List<double>();

        public void GegevensInvullen(Activiteit activiteit, int gebruikerId)
        {
            int tijd = activiteit.Tijd * 60;
            int afstand = activiteit.Afstand * 1000;
            _activiteitDal.GegevensInvullen(tijd, activiteit.Datum, afstand, gebruikerId);
        }
        public List<double> ToonOverzichtLine(int id)
        {
            _activiteitDal.GegevensOverzichtOphalenLine(id);
            foreach (var line in _activiteitDal.LoopmomentOverzichtLine)
            {
                double tijd = Convert.ToDouble(line.Tijd);
                double afstand = Convert.ToDouble(line.Afstand);
                double gemiddeldeSnelheid = tijd / afstand;
                LineOverzicht.Add(gemiddeldeSnelheid);
            }

            return LineOverzicht;
        }
        public List<double> ToonOverzichtTijdBar(int id)
        {
            _activiteitDal.GegevensOverzichtOphalenTijdBar(id);
            foreach (var bar in _activiteitDal.LoopmomentOverzichtTijdBar)
            {
                double line = bar / 60;
                BarTijdOverzicht.Add(line);
            }

            return BarTijdOverzicht;
        }

        public List<double> ToonOverzichtAfstandBar(int id)
        {
            _activiteitDal.GegevensOverzichtOphalenAfstandBar(id);
            foreach (var bar in _activiteitDal.LoopmomentOverzichtAfstandBar)
            {
                double line = bar / 1000;
                BarAfstandOverzicht.Add(line);
            }

            return BarAfstandOverzicht;
        }

        private decimal BerekenGemiddeldeSnelheid(int tijd, int afstand)
        {
            decimal gemiddeldeSnelheid = tijd / afstand;
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
