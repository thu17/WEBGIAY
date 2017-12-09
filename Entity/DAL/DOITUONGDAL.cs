using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.DAL
{
    public class DOITUONGDAL
    {
        WEBGIAYEntities db = null;
        public DOITUONGDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<DOITUONG> listdoituong()
        {
            return db.DOITUONGs.ToList();
        }
        public DOITUONG doituongnay(int iddoituong)
        {
            using (db)
            {
                var d = db.DOITUONGs.Find(iddoituong);
                return d;
            }
        }
    }
}
