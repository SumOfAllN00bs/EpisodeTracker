using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ShowSearchJson;

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
            using (var webClient = new System.Net.WebClient() { Encoding = System.Text.Encoding.UTF8 })//UTF8 used so that I can properly handle certain symbols that are used in the information returned in the json object
            {
                var json = webClient.DownloadString("http://api.tvmaze.com/search/shows?q=" + HttpUtility.UrlEncode(SearchByShow));
                data = ShowSearch.FromJson(json);
            }
            return View(data);
        }

        [HttpPost]
        public ActionResult Today(string hidden_today)
        {
            ViewBag.Filter = "Today";
            List<EpisodesJson.Episodes> tmp = getEpisodesFromShowIds(hidden_today);
            List<EpisodesJson.Episodes> results = new List<EpisodesJson.Episodes>();
            foreach (EpisodesJson.Episodes ep in tmp)
            {
                DateTime EpisodeTime;
                if (DateTime.TryParse(ep.Airstamp, out EpisodeTime))
                {
                    if (EpisodeTime >= DateTime.Now && EpisodeTime < DateTime.Now.AddHours(24))
                    {
                        results.Add(ep);
                    }
                }
                else
                {
                    ViewBag.Message += "Error converting: " + ep.Airstamp + " to " + EpisodeTime;
                }
            }
            return View("Episodes", results);
        }

        [HttpPost]
        public ActionResult Episodes(string hidden_episodes)
        {
            ViewBag.Filter = "All";
            return View(getEpisodesFromShowIds(hidden_episodes));
        }

        private List<EpisodesJson.Episodes> getEpisodesFromShowIds(string showids)
        {
            List<ShowJson> ShowsList = JsonConvert.DeserializeObject<List<ShowJson>>(showids);
            List<EpisodesJson.Episodes> EpisodesList = new List<EpisodesJson.Episodes>();

            //UTF8 used so that I can properly handle certain symbols that are used in the information returned in the json object
            using (var webClient = new System.Net.WebClient() { Encoding = System.Text.Encoding.UTF8 })
            {
                foreach (ShowJson SJ in ShowsList)
                {
                    var json = webClient.DownloadString("http://api.tvmaze.com/shows/" + SJ.Showid + "/episodes");
                    EpisodesList.AddRange(EpisodesJson.Episodes.FromJson(json));
                }
            }
            return EpisodesList;
        }
    }
}