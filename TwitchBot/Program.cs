using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Text;
using System.Net.Sockets;

namespace TwitchBot

{
    class Program
    {
 

        static void Main(string[] args)
        {

            TwitchChatBot bot = new TwitchChatBot();
            bot.Connect();
            Console.ReadLine();
            bot.Disconnect();
            
        }
    }
}
