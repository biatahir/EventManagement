using EventManagement.BusinessLogic.BussinessBase;
using EventManagement.DataAccess.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.BusinessLogic.Business
{
    public class AuthLogic: BaseLogic
    {
        #region webcode 
        public void webmethod()
        {
            
        }
        #endregion 

        #region api code
        public void AttendiLogic(string email,string password)
        {

        }  
        public UserSession CheckSession(string Token)
        {
            return Db.UserSessions.FirstOrDefault(x => x.AuthToken == Token);
        }  
        public object ForgotPassowrd(string email)
        {
            var user =Db.Attendes.FirstOrDefault(x => x.Email == email);
            if (user == null)
                throw new APIException("user does not exist.");
            else
                //forgot password logic here
            return null;
        }
        #endregion 
    }
}
