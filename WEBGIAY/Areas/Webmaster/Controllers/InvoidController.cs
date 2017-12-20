using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.DAL;
using WEBGIAY.Areas.Webmaster.Models;

namespace WEBGIAY.Areas.Webmaster.Controllers
{
    public class InvoidController : Controller
    {
        // GET: Webmaster/Invoid
        public ActionResult Index()
        {
            return View(new InvoidViewModel() { DONHANG = new DonHangDAL().lsDonHang(), CTDH = new HoadonDAL().lsInv() });
        }
    }
}