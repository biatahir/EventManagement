using EventManagement.Areas.API.Models.Authentication;
using EventManagement.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EventManagement.Areas.API.Controllers
{
    public class AuthController : BaseAPIController
    {
        // GET: API/Auth
        public ActionResult Login(string email, string passowrd)
        {
            if (email == "nabiha" && passowrd == "pass")
                return Json(new { Success = "Logged in success have auth token:122313" });
            else
                return Json(new { Success = "login faild no token for you" });
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult VerifyEmail()
        {
            AuthenticationModel RetVal = new AuthenticationModel();
            string _sPostedata = new StreamReader(this.Request.InputStream).ReadToEnd();
            if (_sPostedata != null && _sPostedata.Trim().Length > 0)
            {
                AuthenticationModel ParsedData = new JavaScriptSerializer().Deserialize<AuthenticationModel>(_sPostedata);
                if (ParsedData != null)
                {   
                    if (ParsedData.Email == "nabiha@adad.com")
                    {
                        RetVal.Status = HttpStatusCode.OK;
                        RetVal.Message = "Email Verified";
                    }
                    else
                    {
                        RetVal.Status = HttpStatusCode.BadRequest;
                        RetVal.Message = "login faild no token for you";
                    }
                }
                else
                {
                    RetVal.Status = HttpStatusCode.BadRequest;
                    RetVal.Message = "Invalid Data";
                }
            }
            else
            {
                RetVal.Status = HttpStatusCode.BadRequest;
                RetVal.Message = "Empty Data";
            }
            return Json(RetVal);
        }
        public ActionResult VerifyPassword()
        {
            AuthenticationModel RetVal = new AuthenticationModel();
            string _sPostedata = new StreamReader(this.Request.InputStream).ReadToEnd();
            if (_sPostedata != null && _sPostedata.Trim().Length > 0)
            {
                AuthenticationModel ParsedData = new JavaScriptSerializer().Deserialize<AuthenticationModel>(_sPostedata);
                if (ParsedData != null)
                {
                    if (ParsedData.Email == "nabiha@adad.com" && ParsedData.Password == "Password123")
                    {
                        RetVal.Status = HttpStatusCode.OK;
                        RetVal.Message = "Email Verified and Pasword veroified";
                    }
                    else
                    {
                        RetVal.Status = HttpStatusCode.BadRequest;
                        RetVal.Message = "login faild no token for you";
                    }
                }
                else
                {
                    RetVal.Status = HttpStatusCode.BadRequest;
                    RetVal.Message = "Invalid Data";
                }
            }
            else
            {
                RetVal.Status = HttpStatusCode.BadRequest;
                RetVal.Message = "Empty Data";
            }
            return Json(RetVal);
        }
        public ActionResult VerifyCode()
        {
            AuthenticationModel RetVal = new AuthenticationModel();
            string _sPostedata = new StreamReader(this.Request.InputStream).ReadToEnd();
            if (_sPostedata != null && _sPostedata.Trim().Length > 0)
            {
                AuthenticationModel ParsedData = new JavaScriptSerializer().Deserialize<AuthenticationModel>(_sPostedata);
                if (ParsedData != null)
                {
                    if (ParsedData.Email == "nabiha@adad.com" && ParsedData.Code == "1234")
                    {
                        RetVal.Status = HttpStatusCode.OK;
                        RetVal.Message = "Email Verified and Code Verified";
                    }
                    else
                    {
                        RetVal.Status = HttpStatusCode.BadRequest;
                        RetVal.Message = "login faild no token for you";
                    }
                }
                else
                {
                    RetVal.Status = HttpStatusCode.BadRequest;
                    RetVal.Message = "Invalid Data";
                }
            }
            else
            {
                RetVal.Status = HttpStatusCode.BadRequest;
                RetVal.Message = "Empty Data";
            }
            return Json(RetVal);
        }

        public ActionResult SaveImage(HttpPostedFileBase saveFile)
        {
            saveFile.SaveAs("");
            return Json("Succes");
        }
    }
}