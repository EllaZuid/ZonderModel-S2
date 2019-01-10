using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hardlopen.viewModels;

namespace Hardlopen.Controllers
{
    public class SpotifyController : Controller
    {
        // GET: Spotify
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Spotify()
        {
            SpotifyViewModel viewModel = new SpotifyViewModel();
            viewModel.Link = String.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult Spotify(SpotifyViewModel viewModel)
        {
            string link = viewModel.Link.Replace("open.spotify.com", "open.spotify.com/embed");
            Session["SpotifyLink"] = link;
            if ((string)Session["SpotifyLink"] != "")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}