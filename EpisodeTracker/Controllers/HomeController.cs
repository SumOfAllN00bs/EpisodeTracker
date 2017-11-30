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
            List<ShowSearch> data;
            using (var webClient = new System.Net.WebClient() { Encoding = System.Text.Encoding.UTF8})//UTF8 used so that I can properly handle certain symbols that are used in the information returned in the json object
            {
                var json = webClient.DownloadString("http://api.tvmaze.com/search/shows?q=" + HttpUtility.UrlEncode(SearchByShow));
                data = ShowSearch.FromJson(json);
            }
            return View(data);
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