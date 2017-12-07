﻿using EventManagement.BusinessLogic.BussinessBase;
using EventManagement.DataAccess.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BusinessLogic.Business
{
   public class QRCodeLogic:BaseLogic
    {
        public async Task<object> RecordQRCodeScanHistory(int attendeeId,int qrId)
        {
            Db.QRHistories.Add(new QRHistory
            {
                AttendesID = attendeeId,
                QRid = qrId,
            });
            await Db.SaveChangesAsync();
            return new { Message = "Success" };
        }
    }
}
