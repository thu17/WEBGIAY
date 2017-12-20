using Entity.EntityFramework;
using Entity.MDAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBGIAY.Areas.Merchant.Models;
using WEBGIAY.Common;
namespace WEBGIAY.Areas.Merchant.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Merchant/Home/
        public ActionResult Index()
        {
            return View(listbytinhtrang(0));
        }
       
        public List<DONHANG_CTDH_ViewModel> listall()
        {
            List<DONHANG_CTDH_ViewModel> list = new List<DONHANG_CTDH_ViewModel>();
            var session = (merchantlogin)Session["MERCHANT_SESSION"];
            DONHANGDAL dal = new DONHANGDAL();
            var listdh = dal.listdhmer(session.MAMERCHANT);
            foreach (var item in listdh)
            {
                DONHANG_CTDH_ViewModel dcv = new DONHANG_CTDH_ViewModel();
                dcv.MADH = item.MADH;
                dcv.MACUSTOMER = item.MACUSTOMER;
                dcv.NGAYMUA = item.NGAYMUA;
                dcv.DIACHI = item.DIACHI;
                dcv.SDT = item.SDT;
                dcv.GHICHU = item.GHICHU;
                dcv.TENCUSTOMER = item.CUSTOMER.TENCUSTOMER;
                List<CTDHViewModel> listct = new List<CTDHViewModel>();
                int tinhtrang = 1;
                double? tongtien = 0;
                foreach (var ct in dal.getctdhbyid(item.MADH,session.MAMERCHANT))
                {
                    if (ct.TINHTRANG != 0 && ct.TINHTRANG != 3)
                        tinhtrang = 0;
                    CTDHViewModel v = new CTDHViewModel();
                    v.MADH = ct.MADH;
                    v.MASP = ct.MASP;
                    v.MAMERCHANT = ct.MAMERCHANT;
                    v.SOLUONG = ct.SOLUONG;
                    v.THANHTIEN = ct.THANHTIEN;
                    v.TINHTRANG = ct.TINHTRANG==0?"Đã hủy":(ct.TINHTRANG==1?"Đang xử lí":(ct.TINHTRANG==2?"Đang giao":"Đã giao"));
                    v.MAKICHCO = ct.MAKICHCO;
                    v.GIAGIAM = ct.GIAGIAM;
                    v.KICHCO = ct.KICHCO.KICHCO1;
                    v.TENSANPHAM = ct.SANPHAM.TENSP;
                    v.GIA = ct.SANPHAM.GIA;
                    tongtien =tongtien+ct.THANHTIEN;
                    listct.Add(v);
                }
                dcv.TINHTRANG = tinhtrang;
                dcv.TONGTIEN = tongtien;
                dcv.ctdh = listct;
                list.Add(dcv);
            }
            return list.OrderBy(t=>t.TINHTRANG).ToList();
        }
        public List<DONHANG_CTDH_ViewModel> listbytinhtrang(int tinhtrang)
        {
            var list = listall();
            var bytinhtrang = (from l in list
                               where l.TINHTRANG == tinhtrang
                               select l).OrderByDescending(l=>l.NGAYMUA).ToList();
            return bytinhtrang;

        }
        public JsonResult loaddatabytt(int tt)
        {
            var list = listbytinhtrang(tt);

            return Json(new { data= list }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult thaydoitinhtrang(int madh, int masp,int kc,int? huy)
        {
            string tinhtrang = "";
            DONHANGDAL dal = new DONHANGDAL();
            var check=dal.capnhattrangthai(madh,masp,kc,huy);
            if(check>-1)
            {
                tinhtrang = check == 0 ? "Đã hủy" : (check == 1 ? "Đang xử lí" : (check == 2 ? "Đang giao" : "Đã giao"));
                return Json(tinhtrang, JsonRequestBehavior.AllowGet);
            }
            return Json(-1,JsonRequestBehavior.AllowGet);
        }

        public ActionResult donhanghoantat()
        {
            return View(listbytinhtrang(1));
        }

	}
}