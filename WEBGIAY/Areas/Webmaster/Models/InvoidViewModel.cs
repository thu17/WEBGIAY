using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;

namespace WEBGIAY.Areas.Webmaster.Models
{
    public class InvoidViewModel
    {
        public List<Entity.EntityFramework.DONHANG> DONHANG { get; set; }
        public List<Entity.EntityFramework.CTDH> CTDH { get; set; }
        public List<Entity.EntityFramework.MERCHANT> MERCHANT { get; set; }
        public List<Entity.EntityFramework.CUSTOMER> CUSTOMER { get; set; }
        public List<Entity.EntityFramework.SANPHAM> SANPHAM { get; set; }
    }
}