using log4net;
using System;
using System.Runtime.InteropServices;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using UsagiConnect.Commands;
using UsagiConnect.Commands.TwitchCommands;
using UsagiConnect.WForms;

namespace UsagiConnect.Client
{
    public class TwiClient
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TwiClient).Name);
        TwitchClient TwitchClient;
        ConnectionCredentials credentials = new ConnectionCredentials(MainForm.Config.TwitchUsername, MainForm.Config.TwitchPassword);
        public CommandClient CommandClient;

        public TwiClient()
        {
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };

            WebSocketClient customClient = new WebSocketClient(clientOptions);
            TwitchClient = new TwitchClient(customClient);
        }

        public TwitchClient GetTwitchClient()
        {
            return TwitchClient;
        }

        public CommandClient GetCommandClient()
        {
            return CommandClient;
        }

        public void StartClient()
        {
            LoadListeners();
            try
            {
                TwitchClient.Initialize(credentials, MainForm.Config.TwitchChannel);
                TwitchClient.OnLog += Client_OnLog;
                TwitchClient.OnConnected += Client_OnConnected;
                TwitchClient.OnConnectionError += Client_OnConnectionError;
                TwitchClient.Connect();
            }
            catch (Exception)
            {
                Log.Error("Could not Connect to Twitch Channel. Is everything set up correctly?");
            }
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Log.Info("Successfully Joined:  #" + MainForm.Config.TwitchChannel);
        }

        private void Client_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            Log.Warn(e.BotUsername + " failed to connect to Twitch!");
        }

        private void LoadListeners()
        {
            CommandClient = new CommandClient(GetTwitchClient());
            AddCommands();
        }

        private void AddCommands()
        {
            CommandClient.AddCommand(new HelpCommand());
            CommandClient.AddCommand(new StatsCommand());
            CommandClient.AddCommand(new StarLimitCommand());
            CommandClient.AddCommand(new NowPlayingCommand());
            CommandClient.AddCommand(new RequestToggleCommand());
        }
    }
}