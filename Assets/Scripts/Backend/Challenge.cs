namespace Backend
{
    using System;
    using Newtonsoft.Json;

    public class Challenge
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("frozen")]
        public bool IsFrozen { get; set; }

        [JsonProperty("challenger")]
        public Challenger Challenger { get; set; }

        [JsonProperty("adminApproved")]
        public bool IsAdminApproved { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("skills")]
        public string[] Skills { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("reward")]
        public int Reward { get; set; }

        [JsonProperty("location1")]
        public string Location1 { get; set; }

        [JsonProperty("location2")]
        public string Location2 { get; set; }

        [JsonProperty("location3")]
        public string Location3 { get; set; }

        [JsonProperty("closingTime")]
        private long UnixClosingTime { get; set; }

        [JsonIgnore]
        public DateTime ClosingTime
        {
            get
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                    .AddSeconds(UnixClosingTime).ToLocalTime();
            }
            set
            {
                UnixClosingTime = (long) value.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local))
                    .TotalSeconds;
            }
        }

        [JsonProperty("minAttendees")]
        public int MinAttendees { get; set; }

        [JsonProperty("maxAttendees")]
        public int MaxAttendees { get; set; }

        [JsonProperty("attendees")]
        public YoungPerson[] Attendees { get; set; }
    }
}
