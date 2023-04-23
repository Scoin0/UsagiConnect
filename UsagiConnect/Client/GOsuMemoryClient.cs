using log4net;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UsagiConnect.Osu.Beatmap;
using UsagiConnect.WForms;

namespace UsagiConnect.Client
{
    public class GOsuMemoryClient
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(GOsuMemoryClient).Name);

        public string GetModsFromGOsuMemory()
        {
            try
            {
                string webPath = MainForm.Config.GOsuMemoryPath;
                string json = string.Empty;

                using (var stream = new StreamReader(WebRequest.Create(webPath).GetResponse().GetResponseStream()))
                {
                    json = stream.ReadToEnd();
                }

                var t = JObject.Parse(json);

                string beatmapId = t["menu"]["mods"]["str"].ToString();
                string mods = beatmapId;
                return mods;
            }
            catch (WebException ex)
            {
                Log.Error("Either GOsuMemory is not running or the GOsuMemoryPath is incorrect.\n" + ex.Message);
            }
            catch (IOException ex)
            {
                Log.Error(ex.Message);
            }
            return null;
        }

        public async Task<Beatmap> GetSongFromGOsuMemory()
        {
            try
            {
                string webPath = MainForm.Config.GOsuMemoryPath;
                string json = string.Empty;

                using (var stream = new StreamReader(WebRequest.Create(webPath).GetResponse().GetResponseStream()))
                {
                    json = stream.ReadToEnd();
                }

                var t = JObject.Parse(json);

                string beatmapId = t["menu"]["bm"]["id"].ToString();
                Beatmap beatmap = await MainForm.OsuClient.GetBeatmap(beatmapId);
                return beatmap;
            }
            catch (WebException ex)
            {
                Log.Warn("Either GOsuMemory is not running or the GOsuMemoryPath is incorrect.\n" + ex.Message);
            }
            catch (IOException ex)
            {
                Log.Error(ex.Message);
            }
            return null;
        }
    }
}