using CommonHelpers;
using EventManagement.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportERP.Base;

namespace EventManagement.Base
{
    public class BaseAPIController : BaseController
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Helpers.LogError("API Error: ", filterContext.Exception);
            var apiexception = filterContext.Exception as APIException;
            filterContext.Result = new JsonResult
            {
                Data = new { error = "sorry, an occured while processing your request." }
                ,JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            filterContext.ExceptionHandled = true;
            base.OnException(filterContext);
        }
    }
}