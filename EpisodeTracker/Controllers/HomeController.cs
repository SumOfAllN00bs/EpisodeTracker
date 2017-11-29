using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using QuickType;

namespace EpisodeTracker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Shows()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Shows(string SearchByShow)
        {
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("http://api.tvmaze.com/search/shows?q=" + HttpUtility.UrlEncode(SearchByShow));
                var data = ShowSearch.FromJson(json);
                ViewBag.Results = data;
            }
            return View();
        }
        public ActionResult Today()
        {
            return View();
        }
        public ActionResult Episodes()
        {
            return View();
        }
    }
}