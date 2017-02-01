using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContactUs.Models
{
    [Table("dbo.Contact")]
    public class Contact
    {
        [Key]
        public Guid ContactID { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [StringLength(16)]
        public string Telephone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(80)]
        [Required(ErrorMessage = "Email Address is required")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BestTimeToCall { get; set; }
    }
}