using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BookFinder.Utils
{
    public class WebServices
    {
        public static QueryCollection QueryApi(string q, int startIndex, int totalItemsPerPage)
        {
            try
            {
                //int startIndex = (pageOfPagination - 1) * totalItemsPerPage;
                string json = string.Empty;
                string url = string.Concat(@"https://www.googleapis.com/books/v1/volumes?q=", 
                    HttpUtility.UrlEncode(q), "&startIndex=", startIndex, "&maxResults=", totalItemsPerPage);
                
                ServicePointManager.Expect100Continue = true;
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                    var JsonObj = JsonConvert.DeserializeObject<QueryCollection>(json);
                    if (JsonObj != null)
                    {
                        return JsonObj;
                    }
                }
            }
            catch (Exception e)
            {

            }

            return null;
        }

        public static Volume GetVolumeById(string volumeId)
        {
            try
            {
                string json = string.Empty;
                string url = string.Concat(@"https://www.googleapis.com/books/v1/volumes/", volumeId);

                ServicePointManager.Expect100Continue = true;
                //System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = reader.ReadToEnd();
                    var JsonObj = JsonConvert.DeserializeObject<Volume>(json);
                    if (JsonObj != null)
                    {
                        return JsonObj;
                    }
                }
            }
            catch (Exception e)
            {

            }

            return null;
        }
    }
}
