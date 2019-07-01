using System;
using System.Linq;
using Dapper;
using System.Web.Mvc;
using Supreme_Mobile.Models;
using System.Data;
using Newtonsoft.Json;

namespace Supreme_Mobile.Controllers
{
    public class AccountController : Controller
    {
        IDbConnection _db = GeneralService.DapperConnection();
        GeneralService logger = new GeneralService();

        [HttpPost]
        public JsonResult FetchTransAccountList(AccountSearchModel Smodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(Smodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<AccountListModel>(";Exec Supreme_AccountTransListing @Offset,@SearchTypeID,@SearchStatement",
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
        public JsonResult FetchAccountList(AccountSearchModel Smodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(Smodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<AccountListModel>(";Exec Supreme_AccountListing @Offset,@SearchTypeID,@SearchStatement",
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

            //return Json(UserListResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult FetchAccountDetails(AccountModel Accmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(Accmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<AccountDetailModel>(";Exec Supreme_GetAccountDetails @AccountID",
                        new
                        {
                            AccountID = Accmodel.AccountID
                        }).SingleOrDefault();

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
        public JsonResult FetchAccountTransactions(AccountTrxParamsModel Accmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(Accmodel.TokenCode);
                try
                {        
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<AccountTransactionsModel>(";Exec Supreme_GetAccountTransactions @Offset,@Records,@OurBranchID,@AccountID",
                        new
                        {
                            Offset = Accmodel.Offset,
                            Records = Accmodel.Offset,
                            OurBranchID = Accmodel.OurBranchID,
                            AccountID = Accmodel.AccountID
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
        public JsonResult FetchAccountStatement(AccountStmParamsModel Accmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(Accmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<AccountStatementModel>(";Exec Supreme_GetAccountTransactions @OurBranchID,@AccountID,@FromDate,@ToDate,@OperatorID",
                        new
                        {
                            OurBranchID = Accmodel.OurBranchID,
                            AccountID = Accmodel.AccountID,
                            FromDate = Accmodel.FromDate,
                            ToDate = Accmodel.ToDate,
                            OperatorID = SecurityController.GetValidOperator(Accmodel.TokenCode).ToString()
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
        public JsonResult AddNewAccount(AddAccountModel accountmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(accountmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<AccountResultModel>(";Exec Supreme_AddNewAccount @ClientID,@AccountName,@ProductID,@Address,@CityID,@CountryID,@Mobile,@OperatingModeID,@OperatorID",
                        new
                        {
                            ClientID = accountmodel.ClientID,
                            AccountName = accountmodel.AccountName,
                            ProductID = accountmodel.ProductID,
                            Address = accountmodel.Address,
                            CityID = accountmodel.CityID,
                            CountryID = accountmodel.CountryID,
                            Mobile = accountmodel.Mobile,
                            OperatingModeID = accountmodel.OperatingModeID,
                            OperatorID = SecurityController.GetValidOperator(accountmodel.TokenCode).ToString()

                        }).SingleOrDefault();

                        logger.LogWrite(JsonConvert.SerializeObject(accountmodel).ToString() + ":-" + JsonConvert.SerializeObject(AccListResult).ToString());

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