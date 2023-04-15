using log4net;
using System;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using UsagiConnect.WForms;

namespace UsagiConnect.Client
{
    public class TwiClient
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(TwiClient).Name);
        TwitchClient TwitchClient;
        public TwiClient() 
        {
            ConnectionCredentials credentials = new ConnectionCredentials(MainForm.Config.TwitchUsername, MainForm.Config.TwitchPassword);

            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };

            WebSocketClient customClient = new WebSocketClient(clientOptions);
            TwitchClient = new TwitchClient(customClient);
            TwitchClient.Initialize(credentials, MainForm.Config.TwitchChannel);
            TwitchClient.OnMessageReceived += Client_OnMessageReceived;
            TwitchClient.OnConnected += Client_OnConnected;
            TwitchClient.Connect();
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            Log.Info("Message Received From: " + e.ChatMessage.DisplayName + " and the message was: " + e.ChatMessage.Message);
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Log.Info("Connected to the channel");
        }
    }
}