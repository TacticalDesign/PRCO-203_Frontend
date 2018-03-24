namespace Backend
{
    using Newtonsoft.Json;

    public partial class Response<T>
    {
        [JsonProperty("result")]
        public T[] Result { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        public static Response<T> FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Response<T>>(json, Backend.Converter.Settings);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }
    }
}
