using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
using Entity.DAL;
namespace Entity.MDAL
{
    public class RATINGDAL
    {
        WEBGIAYEntities db = null;
        public RATINGDAL()
        {
            db = new WEBGIAYEntities();
        }
        public void addrating(RATING r)
        {
            db.RATINGs.Add(r);
            db.SaveChanges();
        }
        public void capnhattinhtrangrating(int madh,int masp)
        {
            var rating = db.RATINGs.Where(r => r.MADH == madh && r.MASP == masp ).SingleOrDefault();
            rating.TRANGTHAI = 1;
            db.SaveChanges();
        }
        public List<RATING> listchomerchantrating(int merchant)
        {
            var list = db.RATINGs.Where(r => r.TRANGTHAI == 0 && r.MAMERCHANT==merchant).ToList();
            return list;
        }
        public void tinhratingtbcus(int cus)
        {
            var listrat = db.RATINGs.Where(r => r.MACUSTOMER == cus && r.RATING_C != null);
            var sum = listrat.Sum(x => x.RATING_C);
            int count = listrat.Count();
            var average = sum / count;
            var customer = new CUSTOMERDAL().getcustomer(cus);
            customer.RATING = average;
            db.SaveChanges();
        }
        public void tinhratingtbmer(int mer)
        {
            var listrat = db.RATINGs.Where(r => r.MAMERCHANT == mer && r.RATING_M != null);
            var sum = listrat.Sum(x => x.RATING_M);
            int count = listrat.Count();
            var average = sum / count;
            var merchant = new MERCHANTDAL().getme(mer);
            merchant.RATING = average;
            db.SaveChanges();
        }
        public List<RATING> listchocustomerrating(int custoemr)
        {
            var list = db.RATINGs.Where(r => r.TRANGTHAI == 0 && r.MACUSTOMER == custoemr).ToList();
            return list;
        }
        public void capnhatdanhgiatumer(int iddonhang,int idsp,int cus,int rating)
        {
            var customer = db.RATINGs.Where(r => r.MADH == iddonhang && r.MASP == idsp).SingleOrDefault();
            customer.RATING_C = rating;
            db.SaveChanges();
            tinhratingtbcus(cus);
        }
        public void capnhatdanhgiatucus(int iddonhang, int idsp, int mer, int rating)
        {
            var merrating = db.RATINGs.Where(r => r.MADH == iddonhang && r.MASP == idsp).SingleOrDefault();
            merrating.RATING_M = rating;
            db.SaveChanges();
            tinhratingtbmer(mer);
        }
    }
}
