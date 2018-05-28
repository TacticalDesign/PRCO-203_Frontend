namespace Backend
{
    using Newtonsoft.Json;

    public class TokenRequest
    {
        [JsonProperty("token")]
        public string Value { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        public static TokenRequest FromJson(string json)
        {
            return JsonConvert.DeserializeObject<TokenRequest>(json, Backend.Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }
    }
}

