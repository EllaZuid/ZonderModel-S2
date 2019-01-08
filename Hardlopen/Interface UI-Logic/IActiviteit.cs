using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_UI_Logic
{
    public interface IActiviteit
    {
        DateTime Datum { get; set; }
        int Tijd { get; set; }
        decimal GemiddeldeSnelheid { get; set; }
        int Afstand { get; set; }
        string[] Status { get; set; }
    }
}