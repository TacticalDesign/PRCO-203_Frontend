namespace Backend
{
    using Newtonsoft.Json;
    using RestSharp;
    using System.Threading.Tasks;
    using UnityEngine;

    public class Challenger
    {
        // JSON Properties
        // ===============

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

        // Other Properties
        // ================

        [JsonIgnore]
        public string RawToken { get; private set; }
        [JsonIgnore]
        public Token Token { get; private set; }

        // JSON Methods
        // ============

        public static Challenger FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Challenger>(json, Backend.Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }

        // Commands
        // ========

        public async Task<Challenger> Login(string email, string password, string tempPassword = "")
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Login.php");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("email", email);
            request.AddParameter("password", password);
            if (tempPassword != "")
                request.AddParameter("tempPassword", tempPassword);

            //Get the data async
            IRestResponse response = await Task.Run(() =>
            {
                return client.Execute(request);
            });

            TokenRequest token = TokenRequest.FromJson(response.Content);

            //Log any errors
            for (int i = 0; i < token.Errors.Length; i++)
                Debug.LogError(token.Errors[i]);

            Challenger newChallenger = new Challenger
            {
                RawToken = token.Value,
                Token = Token.FromJWT(token.Value)
            };
            await newChallenger.Update();

            return newChallenger;
        }

        public async Task<bool> Update()
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "YoungPerson.php");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
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
                string result = JsonConvert.SerializeObject(data.Result[0]);
                JsonConvert.PopulateObject(result, this);
                return true;
            }
            return false;
        }
    }
}
