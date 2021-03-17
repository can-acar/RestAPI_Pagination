using Common.Enum;
using Common.Model;
using Common.Model.Example;
using Newtonsoft.Json.Converters;
using RestAPI_Pagination.HelperMethods;
using RestAPI_Pagination.Models;
using RestAPI_Pagination.OperationFilters;
using Swashbuckle.Examples;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestAPI_Pagination.Controllers
{
    [RoutePrefix("api/Customers")]
    public class CustomersController : BaseAPIController
    {
        [HttpPost]
        [SwaggerResponseExample(HttpStatusCode.OK, typeof(CustomerPaginationResponseExample))]
        [SwaggerRequestExample(typeof(PaginationRequest<CustomerPaginationGridColumns>), typeof(CustomerPaginationRequestExample), jsonConverter: typeof(StringEnumConverter))]
        [ResponseType(typeof(PaginationResponse<CustomerPaginationModel>))]
        [HelperMethods.DeflateCompression]
        [ValidateModelState]
        [CheckModelForNull]
        [SwaggerConsumes("application/json")]
        [SwaggerProduces("application/json")]
        [SwaggerResponse(HttpStatusCode.NotFound, "No customer found", typeof(GenericResponseModel))]
        [Route("")]
        public async Task<System.Web.Http.IHttpActionResult> Get(PaginationRequest<CustomerPaginationGridColumns> request)
        {
            BusinessLayer.Entity.Customer obj = new BusinessLayer.Entity.Customer(this);
            PaginationResponse<CustomerPaginationModel> response = obj.Get(request).Result;

            if (response.Items == null)
            {
                return APIResponse(HttpStatusCode.InternalServerError, $"Error: {obj.errorMessage}");
            }
            else
            if (response.Items.Count() == 0)
            {
                return APIResponse(HttpStatusCode.NotFound, $"No customer found");
            }
            return Ok(response);
        }
    }
}
