using Entity.EntityFramework;
using Entity.MDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBGIAY.Common;

namespace WEBGIAY.Areas.Merchant.Controllers
{
    public class muatinController : Controller
    {
        public ActionResult lichsumuatin()
        {            
            ViewData["listgoitin"] = new GOITINDAL().listgoitin();
            var mer = (merchantlogin)Session[constant.MERCHANT_SESSION];
            LICHSUMUATIN ls = new LICHSUMUATIN();
            var list = new GOITINDAL().listalltindamua(mer.MAMERCHANT);
            ViewData["tongtien"] = list.Where(x=>x.TRANGTHAI==1).Sum(x => x.GOITIN.SOTIEN);
            ViewData["phaitra"] = list.Where(x => x.TRANGTHAI == 0).Sum(x => x.GOITIN.SOTIEN);
            return View(list);
        }
        public ActionResult themgoi(int magoi)
        {
            var mer = (merchantlogin)Session[constant.MERCHANT_SESSION];
            LICHSUMUATIN l = new LICHSUMUATIN();
            l.MAMERCHANT = mer.MAMERCHANT;
            l.MAGOITIN = magoi;
            l.NGAYMUA = DateTime.Today;
            l.TRANGTHAI = 0;
            GOITINDAL dal = new GOITINDAL();
            dal.addlichsumuatin(l);
            return Json(1,JsonRequestBehavior.AllowGet);
        }        
	}
}