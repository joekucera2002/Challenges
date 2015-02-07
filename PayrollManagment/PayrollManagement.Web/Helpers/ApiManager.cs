using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace PayrollManagement.Web.Helpers
{
    public class ApiManager
    {
        private readonly String _baseUrl;

        public ApiManager()
        {
            _baseUrl = ConfigurationManager.AppSettings["WebApiLocation"];
        }

        public T Get<T>(String location, Dictionary<String, String> queryParameters)
        {
            String url = BuildUrl(location, queryParameters);
            String result = null;

            using (WebClient client = new WebClient())
            {
                result = client.DownloadString(url);
            }
            
            return Deserialize<T>(result);
        }

        private String BuildUrl(String location, Dictionary<String, String> queryParameters)
        {
            String url = _baseUrl;

            if (!url.EndsWith("?"))
            {
                url += "?";
            }

            foreach (KeyValuePair<String, String> pair in queryParameters)
            {
                if (!url.EndsWith("?"))
                {
                    url += "&";
                }

                url += String.Format("{0}={1}", pair.Key, pair.Value);
            }

            return url;
        }

        private T Deserialize<T>(String json)
        {
            if (!String.IsNullOrWhiteSpace(json))
            {
                using (JsonTextReader reader = new JsonTextReader(new StringReader(json)))
                {
                    JsonSerializer js = new JsonSerializer();

                    return js.Deserialize<T>(reader);
                }
            }

            return default(T);
        }
    }
}