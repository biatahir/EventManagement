using EventManagement.BusinessLogic.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Areas.API.Controllers
{
    public class SponsorsController : Controller
    {
        // GET: API/Sponsors

        public async Task<ActionResult> Index()
        {
            SponsorsLogic SponsorBusiness = new SponsorsLogic();
            return Json(new { data = await SponsorBusiness.GetSponsors() });
        }
        public ActionResult GetSponsorsForSpecificEvent(Int32? EventId)
        {
            SponsorsLogic SponsorBusiness = new SponsorsLogic();
            return Json(new { data = SponsorBusiness.GetSponsorsForSpecificEvent(EventId.HasValue ? EventId.Value : 1) }, JsonRequestBehavior.AllowGet);
        }
    }

}