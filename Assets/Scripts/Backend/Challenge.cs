namespace Backend
{
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Threading.Tasks;
    using UnityEngine;

    public partial class Challenger
    {
        public class Challenge
        {
            [JsonProperty("id")]
            public string ID { get; internal set; }

            [JsonProperty("frozen")]
            public bool IsFrozen { get; internal set; }

            [JsonProperty("challenger")]
            public Challenger Challenger { get; internal set; }

            [JsonProperty("adminApproved")]
            public bool IsAdminApproved { get; internal set; }

            [JsonProperty("name")]
            public string Name { get; internal set; }

            [JsonProperty("image")]
            public string Image { get; internal set; }

            [JsonProperty("skills")]
            public string[] Skills { get; internal set; }

            [JsonProperty("description")]
            public string Description { get; internal set; }

            [JsonProperty("reward")]
            public int Reward { get; internal set; }

            [JsonProperty("location1")]
            public string Location1 { get; internal set; }

            [JsonProperty("location2")]
            public string Location2 { get; internal set; }

            [JsonProperty("location3")]
            public string Location3 { get; internal set; }

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
                private set
                {
                    UnixClosingTime = (long)value.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local))
                        .TotalSeconds;
                }
            }

            [JsonProperty("minAttendees")]
            public int MinAttendees { get; internal set; }

            [JsonProperty("maxAttendees")]
            public int MaxAttendees { get; internal set; }

            [JsonProperty("attendees")]
            public YoungPerson[] Attendees { get; internal set; }

            // JSON Methods
            // ============

            public static Challenge FromJson(string json)
            {
                return JsonConvert.DeserializeObject<Challenge>(json, Backend.Converter.Settings);
            }

            public string ToJson()
            {
                return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
            }

            // Commands
            // ========

            public async Task<bool> EditChallenge(string JWT, string name = "", string[] skills = null, string description = "", int? reward = null,
                                                    string location1 = "", string location2 = "", string location3 = "", DateTime? closingTime = null,
                                                    int? minAttendees = null, int? maxAttendees = null)
            {
                //Set up the request
                var client = new RestClient(API.BaseURL + "Challenge.php");
                var request = new RestRequest(Method.PUT);
                request.AddHeader("Cache-Control", "no-cache");
                request.AddHeader("Authorization", "Bearer " + JWT);
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

                request.AddParameter("id", ID);

                if (name != "")
                    request.AddParameter("name", name);
                if (skills != null)
                    for (int i = 0; i < skills.Length; i++)
                        request.AddParameter("skills[]", skills[i]);
                if (description != "")
                    request.AddParameter("description", description);
                if (reward != null)
                    request.AddParameter("reward", reward);
                if (location1 != "")
                    request.AddParameter("location1", location1);
                if (location2 != "")
                    request.AddParameter("location2", location2);
                if (location3 != "")
                    request.AddParameter("location3", location3);
                if (minAttendees != null)
                    request.AddParameter("minAttendees", minAttendees);
                if (maxAttendees != null)
                    request.AddParameter("maxAttendees", maxAttendees);

                //Get the data async
                IRestResponse response = await Task.Run(() =>
                {
                    return client.Execute(request);
                });
                Response<Challenge> data = Response<Challenge>.FromJson(response.Content);

                //Log any errors
                for (int i = 0; i < data.Errors.Length; i++)
                    Debug.LogError(data.Errors[i]);


                //Update and return the Challenge
                if (data.Result.Length == 1)
                {
                    string result = JsonConvert.SerializeObject(data.Result[0]);
                    JsonConvert.PopulateObject(result, this);
                    return true;
                }
                return false;
            }
        }
    }
}
