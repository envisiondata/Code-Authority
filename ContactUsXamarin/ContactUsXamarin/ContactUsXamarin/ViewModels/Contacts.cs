using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactUsXamarin.ViewModels
{
    public class Contacts
    {
        public Guid ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName;  } set { } }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BestTimeToCall { get; set; }
    }
}
