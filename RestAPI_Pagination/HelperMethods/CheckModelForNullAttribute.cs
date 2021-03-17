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
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CheckModelForNullAttribute'
    public class CheckModelForNullAttribute : ActionFilterAttribute
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CheckModelForNullAttribute'
    {
        private readonly Func<Dictionary<string, object>, bool> _validate;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CheckModelForNullAttribute.CheckModelForNullAttribute()'
        public CheckModelForNullAttribute() : this(arguments =>
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CheckModelForNullAttribute.CheckModelForNullAttribute()'
     arguments.ContainsValue(null))
        { }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CheckModelForNullAttribute.CheckModelForNullAttribute(Func<Dictionary<string, object>, bool>)'
        public CheckModelForNullAttribute(Func<Dictionary<string, object>, bool> checkCondition)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CheckModelForNullAttribute.CheckModelForNullAttribute(Func<Dictionary<string, object>, bool>)'
        {
            _validate = checkCondition;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'CheckModelForNullAttribute.OnActionExecuting(HttpActionContext)'
        public override void OnActionExecuting(HttpActionContext actionContext)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'CheckModelForNullAttribute.OnActionExecuting(HttpActionContext)'
        {
            if (_validate(actionContext.ActionArguments))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
       HttpStatusCode.BadRequest, "The argument cannot be null");
            }
        }
    }
}