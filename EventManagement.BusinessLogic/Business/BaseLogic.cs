using EventManagement.DataAccess.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace EventManagement.BusinessLogic.BussinessBase
{
    public class BaseLogic : IDisposable
    {
        Event_ManagementEntities _dbContext;
        public Event_ManagementEntities Db { get {
                if (_dbContext == null)
                    return _dbContext = new Event_ManagementEntities();
                else
                    return _dbContext;
            }  }
        public void Dispose()
        {
            this.Dispose();
        }
    }
}
