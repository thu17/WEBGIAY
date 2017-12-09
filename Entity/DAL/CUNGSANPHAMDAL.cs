using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.DAL
{
    public class CUNGSANPHAMDAL
    {
        WEBGIAYEntities db = null;
        public CUNGSANPHAMDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<int> listsoluong(int idsp,int kichco)
        {
            using (db)
            {
                var sl = (from c in db.CUNGSANPHAMs
                          where c.MASP == idsp && c.MAKICHCO == kichco
                          select c).SingleOrDefault().SOLUONG;
                var listsoluong = new List<int>();
                for (int i = 0; i <= sl; i++)
                    listsoluong.Add(i);
                return listsoluong;
            }
            
        }
    }
}
