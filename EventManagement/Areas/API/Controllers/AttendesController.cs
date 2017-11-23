using EventManagement.Base;
using EventManagement.BusinessLogic.Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Areas.API.Controllers
{
    public class AttendesController : BaseAPIController
    {

        // GET: API/Attendes
        public async Task<ActionResult> Index()
        {
            AttendesLogic attendesBusiness = new AttendesLogic();
            return Json(new { data = await attendesBusiness.GetAttendes() });
        }
        public ActionResult UploadAttendeeImage(HttpPostedFileBase image)
        {
            if (image != null)
            {
                var path = Path.Combine(ImageSavePath, image.FileName);
                image.SaveAs(path);
                return Json(new { Data = "Image upload Successfuly" });
            }
            return Json(new { Data = "Image Upload Failed" });
        }
        public ActionResult UploadAttendeeVideo(HttpPostedFileBase video)
        {
            if (video !=null)
            {
                var path = Path.Combine(VideoSavePath, video.FileName);
                    video.SaveAs(path);
                return Json(new { Data = "video Uploaded  Successfully"});
            }
            return Json(new { Data = "video Uploaded  Failed" });
        }
    }
}