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
            try
            {
                return JsonConvert.DeserializeObject<Response<T>>(json, Backend.Converter.Settings);
            }
            catch
            {
#if UNITY_EDITOR
                UnityEngine.Debug.LogError("Failed to convert the following into type " + typeof(T).Name + ":\n" + json);
#else
                System.Console.WriteLine("Failed to convert the following into type " + typeof(T).Name + ":\n" + json);
#endif
                return null;
            }
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }
    }
}
