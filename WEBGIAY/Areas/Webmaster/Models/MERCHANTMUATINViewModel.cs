using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity.EntityFramework;
namespace WEBGIAY.Areas.Webmaster.Models
{
    public class MERCHANTMUATINViewModel
    {
        public int IDMUATIN { get; set; }
        public int MAMERCHANT { get; set; }
        public string TENMERCHANT { get; set; }
        public int MAGOITIN { get; set; }
        public int SOTIN { get; set; }
        public double SOTIEN { get; set; }
        public DateTime? NGAYMUA { get; set; }
        
    }
}