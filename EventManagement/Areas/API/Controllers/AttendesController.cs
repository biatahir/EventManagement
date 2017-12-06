using EventManagement.BusinessLogic.Business;
using EventManagement.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Areas.API.Controllers
{
    public class AttendesController : Controller
    {

        // GET: API/Attendes
        public async Task<ActionResult> Index()
        {
            AttendesLogic attendesBusiness = new AttendesLogic();
            return Json(new { data = await attendesBusiness.GetAttendes() });
        }

        [HttpGet]
        public ActionResult GetAttendeeForSpecificEvent(Int32? EventId)
        {
            AttendesLogic attendesBusiness = new AttendesLogic();
            return Json(new { data = attendesBusiness.GetAttendeeForSpecificEvent(EventId.HasValue ? EventId.Value : 1) }, JsonRequestBehavior.AllowGet);
        }
    }
}