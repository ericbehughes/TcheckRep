using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RentProof.API.Models;

namespace RentProof.API
{
    public static class Wrapper
    {
        public static async Task<Token> GetAuthenticationToken(string email, string password)
        {
            using (var client = new HttpClient())
            {
                // build request
                const string url = "http://rentproof.io/token";
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", email),
                    new KeyValuePair<string, string>("password", password),
                });

                // wait for response
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                // parse response
                var data = JsonConvert.DeserializeObject<Token>(result);
                return data;
            }
        }
    }
}