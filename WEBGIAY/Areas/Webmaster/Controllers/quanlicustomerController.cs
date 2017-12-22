using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.DAL;
using Entity.EntityFramework;
namespace WEBGIAY.Areas.Webmaster.Controllers
{
    public class quanlicustomerController : Controller
    {
        //
        // GET: /Webmaster/quanlicustomer/
        public ActionResult Index()
        {
            
            var list = new CUSTOMERDAL().listallcustomer();
            ViewData["tong"] = list.Count;
            return View(list);
        }
        public ActionResult thongkesoluong(DateTime? bd, DateTime? kt)
        {
            var listall = new CUSTOMERDAL().listallcustomer();
            List<CUSTOMER> listhongke = new List<CUSTOMER>();
            if(bd!=null && kt!=null)
            {
                listhongke = (from l in listall
                              where l.NGAYDK >= bd && l.NGAYDK <= kt
                              select new CUSTOMER
                              {
                                  MACUSTOMER=l.MACUSTOMER,
                                  TENCUSTOMER=l.TENCUSTOMER,
                                  NGAYDK=l.NGAYDK,
                                  SDT=l.SDT,
                                  EMAIL=l.EMAIL,
                                  DIACHI=l.DIACHI,
                                  RATING=l.RATING
                              }).ToList();
            }
            else listhongke = (from l in listall
                               select new CUSTOMER
                               {
                                   MACUSTOMER = l.MACUSTOMER,
                                   TENCUSTOMER = l.TENCUSTOMER,
                                   NGAYDK = l.NGAYDK,
                                   SDT = l.SDT,
                                   EMAIL = l.EMAIL,
                                   DIACHI = l.DIACHI,
                                   RATING = l.RATING
                               }).ToList();            
            return Json(listhongke, JsonRequestBehavior.AllowGet);
        }
	}
}