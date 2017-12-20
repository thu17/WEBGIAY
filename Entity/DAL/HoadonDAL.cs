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
    public class HoadonDAL
    {
        WEBGIAYEntities db = null;
        public HoadonDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<CTDH> lsInv()
        {
            using (db)
            {
                var list = db.CTDHs.Take(9).ToList();
                return list;
            }
        }
    }
}
