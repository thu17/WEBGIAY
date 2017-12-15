using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WEBGIAY.Common
{
    [Serializable]
    public class customerlogin
    {
        
        public int MACUSTOMER { get; set; }
        public string TENCUSTOMER { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public string SDT { get; set; }
        public string EMAIL { get; set; }
        public string MATKHAU { get; set; }
        public Nullable<double> RATING { get; set; }
        public string DIACHI { get; set; }
    }
}