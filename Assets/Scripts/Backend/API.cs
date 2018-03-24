using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static MyPrefs;

namespace Backend
{
    public static class API
    {
        public static string BaseURL = "http://localhost/DP/api/";
        //public static string BaseURL = "http://tobysmith.uk/DP/";

        public static async Task<TokenRequest> GetToken(string email, string password, string tempPassword = "")
        {
            //Set up the request
            var client = new RestClient(BaseURL + "Login.php");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("email", email);
            request.AddParameter("password", password);
            if (tempPassword != "")
                request.AddParameter("tempPassword", tempPassword);

            //Get the data async
            IRestResponse response = await Task.Run(() =>
            {
                return client.Execute(request);
            });

            TokenRequest returnable = TokenRequest.FromJson(response.Content);

            //Log any errors
            for (int i = 0; i < returnable.Errors.Length; i++)
                Debug.LogError(returnable.Errors[i]);

            //Save the value if it's not null
            if (returnable.Value != null)
            {
                SetPref(Prefs.RawToken, returnable.Value);

                Token token = Token.FromJWT(returnable.Value);
                SetPref(Prefs.Token, token);
            }

            return returnable;
        }
    }
}
