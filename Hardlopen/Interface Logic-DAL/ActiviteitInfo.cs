using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_Logic_DAL
{
    public struct ActiviteitInfo
    {
        public DateTime? Datum { get; set; }
        public int Tijd { get; set; }
        public double GemiddeldeSnelheid { get; set; }
        public int Afstand { get; set; }
        public string[] Status { get; set; }

        public ActiviteitInfo(int tijd, int afstand)
        {
            Datum = null;
            Tijd = tijd;
            GemiddeldeSnelheid = 0;
            Afstand = afstand;
            Status = null;
        }
    } 
}
