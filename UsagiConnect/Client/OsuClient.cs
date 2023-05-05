using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UsagiConnect.Osu.Beatmap;
using UsagiConnect.Osu.Enums;
using UsagiConnect.Osu.Exceptions;
using UsagiConnect.Osu.User;

namespace UsagiConnect.Client
{
    public class OsuClient
    {
        public string Token;
        public int TokenTimeout;
        public static bool IsOnline = false;
        private static readonly string TOKEN_URL = "https://osu.ppy.sh/oauth/token";
        private static readonly string OSU_ENDPOINT = "https://osu.ppy.sh/api/v2/";
        private static readonly ILog Log = LogManager.GetLogger(typeof(OsuClient).Name);

        public OsuClient(string token, int tokenTimeout)
        {
            Token = token;
            TokenTimeout = tokenTimeout;
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
                if (!response.IsSuccessStatusCode)
                {
                    Log.Error($"Error code: { response.StatusCode }");
                    return response.StatusCode switch
                    {
                        HttpStatusCode.Unauthorized => throw new InvalidApiKeyException(),
                        _ => throw new System.NotImplementedException()
                    };
                }
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var tokenObject = JsonConvert.DeserializeObject<DefaultTokenObject>(responseBody);
                Log.Info("Token retrieved!");
                IsOnline = true;
                return new OsuClient(tokenObject.AccessToken, tokenObject.ExpiresIn);
            }
            catch (HttpRequestException e)
            {
                Log.Error($"HTTP Exception: {e.Message}");
            }
            catch (JsonException e)
            {
                Log.Error($"JSON Exception: {e.Message}");
            }
            catch 
            {
                Log.Error("Unable to retrieve token. Is the configuration set up properly?");
            }
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
                if (!response.IsSuccessStatusCode)
                {
                    Log.Error($"Error code: {response.StatusCode}");
                    return response.StatusCode switch
                    {
                        HttpStatusCode.Unauthorized => throw new InvalidApiKeyException(),
                        HttpStatusCode.NotFound => throw new BeatmapNotFoundException(),
                        _ => throw new System.NotImplementedException()
                    };
                }
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(body);
            }
            catch (HttpRequestException e)
            {
                Log.Error($"HTTP Exception: {e.Message}");
            }
            catch (JsonException e)
            {
                Log.Error($"JSON Exception: {e.Message}");
            }
            return default;
        }

        public T PostApi<T>(string compiledRoute, string token, Gamemode mode)
        {
            var client = new HttpClient();
            var content = new StringContent("{\"mods\":\"0\",\"ruleset\":\"" + mode.ToString().ToLower() + "\"}", Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var response = client.PostAsync(OSU_ENDPOINT + compiledRoute, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
                else
                {
                    Log.Error($"Error code: {response.StatusCode}");
                    return response.StatusCode switch
                    {
                        HttpStatusCode.Unauthorized => throw new InvalidApiKeyException(),
                        HttpStatusCode.NotFound => throw new BeatmapNotFoundException(),
                        _ => throw new System.NotImplementedException()
                    };
                }
            }
            catch (HttpRequestException e)
            {
                Log.Error($"HTTP Exception: {e.Message}");
            }
            catch (JsonException e)
            {
                Log.Error($"JSON Exception: {e.Message}");
            }
            return default;
        }

        public async Task<Beatmap> GetBeatmap(string beatmapId)
        {
            return await RequestApi<Beatmap>(Route.BEATMAP.Compile(beatmapId), Token);
        }
        public BeatmapAttributes GetBeatmapAttributes(string beatmapId, Gamemode mode)
        {
            return PostApi<BeatmapAttributes>(Route.BEATMAP_ATTRIBUTES.Compile(beatmapId), Token, mode);
        }

        public async Task<User> GetUser(string userId, Gamemode mode)
        {
            return await RequestApi<User>(Route.USER.Compile(userId, mode.ToString().ToLowerInvariant()), Token);
        }
    }
}