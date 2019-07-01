using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supreme_Mobile.Models
{

    public class AccountSearchModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        public int Offset { get; set; }
        public string SearchTypeID { get; set; }
        public string SearchStatement { get; set; }
    }

    public class AccountModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        public string AccountID { get; set; }
    }
    public class OffsetModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        public int Offset { get; set; }
    }

    public class GenericResultModel
    {
        public string Status { get; set; }
        public string Remarks { get; set; }
    }

    public class AccountResultModel
    {
        public string Status { get; set; }
        public string AccountID { get; set; }
    }

    public class AddAccountModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Client ID is required")]
        public string ClientID { get; set; }
        [Required(ErrorMessage = "Account Name is required")]
        public string AccountName { get; set; }
        [Required(ErrorMessage = "Product is required")]
        public string ProductID { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string CityID { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string CountryID { get; set; }
        [Required(ErrorMessage = "Mobile is required")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "Operating Mode is required")]
        public string OperatingModeID { get; set; }
    }

    public class AccountListModel
    {
        public Int32 sNo { get; set; }
        public string AccountID { get; set; }
        public string AccountName { get; set; }
        public string ClearBalance { get; set; }
        public string AvailableBalance { get; set; }
        public string CurrencyID { get; set; }
        public string ProductID { get; set; }
        public string ClientID { get; set; }
        public string Address { get; set; }
        public string CityID { get; set; }
        public string CountryID { get; set; }
        public string Mobile { get; set; }
        public string OperatingModeID { get; set; }
        public string AccountClassID { get; set; }
        public string MinimumBalance { get; set; }
        public string FreezedAmount { get; set; }
        public string AccountStatusID { get; set; }
        public string OpenDate { get; set; }
    }

    public class AccountDetailModel
    {
        public string ProductName { get; set; }
        public string AccountID { get; set; }
        public string Adress { get; set; }
        public string Mobile { get; set; }
        public string Currency { get; set; }
        public string ClearBalance { get; set; }
        public string UnclearBalance { get; set; }
        public string Availablebalance { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }
    public class AccountTrxParamsModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Offset is required")]
        public int Offset { get; set; }
        [Required(ErrorMessage = "Records is required")]
        public int Records { get; set; }
        [Required(ErrorMessage = "OurBranchID is required")]
        public string OurBranchID { get; set; }
        [Required(ErrorMessage = "AccountID is required")]
        public string AccountID { get; set; }
    }
    public class AccountStmParamsModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "OurBranchID is required")]
        public string OurBranchID { get; set; }
        [Required(ErrorMessage = "AccountID is required")]
        public string AccountID { get; set; }
        [Required(ErrorMessage = "From Date is required")]
        public string FromDate { get; set; }
        [Required(ErrorMessage = "To Date is required")]
        public string ToDate { get; set; }

    }
    public class AccountTransactionsModel
    {
        public string sNo { get; set; }
        public string TrxRowID { get; set; }
        public string TrxDate { get; set; }
        public string ValueDate { get; set; }
        public string TrxDescription { get; set; }
        public string TrxTypeID { get; set; }
        public string Credit { get; set; }
        public string Debit { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string SupervisedBy { get; set; }
    }
    public class AccountStatementModel
    {
        public string ColumnID { get; set; }
        public string TrxDate { get; set; }
        public string ValueDate { get; set; }
        public string Particulars { get; set; }
        public string Credit { get; set; }
        public string Debit { get; set; }
        public string Closing { get; set; }
        public string OperatorID { get; set; }
        public string SupervisedID { get; set; }
    }
}