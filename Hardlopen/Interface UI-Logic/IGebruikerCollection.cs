using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_UI_Logic
{
    public interface IGebruikerCollection
    {
        int? Inloggen(IGebruiker gebruiker);
        int? Registreren(IGebruiker gebruiker, string wachtwoord2Invoer);
    }
}
