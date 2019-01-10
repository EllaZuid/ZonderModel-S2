using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hardlopen.viewModels;

namespace Hardlopen.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.Link = String.Empty;
            return View();
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel viewModel)
        {
            viewModel.Link = Session["SpotifyLink"].ToString();
            return View();
        }
    }
}