using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supreme_Mobile.Models
{
    public class TrxModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        public string OurBranchID { get; set; }
        public int Offset { get; set; }
    }
    public class CashTrxListModel
    {
        public string ReferenceNo { get; set; }
        public string AccountID { get; set; }
        public string Name { get; set; }
        public string TrxAmount { get; set; }
        public string TrxDate { get; set; }
        public string OperatorID { get; set; }
    }
    public class TrfTrxListModel
    {
        public string ReferenceNo { get; set; }
        public string AccountID { get; set; }
        public string Name { get; set; }
        public string TrxAmount { get; set; }
        public string TrxDate { get; set; }
        public string OperatorID { get; set; }
    }
    public class TrfResultModel
    {
        public string Status { get; set; }
        public string SerialID { get; set; }
    }
    public class TransferTrxAddModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Debit AccountType is required")]
        public string DRAccountTypeID { get; set; }
        [Required(ErrorMessage = "Credit AccountType is required")]
        public string CRAccountTypeID { get; set; }
        [Required(ErrorMessage = "Debit Account Number is required")]
        public string DRAccountID { get; set; }
        [Required(ErrorMessage = "Credit Account Number is required")]
        public string CRAccountID { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public double TrxAmount { get; set; }
        [Required(ErrorMessage = "Narration is required")]
        public string Narration { get; set; }
        public string RefNumber { get; set; }
    }
    public class CashTrxAddModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "AccountType is required")]
        public string AccountTypeID { get; set; }
        [Required(ErrorMessage = "Account Number is required")]
        public string AccountID { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public double TrxAmount { get; set; }
        [Required(ErrorMessage = "Narration is required")]
        public string Narration { get; set; }
        public string RefNumber { get; set; }
        [Required(ErrorMessage = "OperatorID is required")]
        public string OperatorID { get; set; }
        [Required(ErrorMessage = "Transaction Type is required")]
        public string TrxTypeID { get; set; }
    }
}