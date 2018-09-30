using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Api;
using TwitchLib.Client.Models;

namespace TwitchBot
{
    class CommandHandler
    {
        private string userName;
        
        public static void HandleCommand(TwitchClient client,ChatMessage message)
        {
            if ((message.Message.StartsWith("hi", StringComparison.InvariantCultureIgnoreCase)) | (message.Message.StartsWith("привет", StringComparison.InvariantCultureIgnoreCase)))
            {
                client.SendMessage(message.Channel, "@" + message.Username + " Добро пожаловать на трансляцию!");
            }            
            else if (message.Message.StartsWith("!feed", StringComparison.InvariantCultureIgnoreCase))
            {
                try
                {                    
                    client.SendMessage(message.Channel, Feeder.GetRandomFeed());
                }
                catch (Exception ex) { Console.Out.WriteLine(ex.Message); }
                
            }
        }
    }
}
