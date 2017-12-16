using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.DAL;
using Entity.EntityFramework;
using WEBGIAY.Areas.Customer.Models;
namespace WEBGIAY.Areas.Customer.Controllers
{
    public class giohangController : Controller
    {
        public const string ssgiohang = "ssgiohang";
        //
        // GET: /Customer/giohang/
        public ActionResult listsanphamtronggiohang()
        {
            
            var giohang = Session[ssgiohang];
            var list = new List<ITEMGIOHANGViewModel>();
            if (giohang!=null)
            {
                list = (List<ITEMGIOHANGViewModel>)giohang;                
            }
            return View(list);
        }

        public ActionResult additem(int masp,int makichco,int soluong)
        {
            if (Session["USER_SESSION"] == null)
            {
                return Json(-1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var sanpham = new SANPHAMDAL().sanphamnay(masp);
                var kichco = new KICHCODAL().kichco(makichco);
                var giohang = Session[ssgiohang];
                if (giohang != null)
                {
                    var list = (List<ITEMGIOHANGViewModel>)giohang;
                    if (list.Exists(m => m.SANPHAM.MASP == masp) && list.Exists(k => k.KICHCO.MAKICHCO == makichco))
                    {
                        var item = (from l in list
                                    where l.SANPHAM.MASP == masp && l.KICHCO.MAKICHCO == makichco
                                    select l).SingleOrDefault();
                        item.SOLUONG = item.SOLUONG + soluong;
                    }
                    else
                    {
                        var otheritem = new ITEMGIOHANGViewModel();
                        otheritem.SANPHAM = sanpham;
                        otheritem.KICHCO = kichco;
                        otheritem.SOLUONG = soluong;
                        list.Add(otheritem);
                        Session[ssgiohang] = list;
                        
                    }
                    //Session["tongsoluong"] = list.Sum(x => x.SOLUONG);
                    //Session["tongthanhtoan"] = list.Sum(x => x.THANHTIENITEM) - list.Sum(x => x.TIENGIAM);
                }
                else
                {
                    var item = new ITEMGIOHANGViewModel();
                    item.SANPHAM = sanpham;
                    item.KICHCO = kichco;
                    item.SOLUONG = soluong;
                    var list = new List<ITEMGIOHANGViewModel>();
                    list.Add(item);
                    Session[ssgiohang] = list;
                    ViewBag.sl = list.Sum(x => x.SOLUONG);
                    //Session["tongsoluong"] = list.Sum(x=>x.SOLUONG);
                    //Session["tongthanhtoan"] = list.Sum(x=>x.THANHTIENITEM)-list.Sum(x=>x.TIENGIAM);
                }
                
            }        
            return RedirectToAction("listsanphamtronggiohang");
        }
        public ActionResult emptycart()
        {
            Session[ssgiohang] = null;
            return RedirectToAction("listsanphamtronggiohang");
        }
        public ActionResult removeitem(int masp,int makichco)
        {

            List<ITEMGIOHANGViewModel> list = new List<ITEMGIOHANGViewModel>();
            if(Session[ssgiohang]!=null)
            {
                list = (List<ITEMGIOHANGViewModel>)Session[ssgiohang];
            }
            var itemremove = (from l in list
                              where l.SANPHAM.MASP == masp && l.KICHCO.MAKICHCO == makichco
                              select l).SingleOrDefault();
            list.Remove(itemremove);
            Session[ssgiohang] = list;
            double? tongtien = 0;
            double? tonggiam = 0;
            double? tongthanhtoan = 0;
            int tongsoluong = 0;
            foreach (var item in list)
            {
                tongtien = tongtien+item.THANHTIENITEM;
                tonggiam = tonggiam + item.TIENGIAM;
                tongsoluong = tongsoluong + item.SOLUONG;
            }
            tongthanhtoan = tongtien - tonggiam;
            //Session["tongsoluong"] = tongsoluong;
            //Session["tongthanhtoan"] = tongthanhtoan;
            List<double?> listresult = new List<double?>() { tongsoluong, tongtien, tonggiam, tongthanhtoan };
            return Json(listresult, JsonRequestBehavior.AllowGet); 
        }

        public ActionResult luudonhang(int macustomer,string diachi,string sdt,string ghichu, double tongtien)
        {
            if (Session[ssgiohang] != null)
            {
                DONHANG dh = new DONHANG();
                dh.MACUSTOMER = macustomer;
                dh.NGAYMUA = DateTime.Today;
                dh.TONGTIEN = tongtien;
                dh.GHICHU = ghichu;
                dh.SDT = sdt;
                dh.DIACHI = diachi;
                List<ITEMGIOHANGViewModel> listitem = new List<ITEMGIOHANGViewModel>();
                listitem = (List<ITEMGIOHANGViewModel>)Session[ssgiohang];
                List<CTDH> listctdh = new List<CTDH>();
                foreach (var item in listitem)
                {
                    CTDH ctdh = new CTDH();
                    ctdh.MASP = item.SANPHAM.MASP;
                    ctdh.MAMERCHANT = item.SANPHAM.MAMERCHANT;
                    ctdh.SOLUONG = item.SOLUONG;
                    ctdh.THANHTIEN = item.THANHTIENITEM - item.TIENGIAM;
                    ctdh.TINHTRANG = 1;
                    ctdh.MAKICHCO = item.KICHCO.MAKICHCO;
                    ctdh.GIAGIAM = item.SANPHAM.GIAGIAM;
                    listctdh.Add(ctdh);
                }
                DONGHANGDAL dal = new DONGHANGDAL();
                dal.luudonhang(dh, listctdh);
                Session[ssgiohang] = null;
                //Session["tongsoluong"] = null;
                //Session["tongthanhtoan"] = null;
            }
            else return Json(-1, JsonRequestBehavior.AllowGet);
            return RedirectToAction("listsanphamtronggiohang");
        }
	}
}