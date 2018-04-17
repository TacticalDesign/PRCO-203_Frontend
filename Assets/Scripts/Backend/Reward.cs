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
    }
}
