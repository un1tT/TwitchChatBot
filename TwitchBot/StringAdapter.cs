using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot
{
    class StringAdapter
    {
        public static String AdaptFeed(String feed)
        {
            if (feed.Length < 460) return feed;
            else
            {
                var readMore = feed.Substring(feed.Length - 16);
                feed = feed.Remove(feed.Length - 15, 15);
                while (feed.Length >= 455)
                {
                    feed = feed.Remove(feed.Length - 2, 1);
                    for (var i = 0; i < feed.Length; i++)
                    {
                        feed.Remove(feed.Length - (i + 1), 1);
                    }                    
                    
                }
                feed += "... ";
                feed += readMore;
                return feed;
                
            }
            

        }
    }
}
