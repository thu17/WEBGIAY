using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBGIAY.Areas.Customer.Models
{
    public class CUSTOMER_REGISTERViewModel
    {
        public int MACUSTOMER { get; set; }
        [Required(ErrorMessage = "Tên không đươc bỏ trống")]
        public string TENCUSTOMER { get; set; }
        public Nullable<System.DateTime> NGAYDK { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        //[Required(ErrorMessage = "Số điện thoại không được bỏ trống")]
        //[RegularExpression(@"(\\+84|0)\\d{9,10}")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Email không được bỏ trống")]
        //[RegularExpression(@"[a-zA-Z0-9_\.]+@[a-zA-Z]+\.[a-zA-Z]+(\.[a-zA-Z]+)*")]
        public string EMAIL { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        //[StringLength(5000, MinimumLength = 5, ErrorMessage = "Độ dài tối thiểu là 5 kí tự")]
        public string MATKHAU { get; set; }
        [Compare("MATKHAU")]
        public string MATKHAUNHAPLAI { get; set; }
        public Nullable<int> RATING { get; set; }
        public Nullable<int> TINHTRANG { get; set; }
        [Required(ErrorMessage = "Địa chỉ không đươc bỏ trống")]
        public string DIACHI { get; set; }
    }
}