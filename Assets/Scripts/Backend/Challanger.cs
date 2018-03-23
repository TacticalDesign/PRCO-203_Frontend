namespace Backend
{
    using Newtonsoft.Json;
    using UnityEngine;

    public class Challenger
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("frozen")]
        public bool IsFrozen { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("colour")]
        private string HexColour { get; set; }
        public Color Colour
        {
            get
            {
                Color colour;
                ColorUtility.TryParseHtmlString(HexColour, out colour);
                return colour;
            }
            set
            {
                HexColour = ColorUtility.ToHtmlStringRGB(value);
            }
        }

        [JsonProperty("contactEmail")]
        public string ContactEmail { get; set; }

        [JsonProperty("contactPhone")]
        public string ContactPhone { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("currentChallenges")]
        public Challenge[] CurrentChallenges { get; set; }

        [JsonProperty("archivedChallenges")]
        public Challenge[] ArchivedChallenges { get; set; }

        public static Challenger FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Challenger>(json, Backend.Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }
    }
}
