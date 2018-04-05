namespace Backend
{
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Threading.Tasks;
    using UnityEngine;

    public class YoungPerson
    {
        // JSON Properties
        // ===============

        [JsonProperty("id")]
        public string ID { get; private set; }

        [JsonProperty("frozen")]
        public bool IsFrozen { get; private set; }

        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("firstName")]
        public string FirstName { get; private set; }

        [JsonProperty("surname")]
        public string Surname { get; private set; }

        [JsonProperty("balance")]
        public int Balance { get; private set; }

        [JsonProperty("image")]
        public string Image { get; private set; }

        [JsonProperty("skills")]
        public string[] Skills { get; private set; }

        [JsonProperty("interests")]
        public string[] Interests { get; private set; }

        [JsonProperty("currentChallenges")]
        public Challenger.Challenge[] CurrentChallenges { get; private set; }

        [JsonProperty("archivedChallenges")]
        public Challenger.Challenge[] ArchivedChallenges { get; private set; }

        [JsonProperty("feedbacks")]
        public Feedback[] Feedbacks { get; private set; }

        // Other Properties
        // ================

        [JsonIgnore]
        public string RawToken { get; private set; }
        [JsonIgnore]
        public Token Token { get; private set; }

        // Casts
        // =====

        public static explicit operator YoungPerson(string id)
        {
            return new YoungPerson
            {
                ID = id
            };
        }

        // JSON Methods
        // ============

        public static YoungPerson FromJson(string json)
        {
            return JsonConvert.DeserializeObject<YoungPerson>(json, Backend.Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }

        // Commands
        // ========

        public static async Task<YoungPerson> Login(string email, string password, string tempPassword = "")
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

            YoungPerson newYoungPerson = new YoungPerson
            {
                RawToken = token.Value,
                Token = Token.FromJWT(token.Value)
            };
            await newYoungPerson.Update();

            return newYoungPerson;
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

        public async Task<bool> EditSelf(string email = "", string password = "", string firstName = "", string surname = "", string[] skills = null, string[] interests = null)
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "YoungPerson.php");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            if (email != "")
                request.AddParameter("email", email);
            if (password != "")
                request.AddParameter("password", password);
            if (firstName != "")
                request.AddParameter("firstName", firstName);
            if (surname != "")
                request.AddParameter("surname", surname);
            if (skills != null)
                for (int i = 0; i < skills.Length; i++)
                    request.AddParameter("skills[]", skills[i]);
            if (interests != null)
                for (int i = 0; i < interests.Length; i++)
                    request.AddParameter("interests[]", interests[i]);

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

        public async Task<bool> AttendChallenge(string challenge, bool isAttending)
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "YoungPerson.php");
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            if (challenge != "")
                request.AddParameter("challenge", challenge);
            request.AddParameter("attending", isAttending);

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

        public async Task<bool> DeleteSelf()
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "YoungPerson.php");
            var request = new RestRequest(Method.DELETE);
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
