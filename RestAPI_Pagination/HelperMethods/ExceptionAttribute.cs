using Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace RestAPI_Pagination.Models
{
    public class ExceptionAttribute : ExceptionFilterAttribute

    {
        public override void OnException(HttpActionExecutedContext context)
        {

         

            //context.Response.Content = JsonConvert.SerializeObject(model); ;

            var exception = context.Exception;
            if (exception != null)
            {
                context.Response = context.Request.CreateErrorResponse(
                    HttpStatusCode.InternalServerError, exception.Message);
            }

        }
    }
}