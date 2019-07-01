using Dapper;
using Newtonsoft.Json;
using Supreme_Mobile.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Supreme_Mobile.Controllers
{
    public class TransactionController : Controller
    {
        System.Data.IDbConnection _db = GeneralService.DapperConnection();
        GeneralService logger = new GeneralService();

        [HttpPost]
        public ActionResult FetchCashTrxList(TrxModel tModel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(tModel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<CashTrxListModel>(";Exec Supreme_GetCashTrxList @OurBranchID,@Offset",
                        new
                        {
                            OurBranchID = tModel.OurBranchID,
                            Offset = tModel.Offset
                        }).ToList();

                        logger.LogWrite(JsonConvert.SerializeObject(tModel).ToString());
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
        public ActionResult FetchTransferTrxList(TrxModel tModel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(tModel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<TrfTrxListModel>(";Exec Supreme_GetTransferTrxList @OurBranchID,@Offset",
                        new
                        {
                            OurBranchID = tModel.OurBranchID,
                            Offset = tModel.Offset
                        }).ToList();

                        logger.LogWrite(JsonConvert.SerializeObject(tModel).ToString());
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
        public JsonResult AddTransferTrx(TransferTrxAddModel addTrfTrxmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(addTrfTrxmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<TrfResultModel>(";Exec Supreme_AddTransferTrx @DRAccountTypeID, @CRAccountTypeID, @DRAccountID, @CRAccountID, @TrxAmount, @Narration, @RefNumber,@OperatorID",
                    new
                    {
                        DRAccountTypeID = addTrfTrxmodel.DRAccountTypeID,
                        CRAccountTypeID = addTrfTrxmodel.CRAccountTypeID,
                        DRAccountID = addTrfTrxmodel.DRAccountID,
                        CRAccountID = addTrfTrxmodel.CRAccountID,
                        TrxAmount = addTrfTrxmodel.TrxAmount,
                        Narration = addTrfTrxmodel.Narration,
                        RefNumber = addTrfTrxmodel.RefNumber,
                        OperatorID = SecurityController.GetValidOperator(addTrfTrxmodel.TokenCode).ToString()
                    }).SingleOrDefault();

                        logger.LogWrite(JsonConvert.SerializeObject(addTrfTrxmodel).ToString());
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
        public JsonResult AddCashTrx(CashTrxAddModel addcashTrxmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(addcashTrxmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<TrfResultModel>(";Exec Supreme_AddCashTrx @AccountTypeID, @AccountID, @TrxAmount, @Narration, @RefNumber,@OperatorID,@TrxTypeID",
                    new
                    {                        
                        AccountTypeID = addcashTrxmodel.AccountTypeID,
                        AccountID = addcashTrxmodel.AccountID,
                        TrxAmount = addcashTrxmodel.TrxAmount,
                        Narration = addcashTrxmodel.Narration,
                        RefNumber = addcashTrxmodel.RefNumber,
                        OperatorID = SecurityController.GetValidOperator(addcashTrxmodel.TokenCode).ToString(),
                        TrxTypeID = addcashTrxmodel.TrxTypeID
                    }).SingleOrDefault();

                        logger.LogWrite(JsonConvert.SerializeObject(addcashTrxmodel).ToString());
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
    }
}