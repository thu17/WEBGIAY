using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
using PagedList;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

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
            return db.SANPHAMs.Where(m=>m.TINHTRANG==1).ToList();
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
        public List<SANPHAM> ketquatimkiem(string tukhoa)
        {            
            List<SANPHAM> list = new List<SANPHAM>();
            object[] param = { new SqlParameter("@TUKHOA", tukhoa) };
            ////List<SANPHAM> list = db.Database.SqlQuery<object>("sp_timkiem @TUKHOA", param).ToList();
            //int count = db.Database.ExecuteSqlCommand("sp_timkiem @TUKHOA", param);
            //return list;

            DbRawSqlQuery<SANPHAM> data = db.Database.SqlQuery<SANPHAM>("sp_timkiem @TUKHOA",param);
            foreach (var item in data)
            {
                list.Add(item);
            }
            return list;
        }
       public List<SANPHAM> timtheothuonghieu(int [] thươnghieu)
        {
           if(thươnghieu!=null)
           {
               List<int> numberlist = new List<int>();
               foreach (int ma in thươnghieu)
               {
                   numberlist.Add(ma);
               }
               var listsp = getallsanpham();
               var result = (from n in numberlist
                             join sp in listsp
                             on n equals sp.MATHUONGHIEU into joi
                             from j in joi
                             where j.TINHTRANG == 1
                             select new SANPHAM()
                             {
                                 MASP = j.MASP,
                                 TENSP = j.TENSP,
                                 MATHUONGHIEU = j.MATHUONGHIEU,
                                 MADOITUONG = j.MADOITUONG,
                                 MALOAI = j.MALOAI,
                                 MAMERCHANT = j.MAMERCHANT,
                                 MAUSAC = j.MAUSAC,
                                 GIA = j.GIA,
                                 GIAGIAM = j.GIAGIAM,
                                 ANH = j.ANH
                             }).ToList();
               return result;
           }
           return null;
        }
       public List<SANPHAM> timtheophaloai(int[] phanloai)
       {
           if(phanloai!=null)
           {
               List<int> numberlist = new List<int>();
               foreach (int ma in phanloai)
               {
                   numberlist.Add(ma);
               }
               var listsp = getallsanpham();
               var result = (from n in numberlist
                             join sp in listsp
                             on n equals sp.MALOAI into joi
                             from j in joi
                             where j.TINHTRANG == 1
                             select new SANPHAM()
                             {
                                 MASP = j.MASP,
                                 TENSP = j.TENSP,
                                 MATHUONGHIEU = j.MATHUONGHIEU,
                                 MADOITUONG = j.MADOITUONG,
                                 MALOAI = j.MALOAI,
                                 MAMERCHANT = j.MAMERCHANT,
                                 MAUSAC = j.MAUSAC,
                                 GIA = j.GIA,
                                 GIAGIAM = j.GIAGIAM,
                                 ANH = j.ANH
                             }).ToList();
               return result;
           }
           return null;
          
       }
       public List<SANPHAM> timtheogia(float[] gia)
       {
           float tu = gia[0];
           float den = gia[1];
           
           if(gia!=null)
           {
               List<SANPHAM> listsp = new List<SANPHAM>();
               if (tu == 0)
               {
                   listsp = db.SANPHAMs.Where(g => g.GIA < den && g.TINHTRANG == 1).ToList();
               }
               else if (den == 0)
               {
                   listsp = db.SANPHAMs.Where(g => g.GIA > tu && g.TINHTRANG == 1).ToList();
               }
               else
               {
                   listsp = db.SANPHAMs.Where(g => g.GIA >= tu && g.GIA < den && g.TINHTRANG == 1).ToList();
               }
               return listsp;
           }
           return null;
       }
       public List<SANPHAM> ketqualoc(int[] thuonghieu, int[] phanloai, float[] gia)
       {
           List<SANPHAM> listth =new List<SANPHAM>();
           List<SANPHAM> listpl=new List<SANPHAM>();
           List<SANPHAM> listgia=new List<SANPHAM>();
           if (thuonghieu!=null)
           {
                listth = timtheothuonghieu(thuonghieu);
           }
           if(phanloai!=null){
                listpl = timtheophaloai(phanloai);
           }
           if(gia!=null)
           {
                 listgia = timtheogia(gia);
           }
           List<SANPHAM> spth = new List<SANPHAM>();
           foreach (var item in listth)
           {
               spth.Add(item);
           }
           foreach (var item in listpl)
           {
               SANPHAM sp = spth.Where(x => x.MASP == item.MASP).SingleOrDefault();
               if (sp==null)
               spth.Add(item);
           }
           foreach (var item in listgia)
           {
               SANPHAM sp = spth.Where(x => x.MASP == item.MASP).SingleOrDefault();
               if (sp == null)
               spth.Add(item);
           }
           return spth;          
       }
    }
}
