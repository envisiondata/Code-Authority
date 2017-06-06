using ContactUs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CAWebAPI.Controllers
{
    public class ContactController : ApiController
    {
        private ContactUsContext _db = new ContactUsContext();

        // GET api/<controller>
        public string Get()
        {
            List<Contact> myContacts = new List<Contact>();
            myContacts = _db.Contacts.ToList();

            string _return = "";

            _return = JsonConvert.SerializeObject(myContacts);

            return _return;
        }

        // GET api/<controller>/5
        public string Get(string id)
        {
            List<Contact> myContacts = new List<Contact>();
            myContacts = _db.Contacts.Where(a => a.ContactID.ToString() == id).ToList();

            string _return = "";

            _return = JsonConvert.SerializeObject(myContacts);

            return _return;
        }

        // POST api/<controller>
        public string Post([FromBody]string value)
        {
            string Buffer = string.Empty;

            Stream s = HttpContext.Current.Request.InputStream;
            s.Position = 0;
            StreamReader sr = new StreamReader(s);
            Buffer = sr.ReadToEnd();

            ContactUs.Models.Contact myContactInfo = JsonConvert.DeserializeObject<ContactUs.Models.Contact>(Buffer);

            myContactInfo.ContactID = Guid.NewGuid();
            _db.Contacts.Add(myContactInfo);
            _db.SaveChanges();

            return "success";
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<controller>/5
        [HttpGet]
        public HttpResponseMessage Delete(string id)
        {

            try
            {
                Guid itemID = new Guid(id);

                var itemToRemove = _db.Contacts.SingleOrDefault(x => x.ContactID == itemID); //returns a single item.

                if (itemToRemove != null)
                {
                    _db.Contacts.Remove(itemToRemove);
                    _db.SaveChanges();
                }

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {

            }

            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            
        }
    }
}