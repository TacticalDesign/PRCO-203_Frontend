namespace Backend
{
    using Newtonsoft.Json;
    using RestSharp;
    using System.Threading.Tasks;
    using UnityEngine;

    public class YoungPerson
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("frozen")]
        public bool IsFrozen { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("balance")]
        public int Balance { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("skills")]
        public string[] Skills { get; set; }

        [JsonProperty("interests")]
        public string[] Interests { get; set; }

        [JsonProperty("currentChallenges")]
        public Challenge[] CurrentChallenges { get; set; }

        [JsonProperty("archivedChallenges")]
        public Challenge[] ArchivedChallenges { get; set; }

        [JsonProperty("feedbacks")]
        public Feedback[] Feedbacks { get; set; }

        public static YoungPerson FromJson(string json)
        {
            return JsonConvert.DeserializeObject<YoungPerson>(json, Backend.Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }

        public static async Task<YoungPerson> GetSelf()
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "YoungPerson.php");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + MyPrefs.GetPref<string>(MyPrefs.Prefs.Token));
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            //Get the data async
            IRestResponse response = await Task.Run(() =>
            {
                return client.Execute(request);
            });

            Response<YoungPerson> data = Response<YoungPerson>.FromJson(response.Content);

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
