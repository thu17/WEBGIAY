using Entity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DAL
{
    public class ANHCHITIETDAL
    {
         WEBGIAYEntities db = null;
         public ANHCHITIETDAL()
        {
            db = new WEBGIAYEntities();
        }
       
        public List<ANHCHITIET> listanhspnay(int idsp)
        {
            using (db = new WEBGIAYEntities())
            {
                return db.ANHCHITIETs.Where(a => a.MASP == idsp).ToList();
            }
        }
    }
}
