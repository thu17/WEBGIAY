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
        public bool themact(ANHCHITIET a)
        {
            bool check = false;
            db.ANHCHITIETs.Add(a);
            db.SaveChanges();
            check = true;
            return check;
        }
    }
}
