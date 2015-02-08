using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
            T returnValue;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseUrl);

                    Task<String> response = client.GetStringAsync(url);

                    response.Wait();

                    if (!String.IsNullOrWhiteSpace(response.Result))
                    {
                        returnValue = Deserialize<T>(response.Result);
                    }
                    else
                    {
                        returnValue = default(T);
                    }
                }
            }
            catch
            {
                returnValue = default(T);
            }
            
            return returnValue;
        }
        
        public Boolean Update<T>(String location, T content)
        {
            Boolean result;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseUrl);

                    Task<HttpResponseMessage> response = client.PostAsJsonAsync<T>(location, content);
                    
                    response.Wait();
                    response.Result.EnsureSuccessStatusCode();

                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        private String BuildUrl(String location, Dictionary<String, String> queryParameters)
        {
            String url = location;
            
            if (queryParameters != null)
            {
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