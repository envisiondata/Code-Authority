using ContactUs.Data.Model;
using ContactUs.Models;
using ContactUs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Service
{
    public interface IContactService
    {
        void PostContact(ContactViewModel myContact);
        List<ContactViewModel> GetContacts();

        bool Delete(string id);
    }
}
