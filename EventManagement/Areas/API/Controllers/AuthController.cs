using EventManagement.Base;
using EventManagement.BusinessLogic.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Areas.API.Controllers
{
    public class AuthController : BaseAPIController
    {
        // GET: API/Auth

        public ActionResult Login(string email, string password)
        {
            if(email == "nabiha" && password == "pass")
                return Json(new { Success = "Logged in success have auth token:122313" });
            else
                return Json(new { Success = "login faild no token for you" });
        }
        public ActionResult EmailVadilation(string email)
        {
            AuthLogic authLogic = new AuthLogic();
            var response = authLogic.EmailExist(email);
            return Json(response);
        }
        public ActionResult SaveImage(HttpPostedFileBase saveFile)
        {
            saveFile.SaveAs("");
            return Json("Succes");
        }
    }
}