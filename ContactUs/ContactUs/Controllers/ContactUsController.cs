using BotDetect.Web.Mvc;
using ContactUs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ContactUs.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        private ContactUsContext db = new ContactUsContext();

        public ActionResult Index()
        {
            //Contact result = db.Contacts.Distinct().FirstOrDefault();

            return View();
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Telephone,EmailAddress,BestTimeToCall")] Contact MyContact)
        {
            if (ModelState.IsValid)
            {
                MyContact.ContactID = Guid.NewGuid();
                PostContact(MyContact);

                return RedirectToAction("ThankYou");
            }
            return View(MyContact);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult ThankYou()
        {
            return View();
        }
        private bool PostContact(Contact myContact)
        {
            bool _return = false;
            
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

            return _return;
        }
    }
}