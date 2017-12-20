using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBGIAY.Areas.Merchant.Models
{
    public class CTDHViewModel
    {
        public int MADH { get; set; }
        public int MASP { get; set; }
        public int MAMERCHANT { get; set; }
        public int SOLUONG { get; set; }
        public Nullable<double> THANHTIEN { get; set; }
        public string TINHTRANG { get; set; }
        public int MAKICHCO { get; set; }
        public Nullable<double> GIAGIAM { get; set; }

        public int KICHCO  { get; set; }        
        public  string TENSANPHAM { get; set; }
        public double GIA { get; set; }
       
    }
}