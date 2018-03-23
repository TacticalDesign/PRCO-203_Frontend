using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Backend
{
    public static class API
    {
        public static async Task<Token> GetToken(string email, string password, string tempPassword = "")
        {
            var client = new RestClient("http://localhost/DP/api/Login.php");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Postman-Token", "6447e83a-a5f3-49be-8197-b7f1e36e7cbc");
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("email", email);
            request.AddParameter("password", password);
            if (tempPassword != "")
                request.AddParameter("tempPassword", tempPassword);
            IRestResponse response = await Task.Run(() =>
            {
                return client.Execute(request);
            });
            return Token.FromJson(response.Content);
        }
    }
}
