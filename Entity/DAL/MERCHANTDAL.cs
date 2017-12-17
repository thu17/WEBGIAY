using Entity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DAL
{
    public class MERCHANTDAL
    {
        WEBGIAYEntities db = null;
        public MERCHANTDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<MERCHANT>getallmerchant()
        {
            return db.MERCHANTS.ToList();
        }
        public MERCHANT merinfor(int idmer)
        {
            return db.MERCHANTS.Where(i => i.MAMERCHANT == idmer).SingleOrDefault();
        }
    }
}
