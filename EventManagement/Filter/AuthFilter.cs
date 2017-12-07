using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransportERP.Base;

namespace EventManagement.Filter
{
    public class AuthFilterAttribute : ActionFilterAttribute
    {
        public bool IsWebCall { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var baseController = (BaseController)filterContext.Controller;
            if (IsWebCall)
            {
                //write logic here
            }
            else if(baseController.CurrentUserSession == null)
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                filterContext.Result = new JsonResult { Data = new { error = "Access Denied" },JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            base.OnActionExecuting(filterContext);
        }
    }
}