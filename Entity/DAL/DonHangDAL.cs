using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
//using Entity.ViewModel;
using System.Data.SqlClient;

namespace Entity.DAL
{
    public class DonHangDAL
    {
        WEBGIAYEntities db = null;
        public DonHangDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<DONHANG> lsDonHang()
        {
            using (db)
            {
                var list = db.DONHANGs.Take(9).ToList();
                return list;
            }
        }
        public DONHANG getDH(int MADH)
        {
            using (db)
            {
                return db.DONHANGs.Where(c => c.MADH == MADH).FirstOrDefault();
            }
        }
    }
}
