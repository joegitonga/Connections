using Dapper;
using Newtonsoft.Json;
using Supreme_Mobile.Managers;
using Supreme_Mobile.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace Supreme_Mobile.Controllers
{
    public class SecurityController : Controller
    {
        private const string ResetPasswordTokenPurpose = "RP";
        private const string ConfirmLoginTokenPurpose = "LC";//change here change bit length for reason  section (2 per char)
        
        private const string _alg = "HmacSHA256";
        private const string _salt = "2eplSzM8CXnXyNAvRJ7j";
        GeneralService logger = new GeneralService();

        System.Data.IDbConnection _db = GeneralService.DapperConnection();

        [HttpPost]
        public JsonResult CreateAPIUser(NewUsersModel nUsermodel)
        {
            try
            {
                var newUserResult = _db.Query<CreatedUserResultModel>(";Exec Supreme_InsertUser @UserName,@Password,@CompanyName,@Address,@CreatedBy",
                    new
                    {
                        UserName = nUsermodel.UserName,
                        Password = GetHashedPassword(nUsermodel.Password),
                        CompanyName = nUsermodel.CompanyName,
                        Address = nUsermodel.Address,
                        CreatedBy = nUsermodel.CreatedBy
                    }).SingleOrDefault();

                nUsermodel.Password = string.Empty;
                logger.LogWrite(JsonConvert.SerializeObject(nUsermodel).ToString());
                return Json(newUserResult, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public JsonResult APILogin(MyUsersModel Tokenmodel)
        {
            try
            {
                var loginResult = _db.Query<MyUserResultModel>(";Exec Supreme_AuthenticateUser @UserName,@Password",
                new
                {
                    UserName = Tokenmodel.UserName,
                    Password = GetHashedPassword(Tokenmodel.Password)
                }).SingleOrDefault();

                Tokenmodel.UserID = loginResult.UserID;
                Tokenmodel.SecurityStamp = Guid.NewGuid().ToString();

                var token = Managers.TokenManager.GenerateToken(ConfirmLoginTokenPurpose, Tokenmodel);

                _db.Query(";Exec Supreme_UpdateUserToken @UserID,@TokenID,@SecurityStamp",
                    new
                    {
                        UserID = Tokenmodel.UserID,
                        TokenID = token,
                        SecurityStamp = Tokenmodel.SecurityStamp
                    });

                MyTokenResultModel tokenResult = new MyTokenResultModel();
                tokenResult.tokenAuth = token;

                Tokenmodel.Password = string.Empty;
                logger.LogWrite(JsonConvert.SerializeObject(Tokenmodel).ToString());
                return Json(tokenResult, JsonRequestBehavior.AllowGet);
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

        public static TokenValidation ValidateToken(string validToken)
        {
            try
            {
                System.Data.IDbConnection _Mydb = Supreme_Mobile.Models.GeneralService.DapperConnection();
                var loginResult = _Mydb.Query<ValidTokenResultModel>(";Exec Supreme_AuthenticateToken @TokenID",
                    new
                    {
                        TokenID = validToken
                    }).SingleOrDefault();

                MyUsersModel userModel = new MyUsersModel();
                userModel.UserID = loginResult.UserID;
                userModel.UserName = loginResult.UserName;
                userModel.SecurityStamp = loginResult.SecurityStamp;

                GeneralService logger = new GeneralService();
                logger.LogWrite("Token: "+ validToken+" - "+JsonConvert.SerializeObject(userModel).ToString());
                var validation = TokenManager.ValidateToken(ConfirmLoginTokenPurpose, userModel, validToken);

                return validation;
            }
            catch (Exception ee)
            {
                var result = new TokenValidation();
                result.Errors.Add(TokenValidationStatus.Expired);
                GeneralService.WriteErrorLog(ref ee);
                return result;
            }
        }

        public static string GetValidOperator(string validToken)
        {
            return TokenManager.GetValidOperatorID(ConfirmLoginTokenPurpose,validToken);
            
        }

        /// <summary>
        /// Returns a hashed password + salt, to be used in generating a token.
        /// </summary>
        /// <param name="password">string - user's password</param>
        /// <returns>string - hashed password</returns>

        public static string GetHashedPassword(string password)
        {
            string key = string.Join(":", new string[] { password, _salt });

            using (HMAC hmac = HMACSHA256.Create(_alg))
            {
                // Hash the key.
                hmac.Key = Encoding.UTF8.GetBytes(_salt);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(key));

                return Convert.ToBase64String(hmac.Hash);
            }
        }
    }
}