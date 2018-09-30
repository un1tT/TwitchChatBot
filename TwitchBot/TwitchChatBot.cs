using System;
using TwitchLib;
using TwitchLib.Client.Models;
using TwitchLib.Api.Models.v5.Streams;
using TwitchLib.Client.Events;
using TwitchLib.Client;

namespace TwitchBot

{
    internal class TwitchChatBot
    {

        
        TwitchClient client;
        
       
    
        public TwitchChatBot()
        {
        }
        public void Connect()
        {
            Console.WriteLine("Connecting");
            try
            {
                ConnectionCredentials credentials = new ConnectionCredentials(Resource1.BotUserName, Resource1.BotToken);
                client = new TwitchClient();
                client.Initialize(credentials);
                client.OnConnected += Client_OnConnected;
                client.OnLog += Client_OnLog;
                client.OnConnectionError += Client_OnConnectError;
               
                client.OnJoinedChannel += Client_Onjoin;
               
                client.OnMessageReceived += Client_OnMessage;
                client.OnJoinedChannel += Client_Onjoin;
                client.Connect();                 

            } catch (Exception ex) { Console.WriteLine(ex.Message); }
            
            
        }
       
        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            client.JoinChannel("un1t_tv");
        }

        private void Client_Onjoin(object sender, OnJoinedChannelArgs e)
        {
            Console.WriteLine(e.Channel+ " joined");
            
        }

        private void Client_OnMessage(object sender, OnMessageReceivedArgs e)
        {
            try
            {
                CommandHandler.HandleCommand(client,e.ChatMessage);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
                     
        }

        private void Client_OnConnectError(object sender, OnConnectionErrorArgs e)
        {
            Console.WriteLine($"Error!!{e.Error}");
        }

       
       

        public void Disconnect()
        {
            Console.WriteLine("Disconnecting");
        }

       
    }
}