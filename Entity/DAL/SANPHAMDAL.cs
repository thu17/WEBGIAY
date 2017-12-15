using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
using PagedList;
using System.Data.Entity;

namespace Entity.DAL
{
    public class SANPHAMDAL
    {
        WEBGIAYEntities db = null;
        public SANPHAMDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<SANPHAM>getallsanpham()
        {
            return db.SANPHAMs.ToList();
        }
        public List<SANPHAM> listsanphammoi()
        {
            
                var list = db.SANPHAMs.Where(sp=>sp.TINHTRANG==1).OrderByDescending(s=>s.NGAYDANG).Take(9).ToList();
                return list;
            
        }
        public IPagedList<SANPHAM> paging(int? page)
        {
            
                int pageSize=9;
                int pageNumber=(page??1);
                var list = db.SANPHAMs.Where(sp => sp.TINHTRANG == 1).OrderByDescending(s => s.NGAYDANG).ToPagedList(pageNumber, pageSize);
                return list;
            
        }
        public SANPHAM sanphamnay(int id)
        {
            
            return db.SANPHAMs.Find(id);
        }
        
       
    }
}
