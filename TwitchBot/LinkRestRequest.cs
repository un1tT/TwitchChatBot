using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace TwitchBot
{
    class LinkRestRequest
    {
        
        public static String MakeRequest(String data)
        {
            String uri = "https://to.click/api/v1/links";
            String responseString = String.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

            request.Method = "POST";
            request.ContentType="application/json";
            request.Headers["X-AUTH-TOKEN"] = "TKWo5Q7uZkDqRzLNEL2DtAM7"; 
            UTF8Encoding encode = new UTF8Encoding();
            var byteArray = encode.GetBytes(data); 
            request.ContentLength = byteArray.Length;

            request.Timeout = 12000;

            using (Stream webStream = request.GetRequestStream())
            {
                webStream.Write(byteArray, 0, byteArray.Length);                
            }  
            
            try
                    {
                        HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
                        using (Stream responsewebStream = webResponse.GetResponseStream())
                        {
                            if (responsewebStream != null)
                            {
                                using (StreamReader responseReader = new StreamReader(responsewebStream))
                                {
                                    responseString = responseReader.ReadToEnd();
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Out.WriteLine(e.Message);
                    }
            
            

            dynamic JsonTemp = JsonConvert.DeserializeObject(responseString);
            String shortLink = JsonTemp.data.attributes.full_url;

            return shortLink;
             
        }
        
    }
}
