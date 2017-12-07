using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.DAL
{
    public class PHANLOAIDAL
    {
        WEBGIAYEntities db = null;
        public PHANLOAIDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<PHANLOAI> phanloai()
        {
            using (db)
            {
                var list = db.PHANLOAIs.ToList();
                return list;
            }            
        }
    }
}
