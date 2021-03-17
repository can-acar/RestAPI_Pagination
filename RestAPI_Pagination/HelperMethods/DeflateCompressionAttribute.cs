using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace RestAPI_Pagination.HelperMethods
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeflateCompressionAttribute'
    public class DeflateCompressionAttribute : ActionFilterAttribute
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeflateCompressionAttribute'
    {

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'DeflateCompressionAttribute.OnActionExecuted(HttpActionExecutedContext)'
        public override void OnActionExecuted(HttpActionExecutedContext actContext)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'DeflateCompressionAttribute.OnActionExecuted(HttpActionExecutedContext)'
        {
            var content = actContext.Response.Content;
            var bytes = content == null ? null : content.ReadAsByteArrayAsync().Result;
            var zlibbedContent = bytes == null ? new byte[0] :
            CompressionHelper.DeflateByte(bytes);
            actContext.Response.Content = new ByteArrayContent(zlibbedContent);
            actContext.Response.Content.Headers.Remove("Content-Type");
            actContext.Response.Content.Headers.Add("Content-encoding", "deflate");
            actContext.Response.Content.Headers.Add("Content-Type", "application/json");
            base.OnActionExecuted(actContext);
        }
    }
}