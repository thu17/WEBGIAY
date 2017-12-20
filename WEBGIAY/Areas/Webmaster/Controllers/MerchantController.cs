using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.DAL;
using WEBGIAY.Areas.Webmaster.Models;

namespace WEBGIAY.Areas.Webmaster.Controllers
{
    public class MerchantController : Controller
    {
        // GET: Webmaster/Merchant
        public ActionResult Index()
        {
            return View(new Merchant_registerViewModel() { MERCHANT= new MERCHANTDAL().lsMer()} );
        }
        public ActionResult Dangtin()
        {
            return View(new TINDANGDAL().lsTin());
        }
        public ActionResult Invoid()
        {
            return View(new HoadonDAL().lsInv());
        }
    }
}