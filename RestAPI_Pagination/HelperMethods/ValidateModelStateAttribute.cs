using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RestAPI_Pagination.HelperMethods
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ValidateModelStateAttribute'
    public class ValidateModelStateAttribute : ActionFilterAttribute
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ValidateModelStateAttribute'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ValidateModelStateAttribute.OnActionExecuting(HttpActionContext)'
        public override void OnActionExecuting(HttpActionContext actionContext)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ValidateModelStateAttribute.OnActionExecuting(HttpActionContext)'
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
       HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }

}