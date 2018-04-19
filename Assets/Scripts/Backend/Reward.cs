namespace Backend
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using RestSharp;
    using System.Threading.Tasks;
    using UnityEngine;

    public class Reward
    {
        // JSON Properties
        // ===============

        [JsonProperty("id")]
        public string ID { get; private set; }

        [JsonProperty("frozen")]
        public bool IsFrozen { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("image")]
        public string Image { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("cost")]
        public int Cost { get; private set; }

        // Casts
        // =====

        public static explicit operator Reward(string id)
        {
            return new Reward
            {
                ID = id
            };
        }

        // JSON Methods
        // ============

        public static Reward FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Reward>(json, Backend.Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }

        // Commands
        // ========

        public async Task<bool> Edit(string JWT, string name = "", string description = "", int? cost = null)
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Reward.php");
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + JWT);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("id", ID);

            if (name != "")
                request.AddParameter("name", name);
            if (description != "")
                request.AddParameter("description", description);
            if (cost != null)
                request.AddParameter("cost", cost);

            //Get the data async
            IRestResponse response = await Task.Run(() =>
            {
                return client.Execute(request);
            });
            Response<Reward> data = Response<Reward>.FromJson(response.Content);

            //Log any errors
            for (int i = 0; i < data.Errors.Length; i++)
                Debug.LogError(data.Errors[i]);

            //Update and return if successful
            if (data.Result.Length == 1)
            {
                string result = JsonConvert.SerializeObject(data.Result[0]);
                JsonConvert.PopulateObject(result, this);
                return true;
            }
            return false;
        }

        public async Task<bool> ToggleFreeze(string JWT, bool isFrozen)
        {
            //Set up the request
            var client = new RestClient(API.BaseURL + "Reward.php");
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Authorization", "Bearer " + JWT);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("id", ID);
            request.AddParameter("action", isFrozen ? "freeze" : "defrost");

            //Get the data async
            IRestResponse response = await Task.Run(() =>
            {
                return client.Execute(request);
            });
            Response<Reward> data = Response<Reward>.FromJson(response.Content);

            //Log any errors
            for (int i = 0; i < data.Errors.Length; i++)
                Debug.LogError(data.Errors[i]);

            //Update and return if successful
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
