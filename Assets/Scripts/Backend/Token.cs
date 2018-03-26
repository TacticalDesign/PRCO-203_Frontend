namespace Backend
{
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Text;

    public class Token
    {
        public Header Head { get; set; }
        public Payload Pay { get; set; }
        public Signature Sig { get; set; }

        public static Token FromJWT(string jwt)
        {
            string[] parts = jwt.Split('.');
            if (parts.Length != 3)
                return null;

            string header = PrepPart(parts[0]);
            string payload = PrepPart(parts[1]);

            return new Token
            {
                Head = JsonConvert.DeserializeObject<Header>(header),
                Pay = JsonConvert.DeserializeObject<Payload>(payload),
                Sig = new Signature(parts[2])
            };
        }
        private static string PrepPart(string part)
        {
            part = part.Replace('-', '+').Replace('_', '/');
            switch (part.Length % 4)
            {
                case 0:
                    break;
                case 2:
                    part += "==";
                    break;
                case 3:
                    part += "=";
                    break;
            }

            byte[] partAsBytes = Convert.FromBase64String(part);
            return Encoding.UTF8.GetString(partAsBytes, 0, partAsBytes.Count());
        }

        public string ToJWT()
        {
            return JsonConvert.SerializeObject(this, Backend.Converter.Settings);
        }

        public class Header
        {
            [JsonProperty("typ")]
            public string Type { get; set; }
            [JsonProperty("alg")]
            public string Algorithm { get; set; }
        }

        public class Payload
        {
            [JsonProperty("user_id")]
            public string UserID { get; set; }
            [JsonProperty("user_typ")]
            public string UserType { get; set; }
        }

        public class Signature
        {
            public Signature(string value)
            {
                Value = value;
            }
            public string Value { get; set; }
        }
    }

}
