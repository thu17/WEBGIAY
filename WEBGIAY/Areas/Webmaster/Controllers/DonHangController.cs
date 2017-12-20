using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.DAL;
using WEBGIAY.Areas.Webmaster.Models;

namespace WEBGIAY.Areas.Webmaster.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Webmaster/DonHang
        public ActionResult Index()
        {
            return View(new InvoidViewModel() { DONHANG = new DonHangDAL().lsDonHang(), CTDH = new HoadonDAL().lsInv()});
        }
    }
}