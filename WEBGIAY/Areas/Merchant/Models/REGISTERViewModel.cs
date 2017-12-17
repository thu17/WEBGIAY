using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBGIAY.Areas.Merchant.Models
{
    public class REGISTERViewModel
    {
        
         [Required(ErrorMessage = "Tên đăng nhập không được bỏ trống")]
        public string TENDANGNHAP { get; set; }
         [Required(ErrorMessage = "Tên cửa hàng không được bỏ trống")]
        public string TENMERCHANT { get; set; }
         [Required(ErrorMessage = "CMND không được bỏ trống")]
        public string CMND { get; set; }
         [Required(ErrorMessage = "Địa chỉ không được bỏ trống")]
        public string DIACHI { get; set; }
         [Required(ErrorMessage = "Email không được bỏ trống")]
        public string EMAIL { get; set; }
         [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string MATKHAU { get; set; }
         [Compare("MATKHAU")]
         public string MATKHAUNHAPLAI { get; set; }
         [Required(ErrorMessage = "Ngày sinh không được bỏ trống")]
        public Nullable<System.DateTime> NGAYSINH { get; set; }
         [Required(ErrorMessage = "Điện thoại không được bỏ trống")]
        public string SDT { get; set; }
    }
}