using System;
using System.Linq;
using Dapper;
using System.Web.Mvc;
using Supreme_Mobile.Models;
using System.Data;
using Newtonsoft.Json;

namespace Supreme_Mobile.Controllers
{
    public class LoanController : Controller
    {
        IDbConnection _db = GeneralService.DapperConnection();
        GeneralService logger = new GeneralService();

        [HttpPost]
        public JsonResult FetchWFLoanList(WFParamsModel Smodel)
        {
            string errMessage = string.Empty;
            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(Smodel.TokenCode);
                try
                {                    
                    if (validation.Validated == true) { 
                        var AccListResult = _db.Query<WFLoanListModel>(";Exec Supreme_GetWorkflowLoan @Offset,@Records,@ADVStageID,@AppStatusID",
                            new
                            {
                                Offset = Smodel.Offset,
                                Records = Smodel.Records,
                                ADVStageID = Smodel.ADVStageID,
                                AppStatusID = Smodel.AppStatusID
                            }).ToList();

                        logger.LogWrite(JsonConvert.SerializeObject(Smodel).ToString());
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
        public JsonResult AddNewLoan(AddLoanModel loanmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(loanmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<LoanAppResultModel>(";Exec Supreme_LoanApplication @ClientID,@ProductID,@LoanAmount,@LoanTerm,@InterestRate,@LoanPeriodID,@PurposeCodeID,@CreditOfficerID,@OperatorID",
                        new
                        {
                            ClientID = loanmodel.ClientID,
                            ProductID = loanmodel.ProductID,
                            LoanAmount = loanmodel.LoanAmount,
                            LoanTerm = loanmodel.LoanTerm,
                            InterestRate = loanmodel.InterestRate,
                            LoanPeriodID = loanmodel.LoanPeriodID,
                            PurposeCodeID = loanmodel.PurposeCodeID,
                            CreditOfficerID = loanmodel.CreditOfficerID,
                            OperatorID = SecurityController.GetValidOperator(loanmodel.TokenCode).ToString()//loanmodel.OperatorID

                        }).SingleOrDefault();

                        logger.LogWrite(JsonConvert.SerializeObject(loanmodel).ToString());
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
        public JsonResult LoanSanction(SanctionLoanModel loanmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(loanmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<LoanAppResultModel>(";Exec Supreme_LoanSanction @ApplicationID,@ApprovedBy,@Remarks,@OperatorID",
                        new
                        {
                            ApplicationID = loanmodel.ApplicationID,
                            ApprovedBy = loanmodel.ApprovedBy,
                            Remarks = loanmodel.Remarks,
                            OperatorID = SecurityController.GetValidOperator(loanmodel.TokenCode).ToString()
                        }).SingleOrDefault();

                        logger.LogWrite(JsonConvert.SerializeObject(loanmodel).ToString());
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
        public JsonResult LoanBooking(BookingLoanModel loanmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(loanmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<LoanBookResultModel>(";Exec Supreme_LoanBooking @ApplicationID,@InstallmentDate,@OperatorID",
                        new
                        {
                            ApplicationID = loanmodel.ApplicationID,
                            InstallmentDate = loanmodel.InstallmentDate,
                            OperatorID = SecurityController.GetValidOperator(loanmodel.TokenCode).ToString()//loanmodel.OperatorID
                        }).SingleOrDefault();

                        logger.LogWrite(JsonConvert.SerializeObject(loanmodel).ToString());
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
        public JsonResult LoanDisbursement(DisbursementLoanModel loanmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(loanmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<LoanDisbResultModel>(";Exec Supreme_LoanDisbursement @ApplicationID,@Narration,@OperatorID",
                        new
                        {
                            ApplicationID = loanmodel.ApplicationID,
                            Narration = loanmodel.Narration,
                            OperatorID = SecurityController.GetValidOperator(loanmodel.TokenCode).ToString()//loanmodel.OperatorID
                        }).SingleOrDefault();

                        logger.LogWrite(JsonConvert.SerializeObject(loanmodel).ToString());
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
        public JsonResult FetchDisbursedLoanList(DisbursedListParamsModel Smodel)
        {
            string errMessage = string.Empty;
            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(Smodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<DisbursedLoanListModel>(";Exec Supreme_GetDisbursedLoan @Offset,@Records",
                            new
                            {
                                Offset = Smodel.Offset,
                                Records = Smodel.Records
                            }).ToList();

                        logger.LogWrite(JsonConvert.SerializeObject(Smodel).ToString());
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
        public JsonResult FetchLoanInstallment(InstallmentParamsModel Smodel)
        {
            string errMessage = string.Empty;
            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(Smodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<LoanInstallmentModel>(";Exec Supreme_GetLoanInstallment @AccountID,@LoanSeries",
                            new
                            {
                                AccountID = Smodel.AccountID,
                                LoanSeries = Smodel.LoanSeries
                            }).ToList();

                        logger.LogWrite(JsonConvert.SerializeObject(Smodel).ToString());
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
        public JsonResult FetchLoanDetails(LoanDetailsParamsModel Smodel)
        {
            string errMessage = string.Empty;
            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(Smodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<LoanDetailsModel>(";Exec Supreme_GetLoanDetails @OurBranchID,@AccountID,@LoanSeries",
                            new
                            {
                                OurBranchID = Smodel.OurBranchID,
                                AccountID = Smodel.AccountID,
                                LoanSeries = Smodel.LoanSeries
                            }).SingleOrDefault();

                        logger.LogWrite(JsonConvert.SerializeObject(Smodel).ToString());
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
        public JsonResult LoanRejection(RejectionLoanModel loanmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(loanmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<LoanAppResultModel>(";Exec Supreme_LoanRejection @ApplicationID,@Remarks,@OperatorID",
                        new
                        {
                            ApplicationID = loanmodel.ApplicationID,
                            Remarks = loanmodel.Remarks,
                            OperatorID = SecurityController.GetValidOperator(loanmodel.TokenCode).ToString()//loanmodel.OperatorID
                        }).SingleOrDefault();

                        logger.LogWrite(JsonConvert.SerializeObject(loanmodel).ToString());
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
        public JsonResult LoanProcessing(ProcessLoanModel loanmodel)
        {
            string errMessage = string.Empty;

            if (ModelState.IsValid)
            {
                var validation = SecurityController.ValidateToken(loanmodel.TokenCode);
                try
                {
                    if (validation.Validated == true)
                    {
                        var AccListResult = _db.Query<LoanProcessResultModel>(";Exec Supreme_ProcessNewLoan @ClientID,@ProductID,@LoanAmount,@LoanTerm,@InterestRate,@LoanPeriodID,@PurposeCodeID,@CreditOfficerID,@Remarks,@OperatorID",
                        new
                        {
                            ClientID = loanmodel.ClientID,
                            ProductID = loanmodel.ProductID,
                            LoanAmount = loanmodel.LoanAmount,
                            LoanTerm = loanmodel.LoanTerm,
                            InterestRate = loanmodel.InterestRate,
                            LoanPeriodID = loanmodel.LoanPeriodID,
                            PurposeCodeID = loanmodel.PurposeCodeID,
                            CreditOfficerID = loanmodel.CreditOfficerID,
                            Remarks = loanmodel.Remarks,
                            OperatorID = SecurityController.GetValidOperator(loanmodel.TokenCode).ToString()//loanmodel.OperatorID
                        }).SingleOrDefault();

                        logger.LogWrite(JsonConvert.SerializeObject(loanmodel).ToString());
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