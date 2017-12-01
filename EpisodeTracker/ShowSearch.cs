// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = ShowSearch.FromJson(jsonString);
//
namespace ShowSearchJson
{
    using System;
    using System.Net;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using System.ComponentModel;
    using System.Text;

    public partial class ShowSearch
    {
        [JsonProperty("score")]
        [DisplayName("Score")]
        public double Score { get; set; }

        [JsonProperty("show")]
        [DisplayName("Score")]
        public Show Show { get; set; }
    }

    public partial class Show
    {
        [JsonProperty("externals")]
        [DisplayName("Externals")]
        public Externals Externals { get; set; }

        [JsonProperty("genres")]
        [DisplayName("Genres")]
        public List<string> Genres { get; set; }

        [DisplayName("Genres List")]
        public string Genres_short
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (string s in Genres)
                {
                    stringBuilder.Append(s + ", ");
                }
                if (stringBuilder.Length > 1)
                {
                    stringBuilder.Length -= 2;
                }
                return stringBuilder.ToString();
            }
        }

        [JsonProperty("id")]
        [DisplayName("Id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        [DisplayName("Image")]
        public Image Image { get; set; }

        [JsonProperty("language")]
        [DisplayName("Language")]
        public string Language { get; set; }

        [JsonProperty("_links")]
        [DisplayName("Links")]
        public Links Links { get; set; }

        [JsonProperty("name")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [JsonProperty("network")]
        [DisplayName("Network")]
        public Network Network { get; set; }

        [JsonProperty("officialSite")]
        [DisplayName("Official Site")]
        public string OfficialSite { get; set; }

        [JsonProperty("premiered")]
        [DisplayName("Premiered")]
        public string Premiered { get; set; }

        [JsonProperty("rating")]
        [DisplayName("Rating")]
        public Rating Rating { get; set; }

        [JsonProperty("runtime")]
        [DisplayName("Runtime")]
        public long? Runtime { get; set; }

        [JsonProperty("schedule")]
        [DisplayName("Schedule")]
        public Schedule Schedule { get; set; }

        [JsonProperty("status")]
        [DisplayName("Status")]
        public string Status { get; set; }

        [JsonProperty("summary")]
        [DisplayName("Summary")]
        public string Summary { get; set; }

        [JsonProperty("type")]
        [DisplayName("Type")]
        public string Type { get; set; }

        [JsonProperty("updated")]
        [DisplayName("Updated")]
        public long Updated { get; set; }

        [JsonProperty("url")]
        [DisplayName("Url")]
        public string Url { get; set; }

        [JsonProperty("webChannel")]
        [DisplayName("Web Channel")]
        public WebChannel WebChannel { get; set; }

        [JsonProperty("weight")]
        [DisplayName("Weight")]
        public long Weight { get; set; }
    }

    public partial class WebChannel
    {
        [JsonProperty("country")]
        [DisplayName("Country")]
        public object Country { get; set; }

        [JsonProperty("id")]
        [DisplayName("Id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        [DisplayName("Name")]
        public string Name { get; set; }
    }

    public partial class Schedule
    {
        [JsonProperty("days")]
        [DisplayName("Days")]
        public List<string> Days { get; set; }

        [DisplayName("List Of Days")]
        public string Days_short
        {
            get
            {
                return String.Join(String.Empty, Days);
            }
        } 

        [JsonProperty("time")]
        [DisplayName("Time")]
        public string Time { get; set; }
    }

    public partial class Rating
    {
        [JsonProperty("average")]
        [DisplayName("Average")]
        public double? Average { get; set; }
    }

    public partial class Network
    {
        [JsonProperty("country")]
        [DisplayName("Country")]
        public Country Country { get; set; }

        [JsonProperty("id")]
        [DisplayName("Id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        [DisplayName("Name")]
        public string Name { get; set; }
    }

    public partial class Country
    {
        [JsonProperty("code")]
        [DisplayName("Code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [JsonProperty("timezone")]
        [DisplayName("Timezone")]
        public string Timezone { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("nextepisode")]
        [DisplayName("Next Episode")]
        public Nextepisode Nextepisode { get; set; }

        [JsonProperty("previousepisode")]
        [DisplayName("Previous Episode")]
        public Nextepisode Previousepisode { get; set; }

        [JsonProperty("self")]
        [DisplayName("Self")]
        public Nextepisode Self { get; set; }
    }

    public partial class Nextepisode
    {
        [JsonProperty("href")]
        [DisplayName("Href")]
        public string Href { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("medium")]
        [DisplayName("Medium")]
        public string Medium { get; set; }

        [JsonProperty("original")]
        [DisplayName("Original")]
        public string Original { get; set; }
    }

    public partial class Externals
    {
        [JsonProperty("imdb")]
        [DisplayName("Imdb")]
        public string Imdb { get; set; }

        [JsonProperty("thetvdb")]
        [DisplayName("Thetvdb")]
        public long? Thetvdb { get; set; }

        [JsonProperty("tvrage")]
        [DisplayName("Tvrage")]
        public long? Tvrage { get; set; }
    }

    public partial class ShowSearch
    {
        public static List<ShowSearch> FromJson(string json) => JsonConvert.DeserializeObject<List<ShowSearch>>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<ShowSearch> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
