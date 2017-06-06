using ContactUs.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUs.Data.Repositories
{
    public interface IContactRepository
    {
        void PostContact(Contact myContact);
        List<Contact> GetContacts();

        bool Delete(string id);
    }
}
