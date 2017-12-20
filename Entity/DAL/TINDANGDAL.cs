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
    public class TINDANGDAL
    {
        WEBGIAYEntities db = null;
        public TINDANGDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<LICHSUDANGTIN> lsTin()
        {
            using (db)
            {
                var list = db.LICHSUDANGTINs.Take(9).ToList();
                return list;
            }
        }
    }
}
