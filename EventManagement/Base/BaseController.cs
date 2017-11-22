using CommonHelpers;
using EventManagement.BusinessLogic.Business;
using EventManagement.DataAccess.DataBase.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransportERP.Base
{
    public class BaseController : Controller
    {        
        UserSession _currentSession = null;
        public string ImageSavePath
        {
            get
            {
                string path = Server.MapPath(Helpers.GetAppSetting(Literals.AppSettingKey_ImagePath));
                if (Directory.Exists(path))
                {
                    return path;
                }else
                {
                    Directory.CreateDirectory(path);
                    return path;
                }
            }
        }

        public string VideoSavePath
        {
            get
            {
                string path = Server.MapPath(Helpers.GetAppSetting(Literals.AppSettingKey_VideoPath));
                if (Directory.Exists(path))
                {
                    return path;
                }
                else
                {
                    Directory.CreateDirectory(path);
                    return path;
                }
            }
        }
        public UserSession CurrentUserSession { get { return _currentSession; } }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string AuthToken = "";
            if (filterContext.ActionParameters.ContainsKey(Literals.APIToken) && filterContext.ActionParameters[Literals.APIToken] != null)
            {
                AuthToken = filterContext.ActionParameters[Literals.APIToken].ToString();
            }
            if (string.IsNullOrEmpty(AuthToken) && Request.Cookies[Literals.CookieToken] != null)
                AuthToken = Request.Cookies[Literals.CookieToken][Literals.APIToken];

            if (!string.IsNullOrEmpty(AuthToken))
            {
                AuthLogic authLogic = new AuthLogic();
                _currentSession = authLogic.CheckSession(AuthToken);
                //set current session variale here
            }
            base.OnActionExecuting(filterContext);
        }
    }
}