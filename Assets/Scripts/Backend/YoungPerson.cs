namespace Backend
{
    using Newtonsoft.Json;

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
    }
}
