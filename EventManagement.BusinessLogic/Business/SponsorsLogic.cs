using EventManagement.BusinessLogic.BussinessBase;
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
        public async Task<List<Sponsor>> GetSponsors()
        {
            //test 2
            return await Db.Sponsors.ToListAsync();
        }
    }
}
