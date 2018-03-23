namespace Backend
{
    using Newtonsoft.Json;

    public partial class Feedback
    {
        [JsonProperty("challenge")]
        public string Challenge { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("feedback")]
        public string Comment { get; set; }

        public static Feedback FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Feedback>(json, Backend.Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }
    }
}
