using EventManagement.Base;
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

        public ActionResult Login(string email, string passowrd)
        {
            if(email == "nabiha" && passowrd == "pass")
                return Json(new { Success = "Logged in success have auth token:122313" });
            else
                return Json(new { Success = "login faild no token for you" });
        }
        public ActionResult SaveImage(HttpPostedFileBase saveFile)
        {
            saveFile.SaveAs("");
            return Json("Succes");
        }
    }
}