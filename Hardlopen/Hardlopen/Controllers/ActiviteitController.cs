using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ChartJSCore.Models;
using Hardlopen.viewModels;
using Factory;
using Factory2;
using Interface_UI_Logic;
using Logic;

namespace Hardlopen.Controllers
{
    public class ActiviteitController : Controller
    {
        StartupFactory factory = new StartupFactory();
        private readonly Activiteit _activiteit = new Activiteit(new MemoryFactory());
        private readonly Chart _chart = new Chart();
        private readonly Data _data = new Data();

        // GET: Loopmoment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GegevensInvullen()
        {
            InvullenViewModel viewModel = new InvullenViewModel();
            viewModel.Tijd = string.Empty;
            viewModel.Datum = string.Empty;
            viewModel.Afstand = string.Empty;
            viewModel.GemiddeldeSnelheid = string.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult GegevensInvullen(InvullenViewModel viewModel)
        {
            int tijd = Convert.ToInt32(viewModel.Tijd);
            DateTime datum = Convert.ToDateTime(viewModel.Datum);
            int afstand = Convert.ToInt32(viewModel.Afstand);
            IActiviteit activiteit = new Activiteit(tijd, afstand, datum);
            factory.GegevensInvullen(activiteit, (int)Session["idIngeloggd"], datum);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Overzicht()
        {
            List<string> labels = new List<string>();
            BarDataset dataBarAfstand = MaakBarAfstand();
            _chart.Type = "bar";
            _data.Labels = null;
            _data.Datasets = new List<Dataset>();
            _data.Datasets.Add(MaakLineGemiddeldeSnelheid());
            _data.Datasets.Add(dataBarAfstand);
            _data.Datasets.Add(MaakBarTijd());
            for (int i = 1; i < dataBarAfstand.Data.Count + 1; i++)
            {
                labels.Add(i.ToString());
            }
            _data.Labels = labels;
            _chart.Data = _data;
            _chart.Options.Scales = new Scales()
            {
                YAxes = new List<Scale>()
                {
                    MaakScaleA(),
                    MaakScaleB()
                }
            };
            ViewData["chart"] = _chart;
            return View();
        }

        public ActionResult Vergelijken()
        {
            return View();
        }

        private BarDataset MaakBarAfstand()
        {
            List<double> data = _activiteit.ToonOverzichtAfstandBar((int) Session["idIngeloggd"]);
            List<string> kleur = new List<string>();
            foreach (double d in data)
            {
                kleur.Add("rgb(150, 0, 150)");
            }
            BarDataset datasetbarAfstand = new BarDataset()
            {
                Label = "Afstand",
                YAxisID = "A",
                BackgroundColor = kleur,
                Data = data
            };
            return datasetbarAfstand;
        }

        private BarDataset MaakBarTijd()
        {
            List<double> data = _activiteit.ToonOverzichtTijdBar((int) Session["idIngeloggd"]);
            List<string> kleur = new List<string>();
            foreach (double d in data)
            {
                kleur.Add("rgb(150, 0, 200)");
            }
            BarDataset datasetbarTijd = new BarDataset()
            {
                Label = "Tijd",
                YAxisID = "B",
                BackgroundColor = kleur,
                Data = data
            };
            return datasetbarTijd;
        }

        private LineDataset MaakLineGemiddeldeSnelheid()
        {
            LineDataset datasetline = new LineDataset()
            {
                Label = "Gemiddelde snelheid",
                BorderColor = "rgb(255, 145, 255)",
                YAxisID = "A",
                BorderWidth = 4,
                BackgroundColor = "rgba(255, 145, 255, 1.0)",
                Data = _activiteit.ToonOverzichtLine((int)Session["idIngeloggd"]),
                Fill = "false",
            };
            return datasetline;
        }

        private CartesianScale MaakScaleA()
        {
            return new CartesianScale()
            {
                Id = "A",
                Type = "linear",
                Position = "left",
                Ticks = new CartesianLinearTick()
                {
                    Min = 0,
                    Max = MaakBarAfstand().Data.Max() + 1
                }
            }; //System.InvalidOperationException: 'Reeks bevat geen elementen'
        }

        private CartesianScale MaakScaleB()
        {
            return new CartesianScale()
            {
                Id = "B",
                Type = "linear",
                Position = "right",
                Ticks = new CartesianLinearTick()
                {
                    Min = 0,
                    Max = MaakBarTijd().Data.Max() + 10
                }
            };
        }
    }
}