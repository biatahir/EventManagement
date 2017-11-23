using EventManagement.Base;
using EventManagement.BusinessLogic.Business;
using EventManagement.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EventManagement.Areas.API.Controllers
{
    public class QRCodesController : BaseAPIController
    {
        // GET: API/QRCodes
        [AuthFilter]
        public async Task<ActionResult> GetQRCodeData(string Token, int QRCodeId)
        {
            QRCodeLogic businessLogic = new QRCodeLogic();
            var response = await businessLogic.RecordQRCodeScanHistory(CurrentUserSession.AttendesID.Value, QRCodeId);
            return Json(response);
        }
    }
}