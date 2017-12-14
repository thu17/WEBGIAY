using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.DAL
{
    public class CUNGSANPHAM_KICHCODAL
    {
        WEBGIAYEntities db = null;
        public CUNGSANPHAM_KICHCODAL()
        {
            db = new WEBGIAYEntities();
        }
       
       public List<int> listsoluongchon(int idsp,int idkichco)
        {
            using (db)
            {
                var soluong = (from c in db.CUNGSANPHAMs
                           where c.MASP == idsp && c.MAKICHCO == idkichco
                           select c.SOLUONG).SingleOrDefault();
                List<int> listsoluong = new List<int>();
                for (int i = 0; i <soluong;i++ )
                {
                    listsoluong.Add(i+1);
                }
                return listsoluong;
            }
        }
    }
}
