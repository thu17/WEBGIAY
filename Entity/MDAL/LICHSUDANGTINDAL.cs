using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.MDAL
{
    public class LICHSUDANGTINDAL
    {
        WEBGIAYEntities db = null;
        public LICHSUDANGTINDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<LICHSUDANGTIN> tatcabaidang()
        {
            return db.LICHSUDANGTINs.ToList();
        }
        public void addlichsu(int idmer,int idsanpham)
        {
            LICHSUDANGTIN ls = new LICHSUDANGTIN();
            ls.MAMERCHANT = idmer;
            ls.MASP = idsanpham;
            ls.NGAYDANG = DateTime.Today;
            db.LICHSUDANGTINs.Add(ls);
        }
    }
}
