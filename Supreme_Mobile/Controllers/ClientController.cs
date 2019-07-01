using Supreme_Mobile.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using Dapper;
using Newtonsoft.Json;

namespace Supreme_Mobile.Controllers
{
    public class ClientController : Controller
    {
        System.Data.IDbConnection _db = GeneralService.DapperConnection();
        GeneralService logger = new GeneralService();

        [HttpPost]
        public JsonResult FetchClientDetails(ClientParamModel Accmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(Accmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<ClientDetailsModel>(";Exec Supreme_GetClientDetails @ClientID",
                        new
                        {
                            ClientID = Accmodel.ClientID
                        }).SingleOrDefault();

                        logger.LogWrite(JsonConvert.SerializeObject(Accmodel).ToString() + ":-"+JsonConvert.SerializeObject(AccListResult).ToString());
                        return Json(AccListResult, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        GenericResultModel AccListResult2 = new GenericResultModel();
                        AccListResult2.Status = "Fail";
                        AccListResult2.Remarks = validation.Errors[0].ToString();
                        logger.LogWrite(JsonConvert.SerializeObject(validation).ToString());
                        return Json(AccListResult2, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ee)
                {
                    GenericResultModel AccListResult2 = new GenericResultModel();
                    AccListResult2.Status = "Fail";
                    AccListResult2.Remarks = ee.Message;
                    GeneralService.WriteErrorLog(ref ee);
                    return Json(AccListResult2, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                GenericResultModel AccListResult2 = new GenericResultModel();
                AccListResult2.Status = "Fail";
                AccListResult2.Remarks = message;
                return Json(AccListResult2, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult FetchClientAccounts(ClientParamModel Accmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(Accmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<ClientAccountsModel>(";Exec Supreme_GetClientAccounts @ClientID",
                        new
                        {
                            ClientID = Accmodel.ClientID
                        }).ToList();

                        logger.LogWrite(JsonConvert.SerializeObject(Accmodel).ToString() + ":-" + JsonConvert.SerializeObject(AccListResult).ToString());
                        return Json(AccListResult, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        GenericResultModel AccListResult2 = new GenericResultModel();
                        AccListResult2.Status = "Fail";
                        AccListResult2.Remarks = validation.Errors[0].ToString();
                        logger.LogWrite(JsonConvert.SerializeObject(validation).ToString());
                        return Json(AccListResult2, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ee)
                {
                    GenericResultModel AccListResult2 = new GenericResultModel();
                    AccListResult2.Status = "Fail";
                    AccListResult2.Remarks = ee.Message;
                    GeneralService.WriteErrorLog(ref ee);
                    return Json(AccListResult2, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                GenericResultModel AccListResult2 = new GenericResultModel();
                AccListResult2.Status = "Fail";
                AccListResult2.Remarks = message;
                return Json(AccListResult2, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult FetchClientList(ClientSearchModel Smodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(Smodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<ClientListModel>(";Exec Supreme_SearchClientListing @Offset,@SearchTypeID,@SearchStatement",
                                new
                                {
                                    Offset = Smodel.Offset,
                                    SearchTypeID = Smodel.SearchTypeID,
                                    SearchStatement = Smodel.SearchStatement
                                }).ToList();

                        logger.LogWrite(JsonConvert.SerializeObject(Smodel).ToString() + ":-" + JsonConvert.SerializeObject(AccListResult).ToString());

                        return Json(AccListResult, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        GenericResultModel AccListResult2 = new GenericResultModel();
                        AccListResult2.Status = "Fail";
                        AccListResult2.Remarks = validation.Errors[0].ToString();
                        logger.LogWrite(JsonConvert.SerializeObject(validation).ToString());
                        return Json(AccListResult2, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ee)
                {
                    GenericResultModel AccListResult2 = new GenericResultModel();
                    AccListResult2.Status = "Fail";
                    AccListResult2.Remarks = ee.Message;
                    GeneralService.WriteErrorLog(ref ee);
                    return Json(AccListResult2, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                GenericResultModel AccListResult2 = new GenericResultModel();
                AccListResult2.Status = "Fail";
                AccListResult2.Remarks = message;
                return Json(AccListResult2, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddNewClient(AddClientModel clientmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(clientmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<ClientResultModel>(";Exec Supreme_AddNewClient @ClientTypeID,@TitleID,@FirstName,@MiddleName,@LastName,@GenderID,@DateOfBirth,@IDTypeID,@IDNumber, @CountryID, @CityID, @Address, @ZipCodeID, @Mobile, @EmailAddress, @Phone1,@OperatorID",
                                new
                                {
                                    ClientTypeID = clientmodel.ClientTypeID,
                                    TitleID = clientmodel.TitleID,
                                    FirstName = clientmodel.FirstName,
                                    MiddleName = clientmodel.MiddleName,
                                    LastName = clientmodel.LastName,
                                    GenderID = clientmodel.GenderID,
                                    DateOfBirth = clientmodel.DateOfBirth,
                                    IDTypeID = clientmodel.IDTypeID,
                                    IDNumber = clientmodel.IDNumber,
                                    CountryID = clientmodel.CountryID,
                                    CityID = clientmodel.CityID,
                                    Address = clientmodel.Address,
                                    ZipCodeID = clientmodel.ZipCodeID,
                                    Mobile = clientmodel.Mobile,
                                    EmailAddress = clientmodel.EmailAddress,
                                    Phone1 = clientmodel.Phone1,
                                    OperatorID = SecurityController.GetValidOperator(clientmodel.TokenCode).ToString()
                                }).SingleOrDefault();

                        logger.LogWrite(JsonConvert.SerializeObject(clientmodel).ToString() + ":-" + JsonConvert.SerializeObject(AccListResult).ToString());
                        return Json(AccListResult, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        GenericResultModel AccListResult2 = new GenericResultModel();
                        AccListResult2.Status = "Fail";
                        AccListResult2.Remarks = validation.Errors[0].ToString();
                        logger.LogWrite(JsonConvert.SerializeObject(validation).ToString());
                        return Json(AccListResult2, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ee)
                {
                    GenericResultModel AccListResult2 = new GenericResultModel();
                    AccListResult2.Status = "Fail";
                    AccListResult2.Remarks = ee.Message;
                    GeneralService.WriteErrorLog(ref ee);
                    return Json(AccListResult2, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));

                GenericResultModel AccListResult2 = new GenericResultModel();
                AccListResult2.Status = "Fail";
                AccListResult2.Remarks = message;
                return Json(AccListResult2, JsonRequestBehavior.AllowGet);
            }
        }
    }
}