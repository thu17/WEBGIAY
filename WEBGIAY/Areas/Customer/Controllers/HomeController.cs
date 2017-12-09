using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.DAL;
namespace WEBGIAY.Areas.Customer.Controllers
{
    public class HomeController : Controller
    {

        //
        // GET: /Customer/Home/
        public ActionResult Index()
        {
            return View(new SANPHAMDAL().listsanphammoi());
        }
        

        
	}
}