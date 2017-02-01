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
        [Required]
        public string FirstName { get; set; }
        [StringLength(40)]
        [Required]
        public string LastName { get; set; }
        [StringLength(16)]
        public string Telephone { get; set; }
        //[RegularExpression(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$")]
        [StringLength(80)]
        [Required]
        public string EmailAddress { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BestTimeToCall { get; set; }
    }
}