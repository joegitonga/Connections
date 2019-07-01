using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supreme_Mobile.Models
{
    public class SubCodeModel
    {
        public string SubCodeID { get; set; }
        public string Description { get; set; }
    }

    public class SysCodeModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        public string SubCodeID { get; set; }
    }

    public class SysCodeDetailModel
    {
        public string CodeID { get; set; }
        public string Description { get; set; }
    }

    public class NewUsersModel
    {
        public Int32 UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
    }

    public class MyUsersModel
    {
        public Int32 UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SecurityStamp { get; set; }
        public string IPAddress { get; set; }
    }

    public class CreatedUserResultModel
    {
        public Int32 ColumnID { get; set; }
        public Int32 UserID { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public string UserStatus { get; set; }
    }

    public class MyUserResultModel
    {
        public string Status { get; set; }
        public Int32 UserID { get; set; }
        public string UserName { get; set; }
    }

    public class ValidTokenResultModel
    {
        public Int32 UserID { get; set; }
        public string UserName { get; set; }
        public string TokenDate { get; set; }
        public string SecurityStamp { get; set; }
    }

    public class MyTokenResultModel
    {
        public string tokenAuth { get; set; }
    }

    public class Audit
    {
        public Guid AuditID { get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public string URLAccessed { get; set; }
        public DateTime TimeAccessed { get; set; }

        public Audit()
        {
        }
    }
}