// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using EpisodesJson;
//
//    var data = Episodes.FromJson(jsonString);
//
namespace EpisodesJson
{
    using System;
    using System.Net;
    using System.Collections.Generic;
    using System.ComponentModel;

    using Newtonsoft.Json;

    public partial class Episodes
    {
        [JsonProperty("airdate")]
        [DisplayName("Air date")]
        public string Airdate { get; set; }

        [JsonProperty("airstamp")]
        [DisplayName("Air stamp")]
        public string Airstamp { get; set; }

        [JsonProperty("airtime")]
        [DisplayName("Air time")]
        public Airtime Airtime { get; set; }

        [JsonProperty("id")]
        [DisplayName("Episode Id")]
        public long Id { get; set; }

        [JsonProperty("image")]
        [DisplayName("Image")]
        public Image Image { get; set; }

        [JsonProperty("_links")]
        [DisplayName("Links")]
        public Links Links { get; set; }

        [JsonProperty("name")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [JsonProperty("number")]
        [DisplayName("Number")]
        public long Number { get; set; }

        [JsonProperty("runtime")]
        [DisplayName("Runtime")]
        public long Runtime { get; set; }

        [JsonProperty("season")]
        [DisplayName("Season")]
        public long Season { get; set; }

        [JsonProperty("summary")]
        [DisplayName("Summary")]
        public string Summary { get; set; }

        [JsonProperty("url")]
        [DisplayName("Url")]
        public string Url { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("self")]
        [DisplayName("Self")]
        public Self Self { get; set; }
    }

    public partial class Self
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

    public enum Airtime
    {
        The0000, The0100, The0200, The0300, The0400, The0500, The0600, The0700, The0800,
        The0900, The1000, The1100, The1200, The1300, The1400, The1500, The1600, The1700,
        The1800, The1900, The2000, The2100, The2200, The2300,
    };

    public partial class Episodes
    {
        public static List<Episodes> FromJson(string json) => JsonConvert.DeserializeObject<List<Episodes>>(json, Converter.Settings);
    }

    static class AirtimeExtensions
    {
        public static Airtime ReadJson(JsonReader reader, JsonSerializer serializer)
        {
            switch (serializer.Deserialize<string>(reader))
            {
                case "00:00": return Airtime.The0000;
                case "01:00": return Airtime.The0100;
                case "02:00": return Airtime.The0200;
                case "03:00": return Airtime.The0300;
                case "04:00": return Airtime.The0400;
                case "05:00": return Airtime.The0500;
                case "06:00": return Airtime.The0600;
                case "07:00": return Airtime.The0700;
                case "08:00": return Airtime.The0800;
                case "09:00": return Airtime.The0900;
                case "10:00": return Airtime.The1000;
                case "11:00": return Airtime.The1100;
                case "12:00": return Airtime.The1200;
                case "13:00": return Airtime.The1300;
                case "14:00": return Airtime.The1400;
                case "15:00": return Airtime.The1500;
                case "16:00": return Airtime.The1600;
                case "17:00": return Airtime.The1700;
                case "18:00": return Airtime.The1800;
                case "19:00": return Airtime.The1900;
                case "20:00": return Airtime.The2000;
                case "21:00": return Airtime.The2100;
                case "22:00": return Airtime.The2200;
                case "23:00": return Airtime.The2300;
            }
            throw new Exception("Unknown enum case");
        }

        public static void WriteJson(this Airtime value, JsonWriter writer, JsonSerializer serializer)
        {
            switch (value)
            {
                case Airtime.The2100: serializer.Serialize(writer, "21:00"); break;
                case Airtime.The2200: serializer.Serialize(writer, "22:00"); break;
            }
        }
    }

    public static class Serialize
    {
        public static string ToJson(this Episodes[] self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Airtime) || t == typeof(Airtime?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (t == typeof(Airtime))
                return AirtimeExtensions.ReadJson(reader, serializer);
            if (t == typeof(Airtime?))
            {
                if (reader.TokenType == JsonToken.Null) return null;
                return AirtimeExtensions.ReadJson(reader, serializer);
            }
            throw new Exception("Unknown type");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = value.GetType();
            if (t == typeof(Airtime))
            {
                ((Airtime)value).WriteJson(writer, serializer);
                return;
            }
            throw new Exception("Unknown type");
        }

        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = { new Converter() },
        };
    }
}
