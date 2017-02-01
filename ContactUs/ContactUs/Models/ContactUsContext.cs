using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactUs.Models
{
    public class ContactUsContext : DbContext
    {
        public ContactUsContext()
        : base("name=CodeAuthority")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}