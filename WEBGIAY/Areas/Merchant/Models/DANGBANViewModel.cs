using Entity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBGIAY.Areas.Merchant.Models
{
    public class DANGBANViewModel
    {

        //public SANPHAM sp{get;set;}
        public int MASP { get; set; }
        public string TENSP { get; set; }
        public Nullable<System.DateTime> NGAYDANG { get; set; }
        public int MAMERCHANT { get; set; }
        public int MATHUONGHIEU { get; set; }
        public int MADOITUONG { get; set; }
        public int MALOAI { get; set; }
        public Nullable<int> TINHTRANG { get; set; }
        public double GIA { get; set; }
        public Nullable<double> GIAGIAM { get; set; }
        public string MOTA { get; set; }
        public string MAUSAC { get; set; }
        public HttpPostedFileBase ANH { get; set; }
        public List<HttpPostedFileBase> files { get; set; }
        
        //[Display(Name = "Các kích cỡ")]
        //public List<CUNGSANPHAM> csp { get; set; }
        //public int SOLUONG { get; set; }
      
    }
}