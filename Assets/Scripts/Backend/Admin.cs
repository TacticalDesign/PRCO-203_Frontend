namespace Backend
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RestSharp;
    using System.Threading.Tasks;
    using UnityEngine;

    public class Admin
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

        [JsonProperty("image")]
        public string Image { get; private set; }

        // Other Properties
        // ================

        [JsonIgnore]
        public string RawToken { get; private set; }
        [JsonIgnore]
        public Token Token { get; private set; }

        // Casts
        // =====

        public static explicit operator Admin(string id)
        {
            return new Admin
            {
                ID = id
            };
        }

        // JSON Methods
        // ============

        public static Admin FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Admin>(json, Backend.Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }

        // Commands
        // ========

        public static async Task<Admin> Login(string email, string password, string tempPassword = "")
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

            Admin newAdmin = new Admin
            {
                RawToken = token.Value,
                Token = Token.FromJWT(token.Value)
            };
            await newAdmin.Update();

            return newAdmin;
        }

        public async Task<bool> Update()
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Admin.php");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            //Get the data async
            IRestResponse response = await Task.Run(() =>
            {
                return client.Execute(request);
            });
            Response<Admin> data = Response<Admin>.FromJson(response.Content);

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

        public async Task<bool> EditSelf(string email = "", string password = "", string firstName = "", string surname = "")
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Admin.php");
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

            //Get the data async
            IRestResponse response = await Task.Run(() =>
            {
                return client.Execute(request);
            });
            Response<Admin> data = Response<Admin>.FromJson(response.Content);

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
            var client = new RestClient(API.BaseURL + "Admin.php");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            //Get the data async
            IRestResponse response = await Task.Run(() =>
            {
                return client.Execute(request);
            });
            Response<Admin> data = Response<Admin>.FromJson(response.Content);

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

        public async Task<YoungPerson> CreateYoungPerson(string email, string firstName)
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Admin.php");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("type", "young person");
            request.AddParameter("email", email);
            request.AddParameter("firstName", firstName);

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
                return data.Result[0];
            }
            return null;
        }

        public async Task<YoungPerson> SetYoungPersonFreeze(string id, bool isFrozen)
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Admin.php");
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("id", id);
            request.AddParameter("action", isFrozen ? "freeze" : "defrost");

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
                return data.Result[0];
            }
            return null;
        }

        public async Task<Challenger> CreateChallenger(string email, string name)
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Admin.php");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("type", "challenger");
            request.AddParameter("email", email);
            request.AddParameter("name", name);

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
                return data.Result[0];
            }
            return null;
        }

        public async Task<Challenger> SetChallengerFreeze(string id, bool isFrozen)
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Admin.php");
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + RawToken);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("id", id);
            request.AddParameter("action", isFrozen ? "freeze" : "defrost");

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
                return data.Result[0];
            }
            return null;
        }
    }
}
