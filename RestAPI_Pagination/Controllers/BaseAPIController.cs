using Common.Enum;
using Common.Interface;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace RestAPI_Pagination.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]

    public class BaseAPIController : ApiController, ICache

    {

       


        [NonAction]
        protected IHttpActionResult APIResponse(HttpStatusCode statusCode, string message)
        {
            GenericResponseModel model = new GenericResponseModel()
            {
                Code = statusCode.ToString(),
                Message = message
            };

            return Content(statusCode, model);
        }


        [NonAction]
        public T GetCache<T>(string name) where T : class
        {

            return System.Web.HttpContext.Current.Cache.Get(name) as T;
        }

        [NonAction]
        public void SetCache<T>(string name, T value) where T : class
        {
            System.Web.HttpContext.Current.Cache.Insert(name, value, null, DateTime.Now.AddHours(5), Cache.NoSlidingExpiration);
        }

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



       


    }
}
