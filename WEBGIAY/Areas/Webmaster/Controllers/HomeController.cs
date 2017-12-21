using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WEBGIAY.Areas.Webmaster.Models;
using Entity.DAL;
using Entity.EntityFramework;
using WEBGIAY.Common;
using System.Web.Hosting;
using System.Text;
using System.Net.Mail;
using Entity.MDAL;

namespace WEBGIAY.Areas.Webmaster.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Webmaster/Home/
        public ActionResult Index()
        {
            ViewBag.MERCHANT =new SelectList(new Entity.DAL.MERCHANTDAL().getallmerchant(),"MAMERCHANT","TENMERCHANT","Tất cả");
            return View(listall());
        }
        public List<MERCHANTMUATINViewModel> listall()
        {
            GOITINDAL dal = new GOITINDAL();
            var listlichsu = dal.listlichsu();
            var listthongke = (from l in listlichsu
                               select new MERCHANTMUATINViewModel()
                               {
                                   MAMERCHANT = l.MAMERCHANT,
                                   TENMERCHANT = l.MERCHANT.TENMERCHANT,
                                   MAGOITIN = l.MAGOITIN,
                                   SOTIN = l.GOITIN.SOTIN,
                                   SOTIEN = l.GOITIN.SOTIEN,
                                   NGAYMUA = l.NGAYMUA
                               }).ToList();
            ViewData["tongcong"] = listthongke.Sum(x => x.SOTIEN);
            return listthongke;
        }
        public List<MERCHANTMUATINViewModel> thongketheoMerDate(int idmer,DateTime? tu,DateTime? den)
        {
            var list = new List<MERCHANTMUATINViewModel>();
            if(idmer!=0)
            {
                 if(tu!=null && den!=null)
                {
                     list = (from l in listall()
                                where l.MAMERCHANT == idmer && l.NGAYMUA > tu && l.NGAYMUA < den
                                select l).ToList();                
                }
                else
                {
                     list = (from l in listall()
                                where l.MAMERCHANT == idmer 
                                select l).ToList();                
                }
            }
            else{
                if(tu!=null && den!=null)
                {
                     list = (from l in listall()
                                where l.NGAYMUA > tu && l.NGAYMUA < den
                                select l).ToList();                
                }
                else
                {
                     list = (from l in listall()                              
                                select l).ToList();                
                }
            }
           
            ViewData["tongcong"] = list.Sum(x => x.SOTIEN);
            return list;
        }
        public ActionResult thongke(int idmer,DateTime? tu,DateTime? den)
        {
            var list = thongketheoMerDate(idmer, tu, den);
            return Json(list,JsonRequestBehavior.AllowGet);
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string tendangnhap, string matkhau)
        {
            var dal = new WebMasterDAL();
            var getpwd = dal.getpasswordbytk(tendangnhap);
            if (getpwd == null)
            {
                ModelState.AddModelError("", "Sai Tài Khoản! Vui lòng kiểm tra lại");
            }
            else
            {                
                if (MD5Encryptor.MD5Hash(matkhau).Equals(getpwd))
                {
                    var web = dal.getuserbytk(tendangnhap);
                    var wSession = new weblogin();
                    wSession.MAWEBMASTER = web.MAWEBMASTER;
                    wSession.TENDANGNHAP = web.TENDANGNHAP;
                    wSession.TENWEBMASTER = web.TENWEBMASTER;
                    wSession.EMAIL = web.EMAIL;
                    wSession.MATKHAU = web.MATKHAU;
                    wSession.SDT = web.SDT;
                    Session.Add(constant.WEBMASTER_SESSION, wSession);
                    return RedirectToAction("listmuagoitin", "quanlimer");
                }
                else ModelState.AddModelError("", "Sai mật khẩu");
            }
            return View();
        }
    }
}
