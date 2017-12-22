using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity.EntityFramework;
namespace WEBGIAY.Areas.Merchant.Models
{ 
    public class DONHANG_CTDH_ViewModel
    {
        //public DONHANG donhang { get; set; }
        //public List<CTDH> listctdh { get; set; }
        //public int TINHTRANG { get { return dahoantat();} }
        //public int dahoantat()
        //{
        //    foreach (var item in listctdh)
        //    {
        //        if (item.TINHTRANG == 0 || item.TINHTRANG == 3)
        //            return 1;                
        //    }
        //    return 0;
        //}
        public int MAMERCHANT { get; set; }
        public int MADH { get; set; }
        public int MACUSTOMER { get; set; }
        public string TENCUSTOMER { get; set; }
        public Nullable<System.DateTime> NGAYMUA { get; set; }
        public string DIACHI { get; set; }
        public string SDT { get; set; }
        public string GHICHU { get; set; }
        
        public List<CTDHViewModel> ctdh { get; set; }
        public double? TONGTIEN { get ;set ;}
        public int TINHTRANG { get ;set; }
       
        
    }
}