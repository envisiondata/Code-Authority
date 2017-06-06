using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactUsXamarin.ViewModels
{
    public class DataService
    {
        public static async Task<dynamic> getDataFromService(string queryString)
        {
            var uri = new Uri(string.Format(queryString, string.Empty));

            HttpClient client = new HttpClient();

            dynamic data = @"""";

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    data = json;
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return data;

        }

        public static async Task<bool> postDataToService(string URL, Contacts PostData)
        {
            bool _return = false;

            HttpClient client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri(string.Format(URL, string.Empty));

            var json = JsonConvert.SerializeObject(PostData);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                _return = true;
            }

            return _return;
        }
    }
}
