using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpisodeTracker
{
    public class ShowJson
    {
        [JsonProperty("showid")]
        public int Showid { get; set; }
    }
}