using Entity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBGIAY.Areas.Customer.Models
{
    public class DONHANG_CTDHViewModel
    {
        public DONHANG donhang { get; set; }
        public List<CTDH_SANPHAM_MERCHANT_KICHCOViewModel> listct { get; set;}
    }
}