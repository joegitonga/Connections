using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supreme_Mobile.Models
{
    public class AddLoanModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Client ID is required")]
        public string ClientID { get; set; }
        [Required(ErrorMessage = "Product is required")]
        public string ProductID { get; set; }
        [Required(ErrorMessage = "Loan Amount is required")]
        public double LoanAmount { get; set; }
        [Required(ErrorMessage = "Loan Term is required")]
        public int LoanTerm { get; set; }
        [Required(ErrorMessage = "Interest Rate is required")]
        public double InterestRate { get; set; }
        [Required(ErrorMessage = "Loan Frequency is required")]
        public string LoanPeriodID { get; set; }
        [Required(ErrorMessage = "Loan Purpose is required")]
        public string PurposeCodeID { get; set; }
        [Required(ErrorMessage = "Credit Officer is required")]
        public string CreditOfficerID { get; set; }
        public string OperatorID { get; set; }        
    }
    public class SanctionLoanModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Application ID is required")]
        public string ApplicationID { get; set; }
        [Required(ErrorMessage = "ApprovedBy is required")]
        public string ApprovedBy { get; set; }
        public string Remarks { get; set; }
        public string OperatorID { get; set; }
    }
    public class RejectionLoanModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Application ID is required")]
        public string ApplicationID { get; set; }
        [Required(ErrorMessage = "Remarks is required")]
        public string Remarks { get; set; }
        public string OperatorID { get; set; }
    }
    public class BookingLoanModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Application ID is required")]
        public string ApplicationID { get; set; }
        [Required(ErrorMessage = "Installment Date is required")]
        public string InstallmentDate { get; set; }
        public string OperatorID { get; set; }
    }
    public class DisbursementLoanModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Application ID is required")]
        public string ApplicationID { get; set; }
        [Required(ErrorMessage = "Disbursement Narration is required")]
        public string Narration { get; set; }
        public string OperatorID { get; set; }
    }

    public class ProcessLoanModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "ClientID is required")]
        public string ClientID { get; set; }
        [Required(ErrorMessage = "ProductID is required")]
        public string ProductID { get; set; }
        [Required(ErrorMessage = "Loan Amount is required")]
        public double LoanAmount { get; set; }
        [Required(ErrorMessage = "Loan Term is required")]
        public int LoanTerm { get; set; }
        [Required(ErrorMessage = "Interest Rate is required")]
        public double InterestRate { get; set; }
        [Required(ErrorMessage = "Loan Period is required")]
        public string LoanPeriodID { get; set; }
        [Required(ErrorMessage = "Purpose CodeID is required")]
        public string PurposeCodeID { get; set; }
        [Required(ErrorMessage = "Credit Officer is required")]
        public string CreditOfficerID { get; set; }
        [Required(ErrorMessage = "Remarks is required")]
        public string Remarks { get; set; }
        public string OperatorID { get; set; }
    }

    public class WFParamsModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Offset is required")]
        public int Offset { get; set; }
        [Required(ErrorMessage = "Records Per Grid is required")]
        public int Records { get; set; }
        [Required(ErrorMessage = "StageID is required")]
        public string ADVStageID { get; set; }
        [Required(ErrorMessage = "StatusID is required")]
        public string AppStatusID { get; set; }
    }
    public class WFLoanListModel
    {
        public Int32 sNo { get; set; }
        public string OurBranchID { get; set; }
        public string ApplicationID { get; set; }
        public string ApplicationDate { get; set; }
        public string ClientID { get; set; }
        public string Name { get; set; }
        public string ProductID { get; set; }
        public double LoanAmount { get; set; }
        public int LoanTerm { get; set; }
        public string WFAdvStageID { get; set; }
        public string WFAppStatusID { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }

    public class DisbursedLoanListModel
    {
        public Int32 sNo { get; set; }
        public string OurBranchID { get; set; }
        public string ClientID { get; set; }
        public string AccountID { get; set; }
        public int LoanSeries { get; set; }
        public string Name { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CreditOfficer { get; set; }
        public double DisbursedAmount { get; set; }
        public double InterestRate { get; set; }
        public double InterestAmount { get; set; }
        public int Term { get; set; }
        public string Period { get; set; }
        public string RepaymentTerm { get; set; }

        public string InstallmentStartDate { get; set; }
        public string MaturityDate { get; set; }
        public string Purpose { get; set; }
        public string DisbursementDate { get; set; }
    }

    public class DisbursedListParamsModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Offset is required")]
        public int Offset { get; set; }
        [Required(ErrorMessage = "Records Per Grid is required")]
        public int Records { get; set; }
    }

    public class LoanInstallmentModel
    {
        public Int32 sNo { get; set; }
        public string InstallmentNo { get; set; }
        public string InstallmentDueDate { get; set; }
        public double InstallmentAmount { get; set; }
        public double LoanBalance { get; set; }
        public double PrincipalBalance { get; set; }
        public double PrincipalDue { get; set; }
        public decimal InterestRate { get; set; }
        public double InterestDue { get; set; }
        public double Tax { get; set; }
        public string Others { get; set; }
        public string PaidStatus { get; set; }
    }
    public class LoanDetailsModel
    {
        public string LoanBalance { get; set; }
        public string LoanAmount { get; set; }
        public string DisbursedAmount { get; set; }
        public string FirstDisbursementDate { get; set; }
        public string UnearnedInterest { get; set; }
        public string OutstandingPrincipal { get; set; }
        public string OutstandingInterest { get; set; }
        public string InterestReceivable { get; set; }
        public string PenaltyReceivable { get; set; }
        public string LoanStatusID { get; set; }
        public string LoanStatus { get; set; }
        public string ProductID { get; set; }
        public string InterestType { get; set; }
        public string CurrencyID { get; set; }
        public string SanctionedAmount { get; set; }
        public string InterestRate { get; set; }
        public string SanctionedDate { get; set; }
        public string InstallmentStartDate { get; set; }
        public string Term { get; set; }
        public string MaturityDate { get; set; }
        public string RepaymentTerm { get; set; }
        public string InstallmentAmount { get; set; }
        public string RepaymentFrequency { get; set; }
        public string LastInstallmentAmount { get; set; }
        public string CalculationMethod { get; set; }
        public string OurBranchID { get; set; }
        public string BranchName { get; set; }
        public string ClientID { get; set; }
        public string ClientName { get; set; }
        public string AccountID { get; set; }
        public string AccountName { get; set; }
        public string LoanSeries { get; set; }
        public string RepaymentAccountID { get; set; }
        public string PurposeCodeID { get; set; }
        public string CreditOfficerID { get; set; }
        public string CreditOfficer { get; set; }
        public string RepaymentMethodID { get; set; }
        public string LoanTypeID { get; set; }
        public string LoanType { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
    }

    public class InstallmentParamsModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Account ID is required")]
        public string AccountID { get; set; }
        [Required(ErrorMessage = "LoanSeries is required")]
        public int LoanSeries { get; set; }
    }

    public class LoanDetailsParamsModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Branch Code is required")]
        public string OurBranchID { get; set; }
        [Required(ErrorMessage = "Account ID is required")]
        public string AccountID { get; set; }
        [Required(ErrorMessage = "LoanSeries is required")]
        public int LoanSeries { get; set; }
    }
    public class LoanAppResultModel
    {
        public string Status { get; set; }
        public string ApplicationID { get; set; }
    }

    public class LoanBookResultModel
    {
        public string Status { get; set; }
        public string AccountID { get; set; }
    }

    public class LoanDisbResultModel
    {
        public string Status { get; set; }
        public string SerialID { get; set; }
    }

    public class LoanProcessResultModel
    {
        public string Status { get; set; }
        public string ApplicationID { get; set; }
        public string AccountID { get; set; }
        public string OperationalAccountID { get; set; }
        public string SerialID { get; set; }
    }

}