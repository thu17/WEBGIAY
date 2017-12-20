using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBGIAY.Common;

namespace WEBGIAY.Areas.Merchant.Controllers
{
    public class baseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sess = (merchantlogin)Session[constant.MERCHANT_SESSION];
            if(sess==null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "merchant", action = "login", Area = "Merchant" }));
            }
            base.OnActionExecuting(filterContext);
        }
	}
}