using CommonHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransportERP.Base
{
    public class BaseController : Controller
    {
        string dbconext = "";
        string currentSession = "";
        public string CurrentUserSession => "";
        public string ImageSave => Server.MapPath("~/Uploads");

        public string VideoSavePath => Server.MapPath("~/Uploads");
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string AuthToken = "";
            if (filterContext.ActionParameters.ContainsKey(Literals.APIToken) && filterContext.ActionParameters[Literals.APIToken] != null)
            {
               AuthToken = filterContext.ActionParameters[Literals.APIToken].ToString() ;
            }
            if (string.IsNullOrEmpty(AuthToken) && Request.Cookies[Literals.CookieToken] != null)
                AuthToken = Request.Cookies[Literals.CookieToken][Literals.APIToken];

            if (!string.IsNullOrEmpty(AuthToken))
            {
                //set current session variale here
            }
            base.OnActionExecuting(filterContext);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }
    }
}