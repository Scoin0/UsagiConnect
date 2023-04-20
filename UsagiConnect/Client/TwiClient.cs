using log4net;
using System;
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
        CommandClient CommandClient;

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
                TwitchClient.OnConnected += Client_OnConnected;
                TwitchClient.Connect();
            }
            catch (Exception)
            {
                Log.Error("Could not Connect to Twitch Channel. Is everything set up correctly?");
            }
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Log.Info("Successfully Joined:  #" + MainForm.Config.TwitchChannel);
        }

        private void LoadListeners()
        {
            CommandClient = new CommandClient(GetTwitchClient());
            AddCommands();
        }

        private void AddCommands()
        {
            CommandClient.AddCommand(new NowPlayingCommand());
            CommandClient.AddCommand(new StatsCommand());
        }
    }
}