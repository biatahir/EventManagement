using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BusinessLogic.Models
{
   public class SponsorsDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string DocURL { get; set; }
        public Nullable<bool> Status { get; set; }
        public string Name { get; set; }

    }
}
