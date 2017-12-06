using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace EventManagement.Areas.API.Models
{
    public class BaseModel
    {
        public HttpStatusCode Status { get; set; }
        public string Message { get; set; }

        public BaseModel()
        {
            Status = HttpStatusCode.OK;
            Message = string.Empty;
        }
    }
}