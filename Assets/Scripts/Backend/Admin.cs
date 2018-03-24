namespace Backend
{
    using Newtonsoft.Json;
    using RestSharp;
    using System.Threading.Tasks;
    using UnityEngine;

    public class Admin
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

        [JsonProperty("image")]
        public string Image { get; set; }

        public static Admin FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Admin>(json, Backend.Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }

        public static async Task<Admin> GetSelf()
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Admin.php");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + MyPrefs.GetPref<string>(MyPrefs.Prefs.RawToken));
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
                return data.Result[0];
            }
            return null;
        }

        public static async Task<Admin> EditSelf(string email = "", string password = "", string firstName = "", string surname = "")
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Admin.php");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + MyPrefs.GetPref<string>(MyPrefs.Prefs.RawToken));
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
                return data.Result[0];
            }
            return null;
        }
    }
}
