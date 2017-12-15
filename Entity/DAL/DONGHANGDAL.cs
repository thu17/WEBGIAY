using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.EntityFramework;
namespace Entity.DAL
{
    public class DONGHANGDAL
    {
        WEBGIAYEntities db = null;
        public DONGHANGDAL()
        {
            db = new WEBGIAYEntities();
        }
        public List<DONHANG> listdh(int idcustomer)
        {
            return db.DONHANGs.Where(c=>c.MACUSTOMER==idcustomer).OrderByDescending(d=>d.NGAYMUA).ToList();
        }
        public void luudonhang(DONHANG dh, List<CTDH> ctdh)
        {
            DONHANG donhang = new DONHANG
            {
                MACUSTOMER=dh.MACUSTOMER,
                NGAYMUA=dh.NGAYMUA,
                DIACHI=dh.DIACHI,
                SDT=dh.SDT,
                TONGTIEN=dh.TONGTIEN,
                GHICHU=dh.GHICHU                
            };
            db.DONHANGs.Add(donhang);
            db.SaveChanges();
            int iddonhang = donhang.MADH;
            List<CTDH> listct = new List<CTDH>();
            listct = ctdh;
            foreach (var item in listct)
            {
                CTDH ct = new CTDH();
                ct.MADH = iddonhang;
                ct.MASP = item.MASP;
                ct.MAMERCHANT = item.MAMERCHANT;
                ct.SOLUONG = item.SOLUONG;
                ct.THANHTIEN = item.THANHTIEN;
                ct.TINHTRANG = item.TINHTRANG;
                ct.MAKICHCO = item.MAKICHCO;
                ct.GIAGIAM = item.GIAGIAM;
                db.CTDHs.Add(ct);
                db.SaveChanges();
            }

        }
    }
}
