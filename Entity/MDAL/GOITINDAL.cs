using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.MDAL
{
    public class GOITINDAL
    {
        WEBGIAYEntities db = null;
        public GOITINDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<GOITIN> listgoitin()
        {
            return db.GOITINs.ToList();
        }

    }
}
