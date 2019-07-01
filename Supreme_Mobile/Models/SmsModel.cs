using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supreme_Mobile.Models
{
    public class SendSmsModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        public string MobileNumber { get; set; }
        public string smsText { get; set; }
    }
}