using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.DAL
{
    public class SANPHAMDAL
    {
        WEBGIAYEntities db = null;
        public SANPHAMDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<SANPHAM> sanphammoi()
        {
            using (db)
            {
                var list = db.SANPHAMs.ToList();
                return list;
            }
        }
    }
}
