using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Entity.DAL;
using Entity.EntityFramework;
using WEBGIAY.Common;
using System.Web.Hosting;
using System.Text;
using System.Net.Mail;
using WEBGIAY.Areas.Customer.Models;
namespace WEBGIAY.Areas.Customer.Controllers
{
    public class userController : Controller
    {
        
            //REGISTER
            [HttpGet]
            public ActionResult register()
            {
                return View();
            }

            [HttpPost]
            public ActionResult register(CUSTOMER_REGISTERViewModel cr)
            {
                if (ModelState.IsValid)
                {
                    var dao = new CUSTOMERDAL();
                    if (dao.checkemail(cr.EMAIL))
                    {
                        ModelState.AddModelError("", "Email đã đươc sử dụng");
                    }
                    else
                    {
                        var user = new CUSTOMER();
                        user.TENCUSTOMER = cr.TENCUSTOMER;

                        
                        //string privatekey = cr.MATKHAU;
                        //string publickey = rsa.ToXmlString(false);
                        //privatekey = rsa.ToXmlString(true);
                        //plaintext = ByteConverter.GetBytes(cr.MATKHAU);
                        //encryptedtext = RSAal.Encryption(plaintext, RSA.ExportParameters(false), false);
                        //user.MATKHAU = RSAal.Encrypt(cr.MATKHAU,publickey);

                        user.MATKHAU = MD5Encryptor.MD5Hash(cr.MATKHAU);

                        user.DIACHI = cr.DIACHI;
                        user.EMAIL = cr.EMAIL;
                        user.NGAYSINH = cr.NGAYSINH;
                        user.SDT = cr.SDT;
                        user.NGAYDK = DateTime.Today;
                        user.TINHTRANG = 0;
                        var result = dao.AddCustomer(user);
                        if (result > 0)
                        {
                            ViewBag.Success = "Đăng kí thành công";
                            BuildEmailTemplate(user.MACUSTOMER);
                            /*
                             phần này khi tạo đơn hàng xong thì gửi thông tin đơn hàng cho khách hàng
                             string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Customer/templates/neworder.html"));
                            content = content.Replace("{{TENCUSTOMER}}", cr.TENCUSTOMER);
                            content = content.Replace("{{SDT}}", cr.SDT);
                            content = content.Replace("{{EMAIL}}", cr.EMAIL);
                            content = content.Replace("{{DIACHI}}", cr.DIACHI);
                            content=content.Replace("{{TONGTIEN}}",TONGTIEN.ToString("NO");
                            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"];
                            new MailHelper().SendEmail(cr.EMAIL, "Đơn hàng mới từ shop", content);
                            new MailHelper().SendEmail(toEmail, "Đơn hàng mới từ shop", content);
                             */


                        }
                        else ModelState.AddModelError("", "Đăng kí không thành công");
                    }
                }
                return View(cr);
            }


            public void BuildEmailTemplate(int regisID)
            {
                //{E:\Project\asp.net\Register\Register\EmailTemplate\Confirmation.cshtml
                string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("/EmailTemplate/") + "Confirmation" + ".cshtml");
                var regInfo = new CUSTOMERDAL().getcustomer(regisID);
                var url = "http://localhost:58949/" + "/user/Confirm?regId=" + regisID;
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
                var active = new CUSTOMERDAL().thaydoitrangthai(regId);
                var msg = "Lỗi";
                if (active)
                {
                    msg = "xác nhận thành công!";
                }
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

            
            //LOGIN
            [HttpGet]
            public ActionResult login()
            {
                return View();
            }
            public ActionResult login(string email,string matkhau)
            {
                 var dal =new CUSTOMERDAL();               
                var getpwd =dal.getpasswordbyemail(email);
                if(getpwd==null)
                {
                    ModelState.AddModelError("", "Sai email! Vui lòng kiểm tra lại");
                }
                else
                {
                    //string privatekey = rsa.ToXmlString(true);
                    //var decrypt = RSAal.Decrypt(getpwd, privatekey);
                    //decrypt = RSAal.Decryption(getpwd);
                    //byte[] _etext = BtConverter.GetBytes(getpwd);
                    //byte[] dtext = RSAal.RSADecryption(_etext, RSA.ExportParameters(true), false);
                    //var decrypt = BtConverter.GetString(dtext);

                    if ((MD5Encryptor.MD5Hash(matkhau)).Equals(getpwd))
                    {
                        var customer = dal.getuserbyemail(email);
                        var cSession =new customerlogin();
                        cSession.MACUSTOMER=customer.MACUSTOMER;
                        cSession.EMAIL=customer.EMAIL;
                        cSession.DIACHI=customer.DIACHI;
                        cSession.MATKHAU=customer.MATKHAU;
                        cSession.NGAYSINH=customer.NGAYSINH;
                        cSession.RATING=customer.RATING;
                        cSession.SDT=customer.SDT;
                        Session.Add(constant.CUSTOMER_SESSION,cSession);
                        return RedirectToAction("Index", "Home");
                    }
                    else ModelState.AddModelError("","Sai mật khẩu");
                }
                return View();
            }
            
        }
	}
