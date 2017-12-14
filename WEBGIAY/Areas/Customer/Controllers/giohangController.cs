using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.DAL;
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
            var sanpham = new SANPHAMDAL().sanphamnay(masp);
            var kichco = new KICHCODAL().kichco(makichco);
            var giohang = Session[ssgiohang];
            if(giohang!=null)
            {
                var list = (List<ITEMGIOHANGViewModel>)giohang;                
                if(list.Exists(m=>m.SANPHAM.MASP==masp) && list.Exists(k=>k.KICHCO.MAKICHCO==makichco))
                {  
                    list.Where(i => i.SANPHAM.MASP == masp).SingleOrDefault().SANPHAM.MASP += soluong;
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
            }
            return RedirectToAction("listsanphamtronggiohang");
        }
	}
}