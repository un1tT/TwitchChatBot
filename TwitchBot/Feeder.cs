using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Text.RegularExpressions;

namespace TwitchBot
{
    class Feeder
    {
        public static String GetFeed()
        {
            String url = "https://habr.com/rss/interesting/";
            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                StringBuilder builder = new StringBuilder();
                //builder.Append(@"<!DOCTYPE html ><html><meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>");
                SyndicationItem item = feed.Items.First();
                builder.Append(item.Title.Text + ": ");
                builder.Append(item.Summary.Text);
                builder.Append(Environment.NewLine);
                builder.Append(" Ссылка на новость:" + item.Links[0]);
                String outFeed = builder.ToString();
                outFeed = Regex.Replace(outFeed, " < img src =>\\w\">", String.Empty);
                outFeed = Regex.Replace(outFeed, @"<[^>]*>", String.Empty);

                return outFeed;
            }
        }

        public static String GetRandomFeed()
        {
            String url = "https://habr.com/rss/interesting/";
            using (XmlReader reader = XmlReader.Create(url))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                Random r = new Random();
                SyndicationItem item = feed.Items.ElementAt(r.Next(feed.Items.Count() - 1));

                var tempTitle = item.Title.Text;
                tempTitle = Regex.Replace(tempTitle, " < img src =>\\w\">", String.Empty);
                tempTitle = Regex.Replace(tempTitle, @"<[^>]*>", String.Empty);
                tempTitle.Trim(' ');
                tempTitle += ": ";

                String outFeed = tempTitle;

                var tempSummary = item.Summary.Text;
                tempSummary = Regex.Replace(tempSummary, " < img src =>\\w\">", String.Empty);
                tempSummary = Regex.Replace(tempSummary, @"<[^>]*>", String.Empty);
                tempSummary.Trim(' ');
                outFeed += tempSummary;

                String dataForRequest = "{ \"data\": { \"type\": \"link\", \"attributes\": { \"web_url\": \"" + item.Links[0].Uri.ToString() + "\"} }}";
                String shortLink = LinkRestRequest.MakeRequest(dataForRequest);
                outFeed = StringAdapter.AdaptFeed(outFeed);
                outFeed += " "+shortLink;
                Console.Out.WriteLine(outFeed);
                return outFeed;
            }
        }

        
            
               
    }
}
