using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supreme_Mobile.Models
{
    public class ClientListModel
    {
        public Int32 sNo { get; set; }
        public string ClientTypeID { get; set; }
        public string ClientID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CityID { get; set; }
        public string CountryID { get; set; }
        public string Mobile { get; set; }
        public string OpenedDate { get; set; }

    }
    public class ClientResultModel
    {
        public string Status { get; set; }
        public string ClientID { get; set; }
    }
    public class AddClientModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "Client Type ID is required")]
        public string ClientTypeID { get; set; }
        [Required(ErrorMessage = "Title ID is required")]
        public string TitleID { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string GenderID { get; set; }
        [Required(ErrorMessage = "Date Of Birth is required")]
        public string DateOfBirth { get; set; }
        [Required(ErrorMessage = "Identification type is required")]
        public string IDTypeID { get; set; }
        [Required(ErrorMessage = "Identification Number is required")]
        public string IDNumber { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string CountryID { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string CityID { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        public string ZipCodeID { get; set; }
        [Required(ErrorMessage = "Mobile is required")]
        public string Mobile { get; set; }
        public string EmailAddress { get; set; }
        public string Phone1 { get; set; }
    }

    public class ClientSearchModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        public int Offset { get; set; }
        public string SearchTypeID { get; set; }
        public string SearchStatement { get; set; }
    }
    public class ClientDetailsModel
    {
        public string TitleID { get; set; }
        public string ClientID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string CityID { get; set; }
        public string CountryID { get; set; }
        public string Mobile { get; set; }
        public string GenderID { get; set; }
        public string NationalityID { get; set; }
        public string DateOfBirth { get; set; }
        public string Phone1 { get; set; }
        public string Email { get; set; }
    }
    public class ClientParamModel
    {
        [Required(ErrorMessage = "Token Code is required")]
        public string TokenCode { get; set; }
        [Required(ErrorMessage = "ClientID is required")]
        public string ClientID { get; set; }
    }
    public class ClientAccountsModel
    {
        public string OurBranchID { get; set; }
        public string ClientID { get; set; }
        public string AccountID { get; set; }
        public string AccountName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile { get; set; }
        public string EmailiD { get; set; }
        public string AccountStatusID { get; set; }
        public double ClearBalance { get; set; }
        public double UnClearBalance { get; set; }
        public double UnSupervisedCredits { get; set; }
        public double UnSupervisedDebits { get; set; }
        public double FreezedAmount { get; set; }
        public double AvailableBalance { get; set; }
        public string OpenedDate { get; set; }
        public string OpenedBy { get; set; }
        public string ApprovedBy { get; set; }
    }


    //CONVERT(VARCHAR(11), CreatedOn, 106)  CreatedOn,	
    //CreatedBy

}