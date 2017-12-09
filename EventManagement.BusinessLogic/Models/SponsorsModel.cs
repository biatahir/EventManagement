using EventManagement.Areas.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BusinessLogic.Models
{
    public class SponsorsModel : BaseModel
    {
        public List<SponsorsDTO> Data { get; set; }

        public SponsorsModel()
        {
            Data = new List<SponsorsDTO>();
        }

    }
}
