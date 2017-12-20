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

namespace WEBGIAY.Areas.Webmaster.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Webmaster/Home/
        public ActionResult Index()
        {
            return View();
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
                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("", "Sai mật khẩu");
            }
            return View();
        }
    }
}