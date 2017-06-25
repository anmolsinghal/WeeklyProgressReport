using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace PartnerView.WebAPI.Models
{
    public class AllowCrossSiteJsonAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
                actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST, GET, PUT, DELETE, OPTIONS");

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}