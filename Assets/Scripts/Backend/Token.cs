namespace Backend
{
    using Newtonsoft.Json;

    public class Token
    {
        [JsonProperty("token")]
        public string Value { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        public static Token FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Token>(json, Backend.Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }
    }
}
