namespace Backend
{
    using Newtonsoft.Json;
    using RestSharp;
    using System.Threading.Tasks;
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

        public static async Task<Challenger> GetSelf()
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Challenger.php");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + MyPrefs.GetPref<string>(MyPrefs.Prefs.Token));
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            //Get the data async
            IRestResponse response = await Task.Run(() =>
            {
                return client.Execute(request);
            });

            Response<Challenger> data = Response<Challenger>.FromJson(response.Content);

            //Log any errors
            for (int i = 0; i < data.Errors.Length; i++)
                Debug.LogError(data.Errors[i]);

            if (data.Result.Length == 1)
            {
                return data.Result[1];
            }
            return null;
        }
    }
}
