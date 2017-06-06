using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContactUs.Data.Model
{
    //[Table("dbo.Contact")]
    public class Contact
    {
        public Guid ContactID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Telephone { get; set; }

        public string EmailAddress { get; set; }

        public DateTime? BestTimeToCall { get; set; }
    }
}
