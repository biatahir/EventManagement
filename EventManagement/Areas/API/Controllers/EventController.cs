using EventManagement.Base;
using EventManagement.BusinessLogic.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Areas.API.Controllers
{
    public class EventController : BaseAPIController
    {
        // GET: API/Event
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ActivitiesByEvent(string Token, int eventId)
        {
            EventLogic logic = new EventLogic();
            var data = await logic.ActivitiesByEvent(CurrentUserSession.AttendesID.Value, eventId);
            return Json(new { Data = data });
        }
    }
}