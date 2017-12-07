using EventManagement.BusinessLogic.BussinessBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EventManagement.DataAccess.DataBase.Model;

namespace EventManagement.BusinessLogic.Business
{
   public class EventLogic : BaseLogic
    {
        public async Task<List<Activite>> ActivitiesByEvent(int attendeeId,int eventId)
        { 
            var attendeeEvent = await Db.Events.
                FindAsync(eventId);
            var activities = Db.BookMarks.Where(x => x.AttendesID == attendeeId).Select(x => x.ActivityID).ToArray();
            return attendeeEvent.Activites.Where(x=>activities.Contains(x.ID)).ToList();
        }
    }
}
