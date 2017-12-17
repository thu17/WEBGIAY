using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.MDAL;
using WEBGIAY.Common;
namespace WEBGIAY.Areas.Merchant.Controllers
{
    public class merchantController : Controller
    {
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        
        public ActionResult login(string tendangnhap, string matkhau)
        {
            var ver = new MERCHANTDAL().login(tendangnhap,MD5Encryptor.MD5Hash(matkhau));
            if (ver != null)
            {
                var mSession = new merchantlogin();
                mSession.EMAIL = ver.EMAIL;
                mSession.MAMERCHANT = ver.MAMERCHANT;
                mSession.MATKHAU = matkhau;
                mSession.RATING = ver.RATING;
                mSession.SOLANBIKHOA = ver.SOLANBIKHOA;
                mSession.SOTINHIENTAI = ver.SOTINHIENTAI;
                mSession.TENDANGNHAP = ver.TENDANGNHAP;
                mSession.TENMERCHANT = ver.TENMERCHANT;
                Session.Add(constant.MERCHANT_SESSION, mSession);
                return RedirectToAction("Index", "Home");
            }
            else ModelState.AddModelError("", "Sai mật khẩu hoặc tên đăng nhập!Vui lòng kiểm tra lại!");
            return View();
        }
        public ActionResult dangxuat()
        {
            constant.MERCHANT_SESSION = null;
            return RedirectToAction("login");
        }
        [HttpGet]
        public ActionResult register()
        {
            return View();
        }
	}
}