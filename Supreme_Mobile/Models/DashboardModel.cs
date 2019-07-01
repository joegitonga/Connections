using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supreme_Mobile.Models
{
    public class MovementModel
    {
        public string TrxBranchID { get; set; }
        public string TrxTypeID { get; set; }
        public double Amount { get; set; }
    }
    public class MovementParamModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Offset is required")]
        public int Offset { get; set; }
    }
    public class TillBalParamModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "BranchID is required")]
        public string OurBranchID { get; set; }
    }
    public class DisbursmentModel
    {
        public string OurBranchID { get; set; }
        public double DisbursedAmount { get; set; }
    }
    public class TillBalanceModel
    {
        public string TillName { get; set; }
        public double TellerBalance { get; set; }
    }
}