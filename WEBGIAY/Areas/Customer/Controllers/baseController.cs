using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBGIAY.Common;

namespace WEBGIAY.Areas.Customer.Controllers
{
    public class baseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sess = (customerlogin)Session[constant.CUSTOMER_SESSION];
            if(sess==null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "user", action = "login", Area = "Customer" }));
            }
            base.OnActionExecuting(filterContext);
        }
	}
}