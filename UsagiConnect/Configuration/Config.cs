﻿using log4net;
using System.IO;
using UsagiConnect.WForms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UsagiConnect.Osu.API.Beatmap;
using UsagiConnect.Osu.Beatmap;
using System.Threading.Tasks;
using UsagiConnect.Utilities;

namespace UsagiConnect.Configuration
{
    public class Config
    {
        private readonly string configDirectory = "configuration\\";
        private readonly string config = "configuration\\config.json";
        private static readonly ILog Log = LogManager.GetLogger(typeof(MainForm));

        /* Global Settings */
        public string Prefix { get; set; } = "!";
        public bool UseUpdater { get; set; } = true;

        /* Twitch Settings */
        public string TwitchUsername { get; set; } = string.Empty;
        public string TwitchPassword { get; set; } = string.Empty;
        public string TwitchChannel { get; set; } = string.Empty;

        /* GOsuMemory Settings & Stream Companion Settings */
        public string GOsuMemoryPath { get; set; } = "http://127.0.0.1:24050/json";
        public string StreamCompanionPath { get; set; } = "Not Implemented";

        /* Bancho Settings */
        public string BanchoUsername { get; set; } = string.Empty;
        public string BanchoPassword { get; set; } = string.Empty;

        /* Osu Settings */
        public string OsuClientId { get; set; } = string.Empty;
        public string OsuClientSecret { get; set; } = string.Empty;

        public Config()
        {
            InitConfiguration();
        }

        public void InitConfiguration()
        {
            if (File.Exists(config))
            {
                Log.Info("Loading configuration data.");
                LoadConfiguration();
            }
            else
            {
                CreateConfigruation();
            }
        }

        private void CreateConfigruation()
        {
            try
            {
                if (!File.Exists(config))
                {
                    Log.Info("Configuration File not found. Creating one...");
                    if (!Directory.Exists(configDirectory))
                    {
                        Directory.CreateDirectory("configuration\\");
                        File.Create(config);
                    }
                    else
                    {
                        File.Create(config);
                    }
                }
            }
            catch (IOException error)
            {
                Log.Error("Unable to create the configuration file. \n" + error.Message);
            }
        }

        private void LoadConfiguration()
        {
            var json = File.ReadAllText(config);
            JsonConvert.PopulateObject(json, this);
            Log.Info("Loaded configuration.");
            SaveConfiguration(); // Running this here in case a property is introduced or removed.
        }

        public void SaveConfiguration()
        {
            using StreamWriter file = File.CreateText(config);
            JsonSerializer serializer = new()
            {
                Formatting = Formatting.Indented
            };
            serializer.Serialize(file, this);
        }

        public Task<string> GetApiParsedMessage(string message, Beatmap beatmap)
        {
            BeatmapAttributes map = MainForm.GetOsuClient().getBeatmapAttributes(beatmap.Id.ToString());
            Dictionary<string, object> keywords = new Dictionary<string, object>();
            keywords.Add("music_note_emoji", "\u266B");
            keywords.Add("star_emoji", "\u2605");
            keywords.Add("red_exclamation", "\u2757");
            keywords.Add("ranked_status", beatmap.Status);
            keywords.Add("artist", beatmap.Beatmapset.Artist);
            keywords.Add("title", beatmap.Beatmapset.Title);
            keywords.Add("version", beatmap.Version);
            keywords.Add("length", ConvertTime.HumanReadableTime(beatmap.TotalLength));
            keywords.Add("star_rating", beatmap.DifficultyRating);
            keywords.Add("beatmap_id", beatmap.Id);
            keywords.Add("beatmap_url", beatmap.Url);
            keywords.Add("bpm", beatmap.BPM);
            keywords.Add("ar", beatmap.AR);
            keywords.Add("od", map.Attribute.OverallDifficulty);
            return Task.FromResult(ParseKeywords(message, keywords));
        }

        public string ParseKeywords(string message, Dictionary<string, object> keywords)
        {
            StringBuilder formatter = new StringBuilder(message);
            List<object> keywordsList = new List<object>();

            Regex regex = new Regex("\\<(\\w+)>");
            MatchCollection matches = regex.Matches(message);

            foreach (Match match in matches)
            {
                string key = match.Groups[1].Value;
                string formatKey = match.Groups[0].Value;
                object value;

                if (keywords.TryGetValue(key, out value))
                {
                    keywordsList.Add(value);
                    int index = formatter.ToString().IndexOf(formatKey);
                    formatter.Replace(formatKey, "{" + (keywordsList.Count - 1) + "}", index, formatKey.Length);
                }
            }
            return string.Format(formatter.ToString(), keywordsList.ToArray());
        }
    }
}