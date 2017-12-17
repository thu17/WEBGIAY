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
        
    }
}
