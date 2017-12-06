using EventManagement.BusinessLogic.BussinessBase;
using EventManagement.BusinessLogic.Models;
using EventManagement.DataAccess.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BusinessLogic.Business
{
    public class SponsorsLogic : BaseLogic
    {
        public async Task<List<SponsorsDTO>> GetSponsors()
        {
            return await Db.Sponsors.Select(x => new SponsorsDTO
            {
                Description = x.Description,
                DocURL = x.DocURL,
                ID = x.ID,
                Name = x.Name,
                Status = x.Status,
                Thumbnail = x.Thumbnail,
            }).ToListAsync();

        }

        public List<SponsorsDTO> GetSponsorsForSpecificEvent(Int32 EventId)
        {
            List<SponsorsDTO> Data = (from a in Db.Sponsors
                                      join ae in Db.SponsorsEvents on a.ID equals ae.SponsorID
                                      join e in Db.Events on ae.EventID equals e.ID
                                      where e.ID == EventId
                                      select a).ToList().AsEnumerable().Select(x => new SponsorsDTO
                                      {
                                          Description = x.Description,
                                         DocURL = x.DocURL,
                                          ID = x.ID,
                                          Name = x.Name,
                                          Status = x.Status,
                                          Thumbnail = x.Thumbnail,
                                      }).ToList();
            return Data.Distinct().ToList();
        }
    }
}

