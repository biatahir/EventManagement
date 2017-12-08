﻿using EventManagement.BusinessLogic.BussinessBase;
using EventManagement.DataAccess.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EventManagement.BusinessLogic.Models;
using EventManagement.BusinessLogic.Models.AttendeesByEventId;
using System.Net;

namespace EventManagement.BusinessLogic.Business
{
    public class AttendesLogic : BaseLogic
    {
        public async Task<List<AttendesDTO>> GetAttendes()
        {
            return await Db.Attendes.Select(x => new AttendesDTO
            {
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
        public List<AttendesDTO> GetAttendeeForSpecificEvent(Int32 EventId)
        {
            List<AttendesDTO> Data = (from a in Db.Attendes
                                      join ae in Db.AttendesEvents on a.ID equals ae.AttendesID
                                      join e in Db.Events on ae.EventID equals e.ID
                                      where e.ID == EventId
                                      select a).ToList().AsEnumerable().Select(x => new AttendesDTO
                                      {
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
                                      }).ToList();
            return Data.Distinct().ToList();
        }
        public List<AttendesDTO> GetAttendeByID()
        {
            AttendeesByEventID AttendeById = new AttendeesByEventID();
            if (AttendeById != null)
            {
              
                AttendeById.Status = HttpStatusCode.OK;
                AttendeById.Message = "Successful" ;
            }
            else
            {
                AttendeById.Status = HttpStatusCode.BadRequest;
                AttendeById.Message = "Failed";
            }
            return json(new { data = AttendeById });
        }
    }
}





