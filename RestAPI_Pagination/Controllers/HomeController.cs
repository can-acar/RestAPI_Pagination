using Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestAPI_Pagination.Controllers
{
    

    public class HomeController : BaseController
    {


        // GET: Home
        public ActionResult Index()
        {

            bool bShowSwaggerDocumentation = bool.Parse(GetApplicationVariableFromConfig(ApplicationVariablesFromConfig.ShowSwaggerDocumentation));
            if (!bShowSwaggerDocumentation)
            {
                return View("Index");
            }
            return Redirect("APIDocumentation/index");
        }

    }


}
