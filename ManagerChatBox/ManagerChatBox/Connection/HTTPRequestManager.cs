using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagerChatBox.Connection
{
    class HTTPRequestManager
    {
        public static string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            string responseResult;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        responseResult = decodeUnicodeResponse(reader.ReadToEnd());
                        reader.Close();
                    }
                    stream.Close();
                }
                response.Close();
            }
            return responseResult;
        }

        private static string decodeUnicodeResponse(string rawResponse)
        {
            return System.Text.RegularExpressions.Regex.Unescape(rawResponse);
        }
    }
}
