using Entity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBGIAY.Areas.Customer.Models
{
    public class CTDH_SANPHAM_MERCHANT_KICHCOViewModel
    {
        public int MASP { get; set; }
        public int MAKICHCO { get; set; }
        public string TENSP { get; set; }
        public string TENMERCHANT { get; set; }
        public int SOLUONG { get; set; }
        public double? THANHTIEN { get; set; }
        public double? TINHTRANG { get; set; }
        public int KICHCO { get; set; }
        public double? GIAGIAM { get; set; }
        public double GIA { get; set; }
    }
}