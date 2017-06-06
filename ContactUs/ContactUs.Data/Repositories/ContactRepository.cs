using ContactUs.Data.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public void PostContact(Contact myContact)
        {
            WebRequest request = WebRequest.Create("http://52.26.69.45:1111//ContactUSAPI/Contact/Post");

            request.Method = "POST";
            string postData = JsonConvert.SerializeObject(myContact);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        public bool Delete(string id)
        {
            WebRequest request = WebRequest.Create("http://52.26.69.45:1111/ContactUSAPI/Contact/Delete/" + id);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if(response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public List<Contact> GetContacts()
        {
            string json;
            List<Contact> dbContacts = new List<Contact>();

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://52.26.69.45:1111//ContactUSAPI/Contact/Get");

            HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), true))
            {
                try
                {
                    json = streamReader.ReadToEnd();
                    var _json = json.Substring(1, json.Length - 2).Replace(@"\", "");
                    dbContacts = JsonConvert.DeserializeObject<List<Contact>>(_json);
                }
                catch { }
            }

            return dbContacts;

        }

        static async Task<string> DownloadPage(string url)
        {
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    return result;
                }
            }
        }
    }
}
