﻿using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UsagiConnect.Osu.API.Beatmap;
using UsagiConnect.Osu.API.Enums;
using UsagiConnect.Osu.API.User;
using UsagiConnect.WForms;

namespace UsagiConnect.Client
{
    public class OsuClient
    {
        public string Token;
        public int TokenTimeout;
        public bool IsOnline = false;
        private static readonly string TOKEN_URL = "https://osu.ppy.sh/oauth/token";
        private static readonly string OSU_ENDPOINT = "https://osu.ppy.sh/api/v2/";
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainForm));

        public OsuClient(string token, int tokenTimeout)
        {
            Token = token;
            TokenTimeout = tokenTimeout;
            IsOnline = true;
        }

        public static OsuClient CreateClient(string clientId, string clientSecret)
        {
            Log.Info("Retrieving token with the client credentials...");
            var jsonBody = new JObject
            {
                ["client_id"] = clientId,
                ["client_secret"] = clientSecret,
                ["grant_type"] = "client_credentials",
                ["scope"] = "public"
            };

            using var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, TOKEN_URL)
            {
                Content = new StringContent(jsonBody.ToString(), Encoding.UTF8, "application/json")
            };

            try
            {
                var response = client.SendAsync(request).Result;
                response.EnsureSuccessStatusCode();
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var tokenObject = JsonConvert.DeserializeObject<DefaultTokenObject>(responseBody);
                Log.Info("Token retrieved!");
                return new OsuClient(tokenObject.AccessToken, tokenObject.ExpiresIn);
            }
            catch (HttpRequestException e)
            {
                Log.Warn($"HTTP Exception: {e.Message}");
            }
            catch (JsonException e)
            {
                Log.Warn($"JSON Exception: {e.Message}");
            }
            Log.Warn("Unable to retrieve token. Is the configuration set up properly?");
            return null;
        }

        public async Task<T> RequestApi<T>(string compiledRoute, string token)
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, OSU_ENDPOINT + compiledRoute);
            request.Headers.Add("Authorization", $"Bearer {token}");
            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(body);
            }
            catch (HttpRequestException e)
            {
                Log.Warn($"HTTP Exception: {e.Message}");
            }
            catch (JsonException e)
            {
                Log.Warn($"JSON Exception: {e.Message}");
            }
            return default(T);
        }

        public async Task<Beatmap> getBeatmap(string beatmapId)
        {
            return await RequestApi<Beatmap>(Route.BEATMAP.Compile(beatmapId), Token);
        }

        public async Task<User> getUser(string userId, Gamemode mode)
        {
            return await RequestApi<User>(Route.USER.Compile(userId, mode.ToString().ToLowerInvariant()), Token);
        }
    }

    public class DefaultTokenObject
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}