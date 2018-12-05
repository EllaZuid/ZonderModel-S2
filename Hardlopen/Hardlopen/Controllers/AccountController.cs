using System;
using System.Web.Mvc;
using Hardlopen.viewModels;
using Interface_UI_Logic;
using Logic;
using Factory;

namespace Hardlopen.Controllers
{
    public class AccountController : Controller
    {
        StartupFactory factory = new StartupFactory();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inloggen()
        {
            InloggenViewModel viewModel = new InloggenViewModel();
            viewModel.GebruikersNaam = String.Empty;
            viewModel.Wachtwoord = String.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult Inloggen(InloggenViewModel viewModel)
        {
            IGebruiker gebruiker = new Gebruiker(viewModel.GebruikersNaam, viewModel.Wachtwoord);
            Session["idIngeloggd"] = factory.Inloggen(gebruiker); 
            if ((int)Session["idIngeloggd"] > 0) //System.NullReferenceException: 'De objectverwijzing is niet op een exemplaar van een object ingesteld.'
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Registreren()
        {
            RegistrerenViewModel viewModel = new RegistrerenViewModel();
            viewModel.Naam = String.Empty;
            viewModel.Wachtwoord = String.Empty;
            viewModel.WachtwoordHerhaling = String.Empty;
            viewModel.Email = String.Empty;
            viewModel.Gewicht = String.Empty;
            viewModel.Geslacht = String.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult Registreren(RegistrerenViewModel viewModel)
        {
            double gewicht = Convert.ToDouble(viewModel.Gewicht);
            double lengte = Convert.ToDouble(viewModel.Lengte);
            IGebruiker gebruiker = new Gebruiker(viewModel.Naam, viewModel.Wachtwoord, viewModel.Email, viewModel.Geslacht, gewicht, lengte);
            Session["idIngeloggd"] = factory.Registreren(gebruiker, viewModel.WachtwoordHerhaling);
            if ((int)Session["idIngeloggd"] > 0) //System.NullReferenceException:
                                                 //'De objectverwijzing is niet op een exemplaar van een object ingesteld.'
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Uitloggen()
        {
            Session["idIngeloggd"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}