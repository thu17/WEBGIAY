using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity.MDAL;
using WEBGIAY.Common;
using WEBGIAY.Areas.Merchant.Models;
using Entity.EntityFramework;
using System.Text;
using System.Net.Mail;
using System.Web.Hosting;
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
            var ver = new MERCHANTDAL().login(tendangnhap, MD5Encryptor.MD5Hash(matkhau));
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


        [HttpPost]
        public ActionResult register(REGISTERViewModel r)
        {
            if (ModelState.IsValid)
            {
                MERCHANTDAL dal = new MERCHANTDAL();
                var email = dal.kiemtratendangnhap(r.EMAIL);
                var tendn = dal.kiemtratendangnhap(r.TENDANGNHAP);
                var cmd = dal.kiemtracmnd(r.CMND);
                if (email != null)
                {
                    ModelState.AddModelError("", "Email đã đươc sử dụng");
                }
                if (tendn != null)
                {
                    ModelState.AddModelError("", "Tên dăng nhập đã đươc sử dụng");
                }
                if (cmd != null)
                {
                    ModelState.AddModelError("", "CMND đã đươc sử dụng");
                }
                else
                {
                    var m = new MERCHANT();
                    m.TENDANGNHAP = r.TENDANGNHAP;
                    m.TENMERCHANT = r.TENMERCHANT;
                    m.MATKHAU = MD5Encryptor.MD5Hash(r.MATKHAU);
                    m.DIACHI = r.DIACHI;
                    m.EMAIL = r.EMAIL;
                    m.NGAYSINH = r.NGAYSINH;
                    m.SDT = r.SDT;
                    m.NGAYDK = DateTime.Today;
                    m.TINHTRANG = 0;
                    m.SOTINHIENTAI = 0;
                    m.SOLANBIKHOA = 0;
                    m.RATING = 0;
                    m.CMND = r.CMND;
                    var ver = dal.newme(m);
                    if (ver > 0)
                    {
                        ViewBag.Success = "Đăng kí thành công. Vui lòng kiểm tra email để kích hoạt tài khoản";
                        BuildEmailTemplate(ver);

                    }
                    else ModelState.AddModelError("", "Đăng kí không thành công");
                }
            }
            return View(r);
        }

        public void BuildEmailTemplate(int regisID)
        {
            //{E:\Project\asp.net\Register\Register\EmailTemplate\Confirmation.cshtml
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("/EmailTemplate/") + "MConfirmation" + ".cshtml");
            var regInfo = new MERCHANTDAL().getme(regisID);
            var url = "http://localhost:58949/" + "Merchant/merchant/Confirm?regId=" + regisID;
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate("Tài khoản đã được tạo thành công", body, regInfo.EMAIL);
        }

        private static void BuildEmailTemplate(string subjectText, string bodyText, string sendTo)
        {
            string from, to, bcc, cc, subject, body;
            from = "qwertyuio27111994@gmail.com";
            to = sendTo.Trim();
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }
        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("qwertyuio27111994@gmail.com", "2711199400");
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult Confirm(int regId)
        {
            ViewBag.regisID = regId;
            return View();
        }
        public JsonResult activeaccount(int regId)
        {
            var comp = new MERCHANTDAL().active(regId);
            var msg = "Lỗi";
            if (comp)
            {
                msg = "xác nhận thành công!";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public ActionResult info()
        {
            var mer = (merchantlogin)Session[constant.MERCHANT_SESSION];
            MERCHANT m = new MERCHANTDAL().getme(mer.MAMERCHANT);
            m.MATKHAU = mer.MATKHAU;
            return View(m);
        }

        public ActionResult muatin()
        {
            var list = new GOITINDAL().listgoitin();
            return View(list);
        }
    }
}