namespace Backend
{
    using System;
    using Newtonsoft.Json;

    public class Challenge
    {
        [JsonProperty("id")]
        public string ID { get; private set; }

        [JsonProperty("frozen")]
        public bool IsFrozen { get; private set; }

        [JsonProperty("challenger")]
        public Challenger Challenger { get; private set; }

        [JsonProperty("adminApproved")]
        public bool IsAdminApproved { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("image")]
        public string Image { get; private set; }

        [JsonProperty("skills")]
        public string[] Skills { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("reward")]
        public int Reward { get; private set; }

        [JsonProperty("location1")]
        public string Location1 { get; private set; }

        [JsonProperty("location2")]
        public string Location2 { get; private set; }

        [JsonProperty("location3")]
        public string Location3 { get; private set; }

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
        public int MinAttendees { get; private set; }

        [JsonProperty("maxAttendees")]
        public int MaxAttendees { get; private set; }

        [JsonProperty("attendees")]
        public YoungPerson[] Attendees { get; private set; }
    }
}
