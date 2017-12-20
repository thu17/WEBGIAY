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

        public List<MERCHANT> lsMer()
        {
            using (db)
            {
                var list = db.MERCHANTS.Take(9).ToList();
                return list;
            }
        }
        public int AddMerchant(MERCHANT c)
        {
            db = new WEBGIAYEntities();
            db.MERCHANTS.Add(c);
            db.SaveChanges();
            return c.MAMERCHANT;
        }
        public MERCHANT getMerchant(int idMerchant)
        {
            db = new WEBGIAYEntities();
            return db.MERCHANTS.Find(idMerchant);
        }
        public bool thaydoitrangthai(int idmerchant)
        {
            var c = db.MERCHANTS.Find(idmerchant);
            if (c != null)
            {
                c.TINHTRANG = 1;
                return true;
            }
            return false;
        }
        //public List<MERCHANT> getallmerchant()
        //{
        //    return db.MERCHANTS.ToList();
        //}
       
    }
}
