using Entity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBGIAY.Areas.Customer.Models
{
    public class CHITIETSANPHAMViewModel
    {
        public SANPHAM sp { get; set; }
        public List<CUNGSANPHAM_KICHCOViewModel> cungsp { get; set; }
        public List<ANHCHITIET> listanh { get; set; }
        public SelectList viewsize { get; set; }
    }

}