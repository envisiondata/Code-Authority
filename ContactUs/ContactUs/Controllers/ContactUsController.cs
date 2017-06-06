using BotDetect.Web.Mvc;
using ContactUs.Models;
using ContactUs.Service;
using ContactUs.ViewModels;
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

            private readonly IContactService _contact;

        public ContactUsController(IContactService Contact)
        {
            _contact = Contact;
        }

        public ActionResult Index()
        {
            ViewBag.Success = null;

            ContactsViewModel ViewModel = new ContactsViewModel();
            ViewModel.ListContact =  _contact.GetContacts();

            return View(ViewModel);
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult Create(ContactViewModel MyContact)
        {
            if (ModelState.IsValid)
            {
                MyContact.ContactID = Guid.NewGuid();
                _contact.PostContact(MyContact);

                return RedirectToAction("Index");
            }
            return View(MyContact);
        }
        
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Delete(string id)
        {
            bool success = _contact.Delete(id);

            return RedirectToAction("Index");  
        }

        public ActionResult ThankYou()
        {
            return View();
        }

    }
}