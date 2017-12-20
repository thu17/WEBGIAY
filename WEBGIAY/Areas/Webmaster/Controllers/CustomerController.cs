using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.DAL;
using WEBGIAY.Areas.Customer.Models;

namespace WEBGIAY.Areas.Webmaster.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Webmaster/Customer
        
        public ActionResult Index()
        {
            
            return View(new CUSTOMERDAL().lsCus());
        }
        public ActionResult Invoid()
        {
            return View(new DonHangDAL().lsDonHang());
        }
        
    }
}