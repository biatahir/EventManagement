using EventManagement.Areas.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BusinessLogic.Models.AttendeesByEventId
{
    public class AttendeesModel : BaseModel
    {
        public List<AttendesDTO> Data { get; set; }

        public AttendeesModel()
        {
            Data = new List<AttendesDTO>();
        }

    }
}
