using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.MDAL
{
    public class MERCHANTDAL
    {
        WEBGIAYEntities db = null;
        public MERCHANTDAL()
        {
            db = new WEBGIAYEntities();
        }
        public MERCHANT login(string tendn,string mk)
        {
            var mer = db.MERCHANTS.Where(m => m.TENDANGNHAP == tendn && m.MATKHAU == mk).SingleOrDefault();
            if (mer != null)
                return mer;
            return null;                
        }
        public MERCHANT kiemtratendangnhap(string tendangnhap)
        {
            var mer = db.MERCHANTS.Where(m=>m.TENDANGNHAP == tendangnhap).SingleOrDefault();
            return mer;
        }
        public MERCHANT kiemtracmnd(string cmnd)
        {
            var mer = db.MERCHANTS.Where(m => m.CMND == cmnd).SingleOrDefault();
            return mer;
        }
        public MERCHANT kiemtraemail(string email)
        {
            var mer = db.MERCHANTS.Where(m => m.EMAIL == email).SingleOrDefault();
            return mer;
        }
        public MERCHANT getme(int idmer)
        {
            var mer = db.MERCHANTS.Where(m => m.MAMERCHANT == idmer).SingleOrDefault();
            return mer;
        }
        public int newme(MERCHANT m)
        {
            db.MERCHANTS.Add(m);
            db.SaveChanges();
            return m.MAMERCHANT;
        }
        public bool active(int idme)
        {
            bool check = false;
            MERCHANT m = db.MERCHANTS.Find(idme);
            m.TINHTRANG = 1;
            db.SaveChanges();
            check = true;
            return check;
        }
        public List<MERCHANT>listallmer()
        {
            return db.MERCHANTS.ToList();
        }
        public void trutindang(int idmer)
        {
            var merchant = db.MERCHANTS.Where(x => x.MAMERCHANT == idmer).SingleOrDefault();
            merchant.SOTINHIENTAI -= 1;
            db.SaveChanges();
        }
        public List<MERCHANT> listtaikhoanbikhoa()
        {
            return db.MERCHANTS.Where(x => x.TINHTRANG == -1).ToList();
        }
        public void kichhoatlaidangtin(int idmer)
        {
            var mer = db.MERCHANTS.Where(x => x.MAMERCHANT == idmer).SingleOrDefault();
            mer.TINHTRANG = 1;
            db.SaveChanges();
        }
        public List<MERCHANT> kiemtrarating()
        {
            var listmer = listallmer();
            List<MERCHANT> listvuamoikhoa=new List<MERCHANT>();
            foreach (var item in listmer)
            {
                if(item.RATING <1)
                {
                    var mer = db.MERCHANTS.Where(x => x.MAMERCHANT == item.MAMERCHANT).SingleOrDefault();
                    mer.TINHTRANG = -1;
                    db.SaveChanges();
                    listvuamoikhoa.Add(item);
                }
            }
            return listvuamoikhoa;
        }
    }
}
