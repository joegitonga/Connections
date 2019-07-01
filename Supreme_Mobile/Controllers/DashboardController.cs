using Dapper;
using Supreme_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Supreme_Mobile.Controllers
{
    public class DashboardController : Controller
    {
        System.Data.IDbConnection _db = Supreme_Mobile.Models.GeneralService.DapperConnection();

        [HttpPost]
        public JsonResult CashMovement(MovementParamModel sysmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(sysmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var SysListResult = _db.Query<MovementModel>(";Exec Supreme_DashCashMovement @Offset", new { Offset = sysmodel.Offset }).ToList();

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
        public JsonResult Disbursement(MovementParamModel sysmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(sysmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var SysListResult = _db.Query<DisbursmentModel>(";Exec Supreme_DashDisbursement @Offset", new { Offset = sysmodel.Offset }).ToList();

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
        public JsonResult TillBalance(TillBalParamModel sysmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(sysmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var SysListResult = _db.Query<TillBalanceModel>(";Exec Supreme_DashTillBalance @OurBranchID", new { OurBranchID = sysmodel.OurBranchID }).ToList();

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