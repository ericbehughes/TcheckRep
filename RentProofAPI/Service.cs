using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RentProof.API.Models;

namespace RentProof.API
{
    public static class Service
    {
        public static async Task<Token> Login(LoginBindingModel model)
        {
            const string url = "http://rentproof.io/token";

            // build request
            var serialized = JsonConvert.SerializeObject(model);
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(serialized);
            var content = new FormUrlEncodedContent(data);

            using (var client = new HttpClient())
            {
                // wait for response
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                // parse response
                var token = JsonConvert.DeserializeObject<Token>(result);
                return token;
            }
        }

        public static async Task<bool> Register(RegisterBindingModel model)
        {
            const string url = "http://rentproof.io/api/Account/Register";

            // build request
            var serialized = JsonConvert.SerializeObject(model);
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(serialized);
            var content = new FormUrlEncodedContent(data);

            using (var client = new HttpClient())
            {
                // wait for response
                var response = await client.PostAsync(url, content);
                await response.Content.ReadAsStringAsync();

                return true;
            }
        }
    }
}