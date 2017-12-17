using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBGIAY.Common
{
    [Serializable]
    public class merchantlogin
    {
        public int MAMERCHANT { get; set; }
        public string TENDANGNHAP { get; set; }
        public string TENMERCHANT { get; set; }       
        public string EMAIL { get; set; }
        public string MATKHAU { get; set; }       
        public Nullable<int> SOLANBIKHOA { get; set; }
        public Nullable<double> RATING { get; set; }
        public Nullable<int> SOTINHIENTAI { get; set; }
    }
}