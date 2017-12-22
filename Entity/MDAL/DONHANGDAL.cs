using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.MDAL
{
    public class DONHANGDAL
    {
        WEBGIAYEntities db = null;
        public DONHANGDAL()
        {
            db = new WEBGIAYEntities();
            //db.Configuration.ProxyCreationEnabled = false;
        }
        public List<DONHANG> listall()
        {
            return db.DONHANGs.ToList();
        }
        public List<CTDH>getctdhbyid(int iddonhang,int idmer)
        {
            return db.CTDHs.Where(d => d.MADH == iddonhang && d.MAMERCHANT==idmer).ToList();
        }
        public List<int> listmadh(int idmer)
        {
            return (from d in db.CTDHs where d.MAMERCHANT == idmer select d.MADH).Distinct().ToList();
        }
        public List<DONHANG>listdhmer(int idmer)
        {
            List<DONHANG> listdh = new List<DONHANG>();
            var listma = listmadh(idmer);
            foreach (var item in listma)
            {
                var dh = db.DONHANGs.Find(item);
                listdh.Add(dh);                
            }
            return listdh;
        }
        public List<CTDH> ctcuadh(int iddonhang)
        {
            
            return db.CTDHs.Where(c => c.MADH == iddonhang).ToList();            
        }
        public int? capnhattrangthai(int madh, int masp,int kc,int? huy)
        {
            int? check = -1;
            var ct = db.CTDHs.Where(c => c.MADH == madh && c.MASP == masp && c.MAKICHCO==kc).SingleOrDefault();
            if(huy!=null)
            {
                ct.TINHTRANG = 0;
                db.SaveChanges();
            }
            else
            {
                if (ct.TINHTRANG == 1)
                    ct.TINHTRANG = 2;
                else if (ct.TINHTRANG == 2)
                    ct.TINHTRANG = 3;
                db.SaveChanges();
            }
                check= ct.TINHTRANG;
            if(check==0||check==3)
            {
                RATINGDAL r = new RATINGDAL();
                r.capnhattinhtrangrating(madh, masp);
            }
                return check;
        }

    }
}
