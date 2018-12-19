using System;

namespace Model
{
    public class Activiteit
    {
        public DateTime Datum { get; private set; }
        public int Tijd { get; private set; }
        public decimal GemiddeldeSnelheid { get; private set; }
        public int Afstand { get; private set; }
        public Array[] Status { get; private set; }
        public Route Route { get; private set; }
        public Playlist Playlist { get; private set; }

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
    }
}
