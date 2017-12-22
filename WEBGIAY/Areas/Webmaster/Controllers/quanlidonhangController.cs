using Entity.MDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBGIAY.Areas.Merchant.Models;

namespace WEBGIAY.Areas.Webmaster.Controllers
{
    public class quanlidonhangController : Controller
    {
        //
        // GET: /Webmaster/quanlidonhang/
        public ActionResult Index()
        {
            ViewBag.MERCHANT = new SelectList(new MERCHANTDAL().listallmer(), "MAMERCHANT", "TENMERCHANT");
            var list = listall();
            return View(list);
        }
        public ActionResult thongkedonhang(int idmer,DateTime? bd,DateTime? kt)
        {
             var all = listall();
            var list =new List<DONHANG_CTDH_ViewModel>();
            if(idmer!=0)
            {
                 if(bd!=null && kt !=null)
                {
                    list = (from l in all
                            where l.MAMERCHANT == idmer && l.NGAYMUA >= bd && l.NGAYMUA <= kt
                            select l).ToList();
                }
                else
                {
                    list = (from l in all
                            where l.MAMERCHANT == idmer
                            select l).ToList();
                }            
               
            }
            else
            {
                 if(bd!=null && kt !=null)
                {
                    list = (from l in all
                            where l.NGAYMUA >= bd && l.NGAYMUA <= kt
                            select l).ToList();
                }
                else
                {
                    list = (from l in all                         
                            select l).ToList();
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);

        }
        public List<DONHANG_CTDH_ViewModel> listall()
        {
            List<DONHANG_CTDH_ViewModel> list = new List<DONHANG_CTDH_ViewModel>();
            
            DONHANGDAL dal = new DONHANGDAL();
            var listdh = dal.listall();
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
                foreach (var ct in dal.ctcuadh(item.MADH))
                {
                    if (ct.TINHTRANG != 0 && ct.TINHTRANG != 3)
                        tinhtrang = 0;
                    CTDHViewModel v = new CTDHViewModel();
                    v.MAMERCHANT = ct.MAMERCHANT;
                    v.MADH = ct.MADH;
                    v.MASP = ct.MASP;
                    v.MAMERCHANT = ct.MAMERCHANT;
                    v.SOLUONG = ct.SOLUONG;
                    v.THANHTIEN = ct.THANHTIEN;
                    v.TINHTRANG = ct.TINHTRANG == 0 ? "Đã hủy" : (ct.TINHTRANG == 1 ? "Đang xử lí" : (ct.TINHTRANG == 2 ? "Đang giao" : "Đã giao"));
                    v.MAKICHCO = ct.MAKICHCO;
                    v.GIAGIAM = ct.GIAGIAM;
                    v.KICHCO = ct.KICHCO.KICHCO1;
                    v.TENSANPHAM = ct.SANPHAM.TENSP;
                    v.GIA = ct.SANPHAM.GIA;
                    tongtien = tongtien + ct.THANHTIEN;
                    listct.Add(v);
                }
                dcv.TINHTRANG = tinhtrang;
                dcv.TONGTIEN = tongtien;
                dcv.ctdh = listct;
                list.Add(dcv);
            }
            return list.OrderBy(t => t.TINHTRANG).ToList();
        }
	}
}