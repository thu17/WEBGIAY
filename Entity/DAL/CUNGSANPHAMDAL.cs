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
       public List<CUNGSANPHAM>getallcsp()
        {
            return db.CUNGSANPHAMs.ToList();
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
        public List<CUNGSANPHAM> listcungsanpham(int idsp)
        {            
            var list=db.CUNGSANPHAMs.Where(c => c.MASP == idsp).ToList();
            return list;
        }
        public bool themcsp(CUNGSANPHAM csp)
        {
            bool check = false;
            db.CUNGSANPHAMs.Add(csp);
            db.SaveChanges();
            check = true;
            return check;
        }
        public void capnhatsoluong(int idsp,int kc,int soluong)
        {
            var csp = db.CUNGSANPHAMs.Where(c => c.MASP == idsp && c.MAKICHCO == kc).SingleOrDefault();
            csp.SOLUONG -= soluong;
            db.SaveChanges();
        }
    }
}
