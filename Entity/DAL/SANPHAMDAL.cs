using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
using PagedList;
using Entity.ViewModel;
namespace Entity.DAL
{
    public class SANPHAMDAL
    {
        WEBGIAYEntities db = null;
        public SANPHAMDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<SANPHAM> listsanphammoi()
        {
            using (db)
            {
                var list = db.SANPHAMs.Where(sp=>sp.TINHTRANG==1).OrderByDescending(s=>s.NGAYDANG).Take(9).ToList();
                return list;
            }
        }
        public IPagedList<SANPHAM> paging(int? page)
        {
            using (db)
            {
                int pageSize=9;
                int pageNumber=(page??1);
                var list = db.SANPHAMs.Where(sp => sp.TINHTRANG == 1).OrderByDescending(s => s.NGAYDANG).ToPagedList(pageNumber, pageSize);
                return list;
            }
        }
        public SANPHAM sanphamnay(int id)
        {
            db = new WEBGIAYEntities();
            return db.SANPHAMs.Find(id);
        }
        public CHITIETSANPHAMViewModel chitietsanphamnay(int id)
        {
            using (db)
            {
                CHITIETSANPHAMViewModel viewmodel = new CHITIETSANPHAMViewModel();
                viewmodel.sp = this.sanphamnay(id);
                viewmodel.sp.CUNGSANPHAMs = db.CUNGSANPHAMs.Where(c => c.MASP == id).ToList();
                viewmodel.listanh = db.ANHCHITIETs.Where(la => la.MASP == id).ToList();
                return viewmodel;
            }
        }
    }
}
