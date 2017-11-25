using EventManagement.BusinessLogic.BussinessBase;
using EventManagement.DataAccess.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EventManagement.BusinessLogic.Models;

namespace EventManagement.BusinessLogic.Business
{
   public class AttendesLogic:BaseLogic
    {
   
        public async Task<List<AttendesDTO>> GetAttendes() {
           
            return await Db.Attendes.Select(x=>new AttendesDTO {
                 ID = x.ID,
                  AddedBY = x.AddedBY,
                   AddedON = x.AddedON, 
                   Description = x.Description,
                   DeviceToken = x.DeviceToken,
                   FacebookURL = x.FacebookURL,
                   InstagramURL = x.InstagramURL,
                   Name = x.Name,
                   Status = x.Status,
                   Thumbnail = x.Thumbnail,
                   TwitterURL = x.TwitterURL,               
            }).ToListAsync();
        }
    }
}
