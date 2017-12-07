using EventManagement.Base;
using EventManagement.BusinessLogic.Business;
using EventManagement.BusinessLogic.Models;
using Newtonsoft.Json.Linq;
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

        [HttpPost]
        public ActionResult UploadAttendeeImage(string FileName, string FileExtensions)
        {
            Stream PostedStream = this.Request.InputStream;
            if (PostedStream != null)
            {
                string _sPostedString = new StreamReader(PostedStream).ReadToEnd();
                if (_sPostedString != null && _sPostedString.Trim().Length > 0)
                {
                    var jsonimg = JObject.Parse(_sPostedString);
                    if (jsonimg != null)
                    {
                        byte[] image = Convert.FromBase64String(jsonimg["image"].ToString().Trim());
                        if (image != null && image.Length > 0)
                        {
                            var path = Path.Combine(ImageSavePath, FileName + "." + FileExtensions);
                            if (!System.IO.File.Exists(path))
                            {
                                FileStream fstream = new FileStream(path, FileMode.Create);
                                fstream.Write(image, 0, image.Length);
                                fstream.Close();
                                fstream.Dispose();
                                return Json(new { Data = "Image upload Successfuly" });
                            }
                            else
                            {
                                return Json(new { Data = "Image File Already Exists" });
                            }
                        }
                    }
                }
            }
            return Json(new { Data = "Image Upload Failed" });
        }

        [HttpGet]
        public ActionResult GetAttendeeForSpecificEvent(Int32? EventId)
        {
            AttendesLogic attendesBusiness = new AttendesLogic();
            return Json(new { data = attendesBusiness.GetAttendeeForSpecificEvent(EventId.HasValue ? EventId.Value : 1) }, JsonRequestBehavior.AllowGet);
        }
    }
}