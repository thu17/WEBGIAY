using Entity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DAL
{
    public class CTDHDAL
    {
         WEBGIAYEntities db = null;
         public CTDHDAL()
        {
            db=new WEBGIAYEntities();
        }
        public List<CTDH> listallctdh()
        {
            return db.CTDHs.ToList();
        }
        public List<CTDH> listctdh(int iddonhang)
        {
            return db.CTDHs.Where(ct=>ct.MADH==iddonhang).ToList();
        }
    }
}
