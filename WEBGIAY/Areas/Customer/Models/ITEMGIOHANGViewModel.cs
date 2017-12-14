using Entity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBGIAY.Areas.Customer.Models
{
    [Serializable]
    public class ITEMGIOHANGViewModel
    {

        public SANPHAM SANPHAM { get; set; }
        public KICHCO KICHCO { get; set; }
        public int SOLUONG { get; set; }
        public double? THANHTIENITEM { get { return SOLUONG * SANPHAM.GIA; } }
        public double? TIENGIAM { get { return SOLUONG * (SANPHAM.GIA - (SANPHAM.GIAGIAM==null?SANPHAM.GIA:SANPHAM.GIAGIAM)); } }
    }
}