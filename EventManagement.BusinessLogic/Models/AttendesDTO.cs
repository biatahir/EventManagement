using EventManagement.Areas.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BusinessLogic.Models
{
    public class AttendesDTO : BaseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string InstagramURL { get; set; }
        public Nullable<System.DateTime> AddedON { get; set; }
        public Nullable<int> AddedBY { get; set; }
        public Nullable<bool> Status { get; set; }
        public string DeviceToken { get; set; }
        public List<AttendeMessage> AttendeMessages { get; set; }
    }
    public class AttendeMessage
    {
        public string Message { get; set; }
    }
}
