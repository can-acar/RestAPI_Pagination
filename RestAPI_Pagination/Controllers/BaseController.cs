using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace RestAPI_Pagination.Controllers
{
  

    /// <summary>
    /// Base class for all Controller
    /// </summary>
    public class BaseController : Controller
    {
        int _gridTotalRows;     // total number of records encompases filter condition



        [NonAction]
        public string GetApplicationVariableFromConfig(string name)
        {
            string value = GetCache<string>(name);

            if (value == null)
            {
                value = ConfigurationManager.AppSettings.Get(name);
                SetCache<string>(name, value);
            }

            return value;
        }


        [NonAction]
        public T GetCache<T>(string name) where T : class
        {
            return System.Web.HttpContext.Current.Cache.Get(name) as T;
        }

        [NonAction]
        public void SetCache<T>(string name, T value) where T : class
        {
            System.Web.HttpContext.Current.Cache.Insert(name, value, null, DateTime.Now.AddMinutes(60), Cache.NoSlidingExpiration);
        }

    }

}