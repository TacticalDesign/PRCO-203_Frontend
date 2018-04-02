namespace Backend
{
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Threading.Tasks;
    using UnityEngine;

    public partial class Challenger
    {
        // JSON Properties
        // ===============

        [JsonProperty("id")]
        public string ID { get; private set; }

        [JsonProperty("frozen")]
        public bool IsFrozen { get; private set; }

        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("image")]
        public string Image { get; private set; }

        [JsonProperty("cover")]
        public string Cover { get; private set; }

        [JsonProperty("colour")]
        private string HexColour { get; set; }

        [JsonIgnore]
        public Color Colour
        {
            get
            {
                Color colour;
                ColorUtility.TryParseHtmlString(HexColour, out colour);
                return colour;
            }
            private set
            {
                HexColour = ColorUtility.ToHtmlStringRGB(value);
            }
        }

        [JsonProperty("contactEmail")]
        public string ContactEmail { get; private set; }

        [JsonProperty("contactPhone")]
        public string ContactPhone { get; private set; }

        [JsonProperty("about")]
        public string About { get; private set; }

        [JsonProperty("currentChallenges")]
        public Challenge[] CurrentChallenges { get; private set; }

        [JsonProperty("archivedChallenges")]
        public Challenge[] ArchivedChallenges { get; private set; }

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

        public static async Task<Challenger> Login(string email, string password, string tempPassword = "")
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
            var client = new RestClient(API.BaseURL + "Challenger.php");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
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
                string result = JsonConvert.SerializeObject(data.Result[0]);
                JsonConvert.PopulateObject(result, this);
                return true;
            }
            return false;
        }

        public async Task<bool> EditSelf(string email = "", string password = "", string name = "", Color? colour = null,
                                        string contactEmail = "", string contactPhone = "", string about = "")
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Challenger.php");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            if (email != "")
                request.AddParameter("email", email);
            if (password != "")
                request.AddParameter("password", password);
            if (name != "")
                request.AddParameter("name", name);
            if (colour.HasValue)
                request.AddParameter("color", ColorUtility.ToHtmlStringRGB(colour.Value));
            if (contactEmail != "")
                request.AddParameter("contactEmail", contactEmail);
            if (contactPhone != "")
                request.AddParameter("contactPhone", contactPhone);
            if (about != "")
                request.AddParameter("about", about);

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
                string result = JsonConvert.SerializeObject(data.Result[0]);
                JsonConvert.PopulateObject(result, this);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteSelf()
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Challenger.php");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
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
                string result = JsonConvert.SerializeObject(data.Result[0]);
                JsonConvert.PopulateObject(result, this);
                return true;
            }
            return false;
        }

        public async Task<Challenge> CreateChallenge(string name, string[] skills, string description, int reward,
                                                string location1, string location2, string location3, DateTime closingTime,
                                                int minAttendees, int maxAttendees)
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Challenge.php");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("name", name);
            for (int i = 0; i < skills.Length; i++)
                request.AddParameter("skills[]", skills[i]);
            request.AddParameter("description", description);
            request.AddParameter("reward", reward);
            request.AddParameter("location1", location1);
            request.AddParameter("location2", location2);
            request.AddParameter("location3", location3);
            request.AddParameter("closingTime", (long)closingTime.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local))
                        .TotalSeconds);
            request.AddParameter("minAttendees", minAttendees);
            request.AddParameter("maxAttendees", maxAttendees);

            //Get the data async
            IRestResponse response = await Task.Run(() =>
            {
                return client.Execute(request);
            });
            Response<Challenge> data = Response<Challenge>.FromJson(response.Content);

            //Log any errors
            for (int i = 0; i < data.Errors.Length; i++)
                Debug.LogError(data.Errors[i]);

            //Return the new Challenge
            if (data.Result.Length == 1)
            {
                return data.Result[0];
            }

            return null;
        }

    }
}
