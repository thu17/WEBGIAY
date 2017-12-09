using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.DAL
{
    public class THUONGHIEUDAL
    {
        WEBGIAYEntities db = null;
        public THUONGHIEUDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<THUONGHIEU> thuonghieu()
        {
            using (db)
            {
                var list = db.THUONGHIEUx.ToList();
                return list;
            }
        }
    }
}
