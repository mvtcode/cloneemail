using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Clone
{
    class HTMLultility
    {
        public static string GetHotName(string slink)
        {
            int i = 0;
            if (slink.ToLower().StartsWith("http://"))
                i = 7;
            if (slink.ToLower().StartsWith("https://"))
                i = 8;
            int k = slink.IndexOf("/", i);
            k = k > 0 ? k :slink.Length;
            return slink.Substring(0, k);
        }

        public static string GetCurentPage(string sLink)
        {
            int k = sLink.LastIndexOf("?");
            if (k < 0) k = sLink.Length;
            sLink = sLink.Substring(0, k);

            int iStart = 0;
            if (sLink.ToLower().StartsWith("http://"))
                iStart = 7;
            if (sLink.ToLower().StartsWith("https://"))
                iStart = 8;

            k = sLink.LastIndexOf("/");

            if (k < iStart) k = sLink.Length;
            return sLink.Substring(0, k);
        }

        public static bool RemoteFileExists(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }
    }
}
