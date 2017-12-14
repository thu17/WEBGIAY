using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.DAL
{
    public class KICHCODAL
    {
        WEBGIAYEntities db = null;
        public KICHCODAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<KICHCO>getallkc()
        {
            return db.KICHCOes.ToList();
        }
        public KICHCO kichco(int idkc)
        {
            using (db)
            {
                return db.KICHCOes.Find(idkc);
            }
        }
    }
}
