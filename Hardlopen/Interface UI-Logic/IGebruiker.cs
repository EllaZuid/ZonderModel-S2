using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_UI_Logic
{
    public interface IGebruiker
    {
        int Id { get; set; }
        string Naam { get; set; }
        string Wachtwoord { get; set; }
        string Email { get; set; }
        double Gewicht { get; set; }
        double Lengte { get; set; }
        string Geslacht { get; set; }
    }
}
