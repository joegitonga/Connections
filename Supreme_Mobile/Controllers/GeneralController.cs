using Dapper;
using Newtonsoft.Json;
using Supreme_Mobile.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Supreme_Mobile.Controllers
{
    public class GeneralController : Controller
    {
        System.Data.IDbConnection _db = GeneralService.DapperConnection();
        GeneralService logger = new GeneralService();

        [HttpPost]
        public JsonResult FetchAccountSearchTypes(OffsetModel offmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(offmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<SubCodeModel>(";Exec Supreme_getAccountSearchTypes").ToList();

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
                logger.LogWrite(message);
                return Json(AccListResult2, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult FetchClientSearchTypes(OffsetModel offmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(offmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        //var AccListResult = _db.Query<AccountListModel>("Supreme_AccountListing",commandType: CommandType.StoredProcedure).ToList();
                        var AccListResult = _db.Query<SubCodeModel>(";Exec Supreme_getClientSearchTypes").ToList();

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
                logger.LogWrite(message);
                return Json(AccListResult2, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult FetchClientTypes(OffsetModel offmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(offmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<SubCodeModel>(";Exec Supreme_getClientTypes").ToList();

                        return Json(AccListResult, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        GenericResultModel AccListResult2 = new GenericResultModel();
                        AccListResult2.Status = "Fail";
                        AccListResult2.Remarks = validation.Errors[0].ToString();
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
        public JsonResult PingPort(SysCodeModel sysmodel)
        {
            GenericResultModel AccListResult2 = new GenericResultModel();
            AccListResult2.Status = "SUCESS";
            AccListResult2.Remarks = "SUCESS";
            return Json(AccListResult2, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public JsonResult FetchSystemCodes(SysCodeModel sysmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(sysmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var SysListResult = _db.Query<SysCodeDetailModel>(";Exec Supreme_getSystemCodes @SubCodeID", new { SubCodeID = sysmodel.SubCodeID, }).ToList();

                        return Json(SysListResult, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        GenericResultModel AccListResult2 = new GenericResultModel();
                        AccListResult2.Status = "Fail";
                        AccListResult2.Remarks = validation.Errors[0].ToString();
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

        public static string GetIP(HttpRequestBase request)
        {
            string ip = request.Headers["X-Forwarded-For"]; // AWS compatibility

            if (string.IsNullOrEmpty(ip))
            {
                ip = request.UserHostAddress;
            }

            return ip;
        }
    }
}