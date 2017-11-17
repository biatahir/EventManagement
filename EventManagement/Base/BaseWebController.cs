using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransportERP.Base;

namespace EventManagement.Base
{
    public class BaseWebController : BaseController
    {
        // GET: BaseWeb
        public ActionResult Index()
        {
            return View();
        }
    }
}