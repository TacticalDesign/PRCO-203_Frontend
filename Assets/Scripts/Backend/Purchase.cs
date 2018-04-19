namespace Backend
{
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Threading.Tasks;
    using UnityEngine;

    public class Purchase
    {
        // JSON Properties
        // ===============

        [JsonProperty("successful")]
        public bool WasSuccessful { get; private set; }

        [JsonProperty("reward")]
        public Reward Reward { get; private set; }

        [JsonProperty("youngPerson")]
        public YoungPerson YoungPerson { get; private set; }

        // JSON Methods
        // ============

        public static Purchase FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Purchase>(json, Backend.Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }
    }
}
